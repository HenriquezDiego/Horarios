using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HorariosConsoleApp.Services
{
    public class EmpleadoServices
    {
        private readonly AppDbContext _dbContext;
        public readonly string Path = System.IO.Path.Combine(Directory.GetCurrentDirectory(),
            "./Empleados.json");
        public EmpleadoServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (!_dbContext.Empleados.Any())
            {
                var json = JObject.Parse(File.ReadAllText(Path));
                var equipos =
                    JsonConvert.DeserializeObject<IEnumerable<Equipo>>(json["Equipos"]
                        .ToString(Formatting.None));

                _dbContext.Equipos.AddRange(equipos);
                _dbContext.SaveChanges();
            }
            
             
            
        }
    }
}
