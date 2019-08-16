using System.Collections.Generic;
using System.Linq;
using HorariosConsoleApp.Persistence;

namespace HorariosConsoleApp.Services
{
    public class SeedService : ISeedService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHorarioService _horarioService;
        private readonly IEmpleadoService _empleadoService;
        private readonly List<string> _messages;
       

        public SeedService(AppDbContext dbContext,
            IEmpleadoService empleadoService,
            IHorarioService horarioService)
        {
            _dbContext = dbContext; 
            _empleadoService = empleadoService;
            _horarioService = horarioService;
            _messages = new List<string>();
        }
        private bool Clean()
        {
            var horarioFragmentos = _dbContext.HorarioFragmento.ToList();
            var detallehoras = _dbContext.HoraDetalles.ToList();
            if (detallehoras.Count > 0 && horarioFragmentos.Count > 0)
            {
                _dbContext.HoraDetalles.RemoveRange(detallehoras);
                _dbContext.HorarioFragmento.RemoveRange(horarioFragmentos);

            }

            if (_dbContext.SaveChanges() <= 0)
            {
                return false;
            }

            return true;
        }
        public IEnumerable<string> Generar()
        {
            if (Clean()) _messages.Add("Base de datos preparada");
            _empleadoService.Seed();
            _messages.AddRange(_horarioService.Seed());

            return _messages;
        }
    }
}
