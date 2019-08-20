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
                .Where(log=>log.FechaFin!=null && fechaInicio>= log.FechaInicio && fechaFin<=log.FechaFin)
                .ToList();

            var empleados = _dbContext.Empleados
                            .Include(em=>em.Equipo)
                            .ThenInclude(em=>em.Horario).Take(1).ToList();


            var horasDetalle = _dbContext.ConsultaHoraDetalle.ToList();
            
            foreach (var empleado in empleados)
            {
                string horario;
                //var salarioHora = (empleado.SalarioBase/30)/empleado.Equipo.Horario.HorasEfectivas;
                var salarioHora = (empleado.SalarioBase/30)/8;
                
                        while (fecha<=fechaFin)
                        {
                            var dia = fecha.DayOfWeek == 0 ? 7 : (int) fecha.DayOfWeek;
                            
                            var pagoEmpleado = new PagoEmpleado()
                            {
                                EmpleadoId = empleado.EmpleadoId,
                                Equipo = empleado.Equipo.Nombre,
                                Dia = dia.ToString(),
                                FechaPago = fecha,
                                SalarioHora = salarioHora,
                                DetallePago = new List<DetallePagoEmpleado>()
                            };

                            //lista test
                            listFechas.Add(fechaInicio.ToString());


                            horario = empleado.Equipo.Horario.Alias;
                            if (logCambioHorarios.Any())
                            { 
                                var cambio = logCambioHorarios
                                                .FirstOrDefault(log => log.EmpleadoId == empleado.EmpleadoId                            &&fechaInicio>=log.FechaInicio&&fechaInicio<=log.FechaFin);
                                horario = cambio.Horario;
                            }

                            pagoEmpleado.Horario = horario;
                            
                            var horasDia = horasDetalle.Where(hd => hd.Horario.Equals(horario)
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

                            _dbContext.PagoEmpleados.Add(pagoEmpleado);
                            fecha = fecha.AddDays(1);
                        }

                        fecha = fechaInicio;
            }

            _dbContext.SaveChanges();
            return listFechas;
        }

    }
}
