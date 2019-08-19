using HorariosConsoleApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using HorariosConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

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
            var fecha = fechaInicio;
            var listFechas = new List<string>();
            var logCambioHorarios = _dbContext.CambioHorarios
                .Where(log=>log.FechaFin!=null && log.FechaInicio.Month==fechaInicio.Month
                                               &&log.FechaInicio.Year==fechaInicio.Year)
                .ToList();

            var empleados = _dbContext.Empleados
                            .Include(em=>em.Equipo)
                            .ThenInclude(em=>em.Horario).ToList();


            var horasDetalle = _dbContext.ConsultaHoraDetalle.ToList();
            
            foreach (var empleado in empleados)
            {
                var horario = empleado.Equipo.Horario.Alias;
                //var salarioHora = (empleado.SalarioBase/30)/empleado.Equipo.Horario.HorasEfectivas;
                var salarioHora = (empleado.SalarioBase/30)/8;
                
                if (fechaFin > fechaInicio)
                {
                    if (fechaInicio.Month == fechaFin.Month)
                    {
                        while (fecha<=fechaFin)
                        {
                            var dia = fechaInicio.DayOfWeek == 0 ? 7 : (int) fechaInicio.DayOfWeek;
                            
                            var pagoEmpleado = new PagoEmpleado()
                            {
                                EmpleadoId = empleado.EmpleadoId,
                                Equipo = empleado.Equipo.Nombre,
                                Horario =  empleado.Equipo.Horario.Alias,
                                Dia = dia.ToString(),
                                FechaPago = fechaInicio,
                                SalarioHora = salarioHora,
                                DetallePago = new List<DetallePagoEmpleado>()
                            };

                            listFechas.Add(fechaInicio.ToString());


                            if (logCambioHorarios.Any())
                            { 
                                var cambio = logCambioHorarios
                                                .FirstOrDefault(log => log.EmpleadoId == empleado.EmpleadoId                            &&fechaInicio>=log.FechaInicio&&fechaInicio<=log.FechaFin);
                                horario = cambio.Horario;
                            }

                            

                            horasDetalle = horasDetalle.Where(hd => hd.Horario.Equals(horario)
                                                                  &&hd.DiaId==dia).ToList();


                            foreach (var detalle in horasDetalle)
                            {
                                pagoEmpleado.DetallePago.Add(new DetallePagoEmpleado()
                                {
                                    TipoHora = detalle.TipoHora,
                                    CantidadHoras = detalle.NumeroHoras,
                                    Porcentaje = detalle.PorcentajeHora
                                });
                            }

                            fecha = fecha.AddDays(1);

                            _dbContext.PagoEmpleados.Add(pagoEmpleado);
                        }

                        fecha = fechaInicio;
                    }
                
                }

            }

            _dbContext.SaveChanges();
            return listFechas;
        }

    }
}
