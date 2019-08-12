using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                    Descripcion = "Lunes a viernes de 6:00 am a 2:00 pm"
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
            var semanaDias = _dbContext.Dias.Where(d => !d.Abreviatura.Equals("S")
                                                        && !d.Abreviatura.Equals("D")).ToList();
            //var horas = _dbContext.Horas.ToList();
            //var tipoHora = _dbContext.TipoHoras.ToList();
            List<HorarioFraccion> horarioFraccionList = new List<HorarioFraccion>();
            foreach (var dia in semanaDias)
            {

                var horarioFraccion = new HorarioFraccion()
                {
                    DiaId = dia.DiaId,
                    HoraInicioId = 7,
                    HoraFinId = 15,
                };

                horarioFraccionList.Add(horarioFraccion);

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
            if (horarios.Count > 0 && horarioFraccion.Count > 0)
            {
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

            return _messages;

        }
    }
}
