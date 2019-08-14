using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using HorariosConsoleApp.Helpers;

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
        private void GenerateHorarioFraccion()
        {
            var horarioDetalleServices = new HorarioDetalleServices(_dbContext);
            horarioDetalleServices.HorarioFraccionA();
            horarioDetalleServices.HorarioFraccionB();
            horarioDetalleServices.HorarioFraccionC();
        
        }

        private bool Clean()
        {
            var horarioFraccion = _dbContext.HorarioFraccion.ToList();
            var detallehoras = _dbContext.HoraDetalles.ToList();
            if (detallehoras.Count > 0 && horarioFraccion.Count > 0)
            {
                _dbContext.HoraDetalles.RemoveRange(detallehoras);
                _dbContext.HorarioFraccion.RemoveRange(horarioFraccion);

            }

            if (_dbContext.SaveChanges() <= 0)
            {
                return false;
            }

            return true;
        }

        public bool GenerarHoraDetalle(string abreviatura)
        {
            var horario = _dbContext.Horarios
                                            .Include(hr=> hr.HorarioFraccion)
                                            .ThenInclude(frag=> frag.Dia)
                                            .FirstOrDefault(hr => hr.Abreviatura.Equals(abreviatura));

            var fragmentosHorario = horario.HorarioFraccion;
            
            foreach (var fragmento in fragmentosHorario)
            {
                var dia = fragmento.Dia.Abreviatura;
                List<HoraDetalle> listHoras = new List<HoraDetalle>();
                var hora = fragmento.HoraInicio.Hours;
                var horaFin = fragmento.HoraFin.Hours;

                while (hora <= horaFin)
                {
                    var detalleHora = new HoraDetalle()
                    {
                        Hora = new TimeSpan(hora,0,0),
                        HorarioFraccionId = fragmento.HorarioFraccionId,
                        TipoHoraId = Workday.CheckHour(hora,dia)
                    };
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

        public IEnumerable<string> Generate()
        {

            if (Clean())
            {
                _messages.Add("Base de datos preparada");
            }
            var empleadoServices = new EmpleadoServices(_dbContext);
            empleadoServices.Seed();

            GenerateHorarioFraccion();
            if (GenerarHoraDetalle("I")
            &&GenerarHoraDetalle("II")
            &&GenerarHoraDetalle("III")
            )
            {
                _messages.Add("Horas detalle ingresadas");
            }

            return _messages;

        }
    }

}
