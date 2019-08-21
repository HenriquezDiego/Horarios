using HorariosConsoleApp.Persistence;
using HorariosConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;
using HorariosConsoleApp.Repositories;
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
            services.AddTransient<IPagoRepository, PagoRepository>();


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
                        calcularPago.Calcular(new DateTime(2019, 7, 1), new DateTime(2019, 7, 31));
                        Console.WriteLine("¡Base de datos Generada!");
                    
                    }
                    Console.WriteLine();
                    Console.WriteLine(@"Desea verifica la consulta de prueba (MitnickQuery)?(y/n)?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        var mitnickQuery = from deta in appDbContext.DetallePagoEmpleados
                            join pago in appDbContext.PagoEmpleados on deta.PagoEmpleadoId equals pago.PagoEmpleadoId
                            select new
                            {
                                pago.EmpleadoId,
                                pago.Dia,
                                CantidadHora = deta.CantidadHoras,
                                deta.TipoHora,
                                deta.Porcentaje,
                                Total = deta.CantidadHoras * (deta.Porcentaje / 100) * pago.SalarioBase
                            };

                        var result = mitnickQuery.GroupBy(m => new {m.EmpleadoId,m.Dia,m.TipoHora}).Select(m => new
                        {
                            m.Key.EmpleadoId,
                            m.Key.Dia,
                            m.Key.TipoHora,
                            Total = m.Sum(l => l.Total)
                        });

                        Console.WriteLine();
                        foreach (var value in result)
                        {
                            Console.WriteLine($"{value.EmpleadoId} - {value.Dia} - " +
                                              $"{value.Total.ToString("#.00", CultureInfo.InvariantCulture)}");
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
