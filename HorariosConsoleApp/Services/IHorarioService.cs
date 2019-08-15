using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorariosConsoleApp.Services
{
    public interface IHorarioService
    {
        IEnumerable<string> Seed();
    }
}
