using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using HorariosConsoleApp.Helpers;

namespace HorariosConsoleApp.Services
{
    public class HorarioService: IHorarioService
    {
        private readonly AppDbContext _dbContext;

        public HorarioService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        private bool HorarioFragmentoA()
        {
            var semanaDias = _dbContext.Dias.ToList();

            List<HorarioFragmento> horarioFraccionList = new List<HorarioFragmento>();
            foreach (var dia in semanaDias)
            {
                
                if (dia.Abreviatura.Equals("S"))
                {
                    horarioFraccionList.AddRange(
                        new List<HorarioFragmento>()
                        {
                            new HorarioFragmento()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(6,0,0),
                                HoraFin = new TimeSpan(10,0,0),
                            },
                            new HorarioFragmento()
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
                        
                            new HorarioFragmento()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(0,0,0),
                                HoraFin = new TimeSpan(6,0,0),
                            }  
                        
                    );

                }
                else
                {
                    var horarioFraccion = new HorarioFragmento()
                    {
                        DiaId = dia.DiaId,
                        HoraInicio = new TimeSpan(6,0,0),
                        HoraFin = new TimeSpan(14,0,0),
                    };
                
                    horarioFraccionList.Add(horarioFraccion);
                }
               

            }
            
            var horario = _dbContext.Horarios.FirstOrDefault(hr=>hr.Abreviatura.Equals("I"));
            horario.HorarioFragmentos = horarioFraccionList;
            return _dbContext.SaveChanges() > 0;

        }
        private bool HorarioFragmentoB()
        {
            var semanaDias = _dbContext.Dias.ToList();

            List<HorarioFragmento> horarioFraccionList = new List<HorarioFragmento>();
            foreach (var dia in semanaDias)
            {
                
                if (dia.Abreviatura.Equals("S"))
                {
                    horarioFraccionList.AddRange(
                        new List<HorarioFragmento>()
                        {
                            new HorarioFragmento()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(10,0,0),
                                HoraFin = new TimeSpan(14,0,0),
                            }
                        }
                    );
                }
                else if(dia.Abreviatura.Equals("D"))
                {

                    horarioFraccionList.Add(
                        
                            new HorarioFragmento()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(6,0,0),
                                HoraFin = new TimeSpan(18,0,0),
                            }  
                        
                    );

                }
                else
                {
                    var horarioFraccion = new HorarioFragmento()
                    {
                        DiaId = dia.DiaId,
                        HoraInicio = new TimeSpan(14,0,0),
                        HoraFin = new TimeSpan(22,0,0),
                    };
                
                    horarioFraccionList.Add(horarioFraccion);
                }
               

            }
            
            var horario = _dbContext.Horarios.FirstOrDefault(hr=>hr.Abreviatura.Equals("II"));
            horario.HorarioFragmentos = horarioFraccionList;
            return _dbContext.SaveChanges() > 0;
        }
        private bool HorarioFragmentoC()
        {
            var semanaDias = _dbContext.Dias.ToList();

            List<HorarioFragmento> horarioFraccionList = new List<HorarioFragmento>();
            foreach (var dia in semanaDias)
            {

                if (dia.Abreviatura.Equals("S"))
                {
                    horarioFraccionList.AddRange(
                        new List<HorarioFragmento>()
                        {
                            new HorarioFragmento()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(14,0,0),
                                HoraFin = new TimeSpan(18,0,0),
                            }
                        }
                    );
                }
                else if (dia.Abreviatura.Equals("D"))
                {

                    horarioFraccionList.Add(

                            new HorarioFragmento()
                            {
                                DiaId = dia.DiaId,
                                HoraInicio = new TimeSpan(18, 0, 0),
                                HoraFin = new TimeSpan(23, 59, 59),
                            }

                    );

                    horarioFraccionList.Add(new HorarioFragmento()
                    {
                        DiaId = 1,
                        HoraInicio = new TimeSpan(0, 0, 0),
                        HoraFin = new TimeSpan(6, 0, 0)
                    });

                }
                else
                {
                    horarioFraccionList.Add(new HorarioFragmento()
                    {
                        DiaId = dia.DiaId,
                        HoraInicio = new TimeSpan(22, 0, 0),
                        HoraFin = new TimeSpan(23, 59, 59)
                    }
                    );

                    horarioFraccionList.Add(new HorarioFragmento()
                    {
                        DiaId = dia.DiaId+1,
                        HoraInicio = new TimeSpan(0, 0, 0),
                        HoraFin = new TimeSpan(6, 0, 0)
                    });

                }
                
            }
            
            var horario = _dbContext.Horarios.FirstOrDefault(hr=>hr.Abreviatura.Equals("III"));
            horario.HorarioFragmentos = horarioFraccionList;
            return _dbContext.SaveChanges() > 0;
        }

        private bool GenerarHoraDetalle(string horarioAbreviatura)
        {
            var horario = _dbContext.Horarios
                                            .Include(hr=> hr.HorarioFragmentos)
                                            .ThenInclude(frag=> frag.Dia)
                                            .FirstOrDefault(hr => hr.Abreviatura.Equals(horarioAbreviatura));

            var fragmentosHorario = horario.HorarioFragmentos;
            
            foreach (var fragmento in fragmentosHorario)
            {
                var horasEfectivas = (Workday.CheckSection(fragmento.HoraInicio, fragmento.HoraFin)) ? Workday.HeN : Workday.HeD;

                var dia = fragmento.Dia.Abreviatura;
                List<HoraDetalle> listHoras = new List<HoraDetalle>();
                var hora = fragmento.HoraInicio.Hours;
                var horaFin = fragmento.HoraFin.Hours;
                horaFin = horaFin == 23 ? 24 : horaFin;
                var horasTrabajadas = 0;
                var extra = false;
                while (hora < horaFin)
                {
                    horasTrabajadas++;

                    if (horasTrabajadas > horasEfectivas || fragmento.Dia.DiaId==1 && fragmento.HoraInicio.Hours<6
                        || fragmento.Dia.DiaId==7 || fragmento.HoraInicio.Hours>=18 && fragmento.Dia.DiaId==6)
                    {
                        extra = true;
                    }


                    var detalleHora = new HoraDetalle()
                    {
                        Hora = new TimeSpan(hora,0,0),
                        HorarioFragmentoId = fragmento.HorarioFragmentoId,
                        TipoHoraId = Workday.CheckHour(hora,dia,extra)
                    };
                    listHoras.Add(detalleHora);

                    hora++;
                }

                _dbContext.HoraDetalles.AddRange(listHoras);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<string> Seed()
        {
            var mensajes = new List<string>();
            if(HorarioFragmentoA()) mensajes.Add("Fragmento A done");
            if(HorarioFragmentoB()) mensajes.Add("Fragmento B done");
            if(HorarioFragmentoC()) mensajes.Add("Fragmento C done");
            if(GenerarHoraDetalle("I") 
               &&GenerarHoraDetalle("II")
               &&GenerarHoraDetalle("III")) mensajes.Add("HorasDetalle done");
            return mensajes;

        }
    }

}
