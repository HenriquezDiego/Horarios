using System;
using System.Collections.Generic;
using System.Linq;
using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;

namespace HorariosConsoleApp.Services
{
    public class HorarioDetalleServices
    {
        private readonly AppDbContext _dbContext;
        public HorarioDetalleServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public bool HorarioFraccionA()
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
            
            var horario = _dbContext.Horarios.FirstOrDefault(hr=>hr.Abreviatura.Equals("I"));
            horario.HorarioFraccion = horarioFraccionList;
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
        public bool HorarioFraccionB()
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
                                HoraInicio = new TimeSpan(10,0,0),
                                HoraFin = new TimeSpan(14,0,0),
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
                                HoraInicio = new TimeSpan(6,0,0),
                                HoraFin = new TimeSpan(18,0,0),
                            }  
                        
                    );

                }
                else
                {
                    var horarioFraccion = new HorarioFraccion()
                    {
                        DiaId = dia.DiaId,
                        HoraInicio = new TimeSpan(14,0,0),
                        HoraFin = new TimeSpan(22,0,0),
                    };
                
                    horarioFraccionList.Add(horarioFraccion);
                }
               

            }
            
            var horario = _dbContext.Horarios.FirstOrDefault(hr=>hr.Abreviatura.Equals("II"));
            horario.HorarioFraccion = horarioFraccionList;
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
        public bool HorarioFraccionC()
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
                                HoraInicio = new TimeSpan(14,0,0),
                                HoraFin = new TimeSpan(18,0,0),
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
                                HoraInicio = new TimeSpan(18,0,0),
                                HoraFin = new TimeSpan(23,59,59),
                            }  
                        
                    );

                }
                else
                {
                    horarioFraccionList.Add(new HorarioFraccion() 
                        {
                            DiaId = dia.DiaId,
                            HoraInicio = new TimeSpan(0,0,0),
                            HoraFin = new TimeSpan(6,0,0)
                        }
                    );

                    horarioFraccionList.Add( new HorarioFraccion()
                        {
                             DiaId = dia.DiaId,
                            HoraInicio = new TimeSpan(10,0,0),
                            HoraFin = new TimeSpan(18,0,0)
                        }
                    );
                }

            }
            
            var horario = _dbContext.Horarios.FirstOrDefault(hr=>hr.Abreviatura.Equals("III"));
            horario.HorarioFraccion = horarioFraccionList;
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public void GenerarEmpleadoEquipos()
        {
            var list = new List<EmpleadoEquipo>();
            for (var i = 1; i < 5; i++)
            {
                var row = new EmpleadoEquipo()
                {
                    EmpleadoId = i,
                    EquipoId = 1
                };
                list.Add(row);
            }
            for (var i = 5; i < 9; i++)
            {
                var row = new EmpleadoEquipo()
                {
                    EmpleadoId = i,
                    EquipoId = (i>6)?2:3
                };
                list.Add(row);
            }
            
            
            _dbContext.EmpleadosEquipos.AddRange(list);
            _dbContext.SaveChanges();
        }
    }
}
