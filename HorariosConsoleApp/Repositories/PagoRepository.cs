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
            var mitnickQuery = from deta in ContaContext.DetallePagoEmpleados
                join pago in ContaContext.PagoEmpleados on deta.PagoEmpleadoId equals pago.PagoEmpleadoId
                select new
                {
                    CantidadHora = deta.CantidadHoras,
                    deta.TipoHora,
                    deta.Porcentaje,
                    Total = deta.CantidadHoras*deta.Porcentaje*pago.SalarioHora
                };

            return mitnickQuery;

        }
    }
}
