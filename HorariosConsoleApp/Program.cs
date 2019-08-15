using HorariosConsoleApp.Persistence;
using HorariosConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

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

            var serviceProvider = services.BuildServiceProvider();
            var seedService = serviceProvider.GetService<ISeedService>();
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
                }
                else
                {
                    return;
                }
            }
            
            Console.WriteLine("¡Base de datos Generada!");
            Console.ReadLine();
            
            
        }
    }
}
