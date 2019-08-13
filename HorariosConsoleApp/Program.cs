using HorariosConsoleApp.Persistence;
using HorariosConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace HorariosConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {


            using (var appDbContext = new AppDbContext())
            {
                Console.WriteLine("Horarios Console App");

                Console.WriteLine(@"Desea aplicar la ultima migración estable (y/n)?");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("");
                    appDbContext.Database.Migrate();
                }

                var horarioService = new HorarioService(appDbContext);
                foreach (var msj in horarioService.Generate())
                {
                    Console.WriteLine(msj);
                }

            }
            Console.WriteLine("¡Base de datos Generada!");
            Console.ReadLine();
            
            
        }
    }
}
