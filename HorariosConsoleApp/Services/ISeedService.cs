using System.Collections.Generic;

namespace HorariosConsoleApp.Services
{
    public interface ISeedService
    {
        IEnumerable<string> Generar();
    }
}
