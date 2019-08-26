using HorariosConsoleApp.Persistence;
using HorariosConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;
using HorariosConsoleApp.Helpers;
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
                        calcularPago.Calcular(new DateTime(2019, 7, 1), new DateTime(2019, 7, 28));
                        
                    }

                    Console.WriteLine();
                    Console.WriteLine(@"Desea verifica la consulta de prueba (MitnickQuery)?(y/n)?");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        //TODO
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
