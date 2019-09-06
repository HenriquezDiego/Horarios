using System.Collections.Generic;
using System.Linq;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;

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
        private bool SetupDatabase()
        {
            var horarioFragmentos = _dbContext.HorariosFragmentos.ToList();
            var detallehoras = _dbContext.HorarioFragmentoDetalle.ToList();
            var pagoEmpleado = _dbContext.PagoEmpleados;
            if (detallehoras.Count > 0 && horarioFragmentos.Count > 0)
            {
                _dbContext.HorarioFragmentoDetalle.RemoveRange(detallehoras);
                _dbContext.HorariosFragmentos.RemoveRange(horarioFragmentos);
                _dbContext.PagoEmpleados.RemoveRange(pagoEmpleado);
            }

            _dbContext.Database.ExecuteSqlCommand(@"CREATE OR ALTER VIEW [dbo].[DetalleHoras] AS 
             SELECT COUNT(*) AS NumeroHoras,th.TipoHoraId,th.Nombre AS TipoHora,th.PorcentajeExtra AS PorcentajeHora,h.Alias
            AS Horario,d.DiaId,d.Nombre
            AS Dia,hf.EsNocturno AS FragmentoEsNocturno,th.EsNocturna AS HoraEsNocturna
            FROM dbo.HorarioFragmentoDetalle AS hd INNER JOIN
            dbo.TipoHoras AS th ON hd.TipoHoraId = th.TipoHoraId INNER JOIN
            dbo.HorariosFragmentos AS hf ON hd.HorarioFragmentoId = hf.HorarioFragmentoId INNER JOIN
            dbo.Horarios AS h ON hf.HorarioId = h.HorarioId INNER JOIN
            dbo.Dias AS d ON hf.DiaId = d.DiaId
            GROUP BY th.Nombre,
            hd.HorarioFragmentoId,h.Alias,d.Nombre,d.DiaId,th.TipoHoraId,th.PorcentajeExtra,hf.EsNocturno,th.EsNocturna");
            return _dbContext.SaveChanges() > 0;
        }
        public IEnumerable<string> Generar()
        {
            if (SetupDatabase()) _messages.Add("Base de datos preparada");
            _empleadoService.Seed();
            _messages.AddRange(_horarioService.Seed());


            return _messages;
        }
    }
}
