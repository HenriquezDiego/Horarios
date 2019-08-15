using System;
using System.Collections.Generic;

namespace HorariosConsoleApp.Services
{
    public interface IPagoEmpleadoService
    {
        IEnumerable<string> Calcular(DateTime fechaInicio, DateTime fechaFin);
    }
}
