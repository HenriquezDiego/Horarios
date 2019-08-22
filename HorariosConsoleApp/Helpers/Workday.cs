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
        public static bool CheckSection(TimeSpan start , TimeSpan end)
        {
            var hoursD = 0;
            var hoursN = 0;

            for (var i = start.Hours; i < end.Hours; i++)
            {
                if (i > 18 && i < 23 || i > 0 && i < 6)
                {
                    hoursN++;
                }
                else
                {
                    hoursD++;
                }
            }

            return hoursN>hoursD;
        }
    }
}
