using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using HorariosConsoleApp.Helpers;

namespace HorariosConsoleApp.Services
{
    public class PagoEmpleadoService : IPagoEmpleadoService
    {
        private readonly AppDbContext _dbContext;

        public PagoEmpleadoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Calcular(DateTime fechaInicio, DateTime fechaFin)
        {
            
        }

        public void Calcular(DateTime fecha)
        {
            var empleados = _dbContext.Empleados
                .Include(em=>em.Equipo)
                .ThenInclude(em=>em.Horario).ToList();

            var queryhorarioDetalle = _dbContext.ConsultaHoraDetalle.ToList();

            var monthInfo = Workday.DateInfo(fecha);
            foreach (var empleado in empleados)
            {
                
                var pagoEmpleado = new PagoEmpleado()
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Equipo = empleado.Equipo.Nombre,
                    Fecha = fecha,
                    SalarioBase = empleado.SalarioBase,
                    DiasLaborados = monthInfo.Weekdays,
                    DiasCompensatorios = monthInfo.Sundays,
                    DetallePagoEmpleados = new List<DetallePagoEmpleado>()
                };

                var detalleHorasFiltered = queryhorarioDetalle.Where(hd => hd.Horario.Equals(empleado.Equipo.Horario.Alias) && hd.DiaId == 2);

                foreach (var value in detalleHorasFiltered)
                {
                    var detallePago = new DetallePagoEmpleado()
                    {
                        TipoHora = value.TipoHora,
                        CantidadHoras = value.NumeroHoras,
                        Porcentaje = value.PorcentajeHora,
                        EsNocturna = value.EsNocturna,
                        
                    };

                    pagoEmpleado.DetallePagoEmpleados.Add(detallePago);
                }

            }

        }
    }
}
