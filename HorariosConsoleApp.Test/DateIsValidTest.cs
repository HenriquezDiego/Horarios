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
    }
}
