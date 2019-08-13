using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorariosConsoleApp.Services
{
    public class HorarioService
    {
        private readonly AppDbContext _dbContext;
        private readonly List<string> _messages;

        public HorarioService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _messages = new List<string>();
        }

        private bool GenerateHorario()
        {
            var listaHorarios = new List<Horario>()
            {

                new Horario()
                {
                    Descripcion = "Lunes a viernes de 6:00 am a 2:00 pm" +
                                  "Sabado de 6:00 am a 10:00 am y 6:00 pm 12:00 am",
                    Abreviatura = "I",
                    Alias = "Azul"
                },

            };

            _dbContext.Horarios.AddRange(listaHorarios);
            if (_dbContext.SaveChanges() <= 0)
            {
                return false;
            }

            return true;
        }

        private bool GenerateHorarioFraccion()
        {
            var semanaDias = _dbContext.Dias.ToList();

            

            List<HorarioFraccion> horarioFraccionList = new List<HorarioFraccion>();
            foreach (var dia in semanaDias)
            {
                
                if (dia.Abreviatura.Equals("S"))
                {
                    horarioFraccionList.AddRange(
                        new List<HorarioFraccion>()
                        {
                            new HorarioFraccion()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(6,0,0),
                                HoraFin = new TimeSpan(10,0,0),
                            },
                            new HorarioFraccion()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(18,0,0),
                                HoraFin = new TimeSpan(23,59,59),
                            }
                        }
                    );
                }
                else if(dia.Abreviatura.Equals("D"))
                {

                    horarioFraccionList.Add(
                        
                            new HorarioFraccion()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(0,0,0),
                                HoraFin = new TimeSpan(6,0,0),
                            }  
                        
                    );

                }
                else
                {
                    var horarioFraccion = new HorarioFraccion()
                    {
                        DiaId = dia.DiaId,
                        HoraInicio = new TimeSpan(6,0,0),
                        HoraFin = new TimeSpan(14,0,0),
                    };
                
                    horarioFraccionList.Add(horarioFraccion);
                }
               

            }



            var horario = _dbContext.Horarios.FirstOrDefault();
            horario.HorarioFraccion = horarioFraccionList;
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        private bool Clean()
        {
            var horarios = _dbContext.Horarios.ToList();
            var horarioFraccion = _dbContext.HorarioFraccion.ToList();
            var detallehoras = _dbContext.HoraDetalles.ToList();
            if (horarios.Count > 0 && horarioFraccion.Count > 0)
            {
                _dbContext.HoraDetalles.RemoveRange(detallehoras);
                _dbContext.HorarioFraccion.RemoveRange(horarioFraccion);
                _dbContext.Horarios.RemoveRange(horarios);

            }

            if (_dbContext.SaveChanges() <= 0)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<string> Generate()
        {

            if (Clean())
            {
                _messages.Add("Base de datos preparada");
            }

            if (GenerateHorario())
            {
                _messages.Add("Horarios Creados");
            }

            if (GenerateHorarioFraccion())
            {
                _messages.Add("Se ha ingresado los horarios fraccionados");
            }

            if (GenerarHoraDetalle())
            {
                _messages.Add("Horas detalle ingresadas");
            }

            return _messages;

        }

        public bool GenerarHoraDetalle()
        {
            var horario = _dbContext.Horarios
                                            .Include(hr=> hr.HorarioFraccion)
                                            .FirstOrDefault(hr => hr.Abreviatura.Equals("I"));

            var fragmentosHorario = horario.HorarioFraccion;
            
            foreach (var fragmento in fragmentosHorario)
            {
                List<HoraDetalle> listHoras = new List<HoraDetalle>();
                var hora = fragmento.HoraInicio.Hours;
                var horaFin = fragmento.HoraFin.Hours;

                while (hora <= horaFin)
                {
                    var detalleHora = new HoraDetalle()
                    {
                        Hora = new TimeSpan(hora,0,0),
                        HorarioFraccionId = fragmento.HorarioFraccionId
                    };
                    if (hora == 22 || hora == 23 && hora > 0 && hora < 6 && fragmento.DiaId == 7)
                    {
                        detalleHora.TipoHoraId = 6;
                    } 
                    else if (hora > 5 &&hora < 22 && fragmento.DiaId == 7)
                    {
                        detalleHora.TipoHoraId = 5;
                    }

                    else if (hora > 22)
                    {
                        detalleHora.TipoHoraId = 2;
                    }
                    else
                    {
                        detalleHora.TipoHoraId = 1;
                    }
                    listHoras.Add(detalleHora);
                    hora++;
                }

                _dbContext.HoraDetalles.AddRange(listHoras);
                if (_dbContext.SaveChanges() < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
