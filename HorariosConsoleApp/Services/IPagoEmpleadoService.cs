using System;
using System.Collections.Generic;

namespace HorariosConsoleApp.Services
{
    public interface IPagoEmpleadoService
    {
        void Calcular(DateTime fechaInicio, DateTime fechaFin);
    }
}
