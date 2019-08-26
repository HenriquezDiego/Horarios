using System;
using System.Collections.Generic;
using System.Linq;
using ContaWebApi.DataAccess.Repositories;
using HorariosConsoleApp.Entities;
using HorariosConsoleApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HorariosConsoleApp.Repositories
{
    public class PagoRepository : Repository<PagoEmpleado>, IPagoRepository
    {
        private AppDbContext ContaContext => Context as AppDbContext;
        public PagoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<object> GetCalculoPago(DateTime fechaInicio, DateTime fechaFin)
        {
          

            return null;

        }
    }
}
