using System;
using HorariosConsoleApp.Helpers;
using Xunit;

namespace HorariosConsoleApp.Test
{
    public class DateIsValidTest
    {
        [Fact]
        public void RangoFechaDeberiaSerCorrecto()
        {
            var flag = DateValidator.DateRangeIsValid(new DateTime(2019, 8, 1),
                new DateTime(2019,8, 31));
            Assert.True(flag);
        }

        [Fact]
        public void InformacionDiasAgostoCorrecto()
        {
            var infoDate = Workday.DateInfo(new DateTime(2019, 8, 1)); 
            Assert.Equal(31,infoDate.Days);
        }

        [Fact]
        public void InformacionDomingosAgostoSobreCarga()
        {
            var infoDate = Workday.DateInfo(2019,8); 
            Assert.Equal(4,infoDate.Sundays);
        }

        
    }
}
