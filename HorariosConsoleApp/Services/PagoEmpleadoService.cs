using HorariosConsoleApp.Persistence;
using System;
using System.Collections.Generic;

namespace HorariosConsoleApp.Services
{
    public class PagoEmpleadoService : IPagoEmpleadoService
    {
        private readonly AppDbContext _dbContext;

        public PagoEmpleadoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<string> Calcular(DateTime fechaInicio, DateTime fechaFin)
        {
            var listFechas = new List<string>();
            if (fechaFin > fechaInicio)
            {
                if (fechaInicio.Month == fechaFin.Month)
                {
                    while (fechaInicio<=fechaFin)
                    {
                        listFechas.Add(fechaInicio.ToString());
                        
                        fechaInicio = fechaInicio.AddDays(1);
                    }
                }
                
            }

            return listFechas;
        }

        public void Query()
        {
            //var x = from horaDetalle in _dbContext.HoraDetalles
            //        .Include(ht => ht.TipoHora)
            //        .Include(ht => ht.HorarioFragmento)
            //        .ThenInclude(ht => ht.Dia)
            //        .Include(ht => ht.HorarioFragmento).ToList()
            //    select new object()
            //    {

            //    };

        }
    }
}
