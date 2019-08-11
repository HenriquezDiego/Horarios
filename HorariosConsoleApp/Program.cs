using System;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HorariosConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Horarios Console App");
            Console.WriteLine("Por favor presione Enter para aplicar la migracion");
            Console.WriteLine("o presione cualquier otra tecla para salir");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                using (var appDbContext = new AppDbContext())
                {
                    appDbContext.Database.Migrate();
                }

                Console.WriteLine("¡Base de datos Generada!");
                Console.ReadLine();
            }
            
        }
    }
}
