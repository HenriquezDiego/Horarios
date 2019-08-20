using System;
using System.Collections.Generic;
using ContaWebApi.DataAccess.Core.IRepositories;
using HorariosConsoleApp.Entities;

namespace HorariosConsoleApp.Repositories
{
    public interface IPagoRepository : IRepository<PagoEmpleado>
    {
        IEnumerable<object> GetCalculoPago(DateTime fechaInicio, DateTime fechaFin);

    }
}
