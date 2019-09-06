using HorariosConsoleApp.Persistence;
using HorariosConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using HorariosConsoleApp.Helpers;
using System.Linq;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace HorariosConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>();
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<IHorarioService, HorarioService>();
            services.AddTransient<ISeedService, SeedService>();
            services.AddSingleton<IPagoEmpleadoService, PagoEmpleadoService>();

            var serviceProvider = services.BuildServiceProvider();
            var seedService = serviceProvider.GetService<ISeedService>();
            var calcularPago = serviceProvider.GetService<IPagoEmpleadoService>();

            try
            {
                using (var appDbContext = new AppDbContext())
                {
                    Console.WriteLine("Horarios Console App");

                    Console.WriteLine(@"Antes de continuar verifique no tenga ninguna versión de la base de datos creada. Desea continuar (y/n)?");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("");
                        appDbContext.Database.Migrate();
                        foreach (var msj in seedService.Generar())
                        {
                            Console.WriteLine(msj);
                        }
                        Console.WriteLine("¡Base de datos Generada!");
                    }
                    Console.WriteLine();
                    Console.WriteLine(@"Desea CalcularPagoEmpleado?(y/n)?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        calcularPago.Calcular(new DateTime(2019, 2, 1));
                        
                    }

                    Console.WriteLine();
                    Console.WriteLine(@"Desea verifica la consulta de prueba (MitnickQuery)?(y/n)?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        var queryhorarioDetalle = appDbContext.ConsultaHoraDetalle.ToList();

                        var pagoEmpleados = appDbContext.PagoEmpleados
                                                       .Include(emp=> emp.Empleado).ToList();

                        foreach (var pagoEmpleado in pagoEmpleados)
                        {
                            List<DetalleHoras> horariosFiltered;
                            if (pagoEmpleado.Horario.Equals("Azul"))
                            {
                                horariosFiltered = queryhorarioDetalle.Where(hd =>(
                                    hd.DiaId == 2 || hd.DiaId == 6 || hd.DiaId == 7)
                                    &&hd.Horario.Equals("Azul")).ToList();
                            }
                            else if(pagoEmpleado.Horario.Equals("Rojo"))
                            {
                                horariosFiltered = queryhorarioDetalle.Where(hd =>
                                    (hd.DiaId == 2 || hd.DiaId == 7)
                                    &&hd.Horario.Equals("Rojo")).ToList();
                            }
                            else
                            {
                                horariosFiltered = queryhorarioDetalle.Where(hd =>(
                                    hd.DiaId == 2 || hd.DiaId == 7 || hd.DiaId==1 && hd.NumeroHoras==6)
                                    &&hd.Horario.Equals("Negro")).ToList();
                            }
                            var result = new List<object>();
                            foreach (var horario in horariosFiltered)
                            { 
                                var salarioHora = pagoEmpleado.SalarioBase/30/(horario.EsNocturno ?  Workday.HeN:Workday.HeD);
                                
                                var x = new
                                {
                                    Nombre = $"{pagoEmpleado.Empleado.Nombre} {pagoEmpleado.Empleado.Apellido}",
                                    horario.Horario,
                                    horario.TipoHora,
                                    SubTotal = (horario.PorcentajeHora/100)*horario.NumeroHoras*salarioHora
                                               *(horario.DiaId==2?pagoEmpleado.DiasLaborados
                                                   :pagoEmpleado.DiasCompensatorios)
                                };
                                result.Add(x);
                            }

                            foreach (var value in result)
                            {
                                Console.WriteLine(value);
                            }
                        }
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message:{e.Message} StackTrace:{e.StackTrace}");
                Console.ReadLine();
            }
            
        }
    }
}
