using System;

namespace HorariosConsoleApp.Helpers
{
    public static class Workday
    {
        /// <summary>
        /// Inicio de horas nocturnas
        /// </summary>
        public const int IhN = 19;
        /// <summary>
        /// Fin de horas nocturnas
        /// </summary>
        public const int FhN = 5;
        /// <summary>
        /// Horas "efectivas" nocturnas
        /// </summary>
        public const int HeN = 7;
        /// <summary>
        ///  Horas "efectivas" diurnas
        /// </summary>
        public const int HeD = 8;
        public static int CheckHour(int hour, string day,bool extra=false)
        {

            if (hour > FhN && hour < IhN)
            {
                switch (day)
                {
                    case "S":
                        return !extra?(int) HoraTipo.Hds:(int) HoraTipo.Hed;

                    case "D":
                        return !extra?(int) HoraTipo.Hdd:(int)HoraTipo.Hedd;
                    default:
                        return !extra?(int)HoraTipo.Hod:(int)HoraTipo.Hed;
                       
                }
            }

            if (hour >= IhN || hour >= 0)
            {
                switch (day)
                {
                    case "S":
                        return !extra?(int)HoraTipo.Hns:(int) HoraTipo.Hen;

                    case "D":
                        return  !extra?(int)HoraTipo.Hnd:(int)HoraTipo.Hend;
                    default:
                        return !extra?(int)HoraTipo.Hon:(int)HoraTipo.Hen;
                       
                }

            }

            return 1;
        }

        //Validad si la sección o fragmento tiene en su mayoría horas nocturnas, de serlo devuelve true
        /// <summary>
        /// Verifica si una lapso de tiempo contiene mas horas nocturnas que diurnas
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static bool IsNightly(TimeSpan start, TimeSpan end)
        {
            var hoursD = 0;
            var hoursN = 0;
            var hours = Math.Abs(end.Hours - start.Hours);
            var flag = 0;
            var startHours = start.Hours;

            while (flag<hours)
            {
                if (startHours == 24)
                {
                    startHours = 0;
                    hours = end.Hours;
                }

                if (startHours > 18 && startHours <= 23 
                    || startHours >= 0 && startHours < 6)
                {
                    hoursN++;
                }
                else
                {
                    hoursD++;
                }

                startHours++;
                flag++;
            }

            return hoursN>hoursD;
        }

        public static object DateInfo(DateTime date)
        {
            var month = date.Month;
            var year = date.Year;
            var days = DateTime.DaysInMonth(year, month);
            var saturdays = 0;
            var sundays = 0;
            var week = 0;
            for (var i = 0; i < 31; i++)
            {
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        saturdays++;
                        break;
                    case DayOfWeek.Sunday:
                        sundays++;
                        break;
                    default:
                        week++;
                        break;

                }

                date=date.AddDays(1);
            }


            return new
            {
                month,
                days,
                saturdays,
                sundays,
                week
            };
        }
    }
}
