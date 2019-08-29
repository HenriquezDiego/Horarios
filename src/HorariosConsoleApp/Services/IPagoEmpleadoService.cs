using System;

namespace HorariosConsoleApp.Services
{
    public interface IPagoEmpleadoService
    {
        void Calcular(DateTime fechaInicio, DateTime fechaFin);
        //Solo se tomara el mes
        void Calcular(DateTime fecha);
    }
}
