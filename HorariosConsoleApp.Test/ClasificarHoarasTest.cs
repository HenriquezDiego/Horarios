using System;
using  Xunit;
using  HorariosConsoleApp.Helpers;

namespace HorariosConsoleApp.Test
{
    public class ClasificarHoarasTest
    {
        [Fact]
        public void DeberiaSerHorarioNoctura()
        {
            var inicio = new TimeSpan(18, 0, 0);
            var fin = new TimeSpan(22, 0, 0);
            var flag = Workday.IsNightly(inicio, fin);
            Assert.True(flag);
        }

        [Fact]
        public void DeberiaSerHorarioDiurno()
        {
            var inicio = new TimeSpan(2, 0, 0);
            var fin = new TimeSpan(21, 0, 0);
            var flag = Workday.IsNightly(inicio, fin);
            Assert.False(flag);
        }

        [Fact]
        public void DeberiaSerHorarioNocturnoRangoTranversal()
        {
            var inicio = new TimeSpan(22,0,0);
            var fin = new TimeSpan(6,0,0);
            var flag = Workday.IsNightly(inicio, fin);
            Assert.True(flag);
        }
    }
}
