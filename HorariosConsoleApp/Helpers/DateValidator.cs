using System;
namespace HorariosConsoleApp.Helpers
{
    public static class DateValidator
    {
        public static bool DateRangeIsValid(DateTime inicio, DateTime fin)
        {
            return inicio < fin;
        }
    }
}
