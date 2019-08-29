using System.Collections.Generic;

namespace HorariosConsoleApp.Services
{
    public interface IHorarioService
    {
        IEnumerable<string> Seed();
    }
}
