using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
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

            var monthInfo = Workday.DateInfo(fecha);
            foreach (var empleado in empleados)
            {
                
                var pagoEmpleado = new PagoEmpleado()
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Equipo = empleado.Equipo.Nombre,
                    Horario = empleado.Equipo.Horario.Alias,
                    Fecha = fecha,
                    SalarioBase = empleado.SalarioBase,
                    DiasLaborados = monthInfo.Weekdays,
                    DiasCompensatorios = monthInfo.Sundays,
                };


                _dbContext.PagoEmpleados.Add(pagoEmpleado);
            }
            
            _dbContext.SaveChanges();
        }
    }
}
