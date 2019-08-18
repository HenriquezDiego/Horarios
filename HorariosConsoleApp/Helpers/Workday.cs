namespace HorariosConsoleApp.Helpers
{
    public static class Workday
    {
        public const int HoraNocturna = 19;
        public static int CheckHour(int hour, string day)
        {
            
            if (hour > 5 && hour < HoraNocturna && day.Equals("S"))
            {
                return (int) HoraTipo.Hds;
            }

            if (hour >= HoraNocturna || (hour >= 0 && hour < 6) && day.Equals("S"))
            {
                return (int)HoraTipo.Hns;
            }

            if (hour > 5 && hour < HoraNocturna && day.Equals("D"))
            {
                return (int) HoraTipo.Hdd;
            }

            if (hour >= HoraNocturna || (hour >= 0 && hour < 6) && day.Equals("D"))
            {
                return (int)HoraTipo.Hnd;
            }

            if (hour > 5 && hour < HoraNocturna && !day.Equals("S") && !day.Equals("D"))
            {
                return (int)HoraTipo.Hod;
            }

            if (hour >= HoraNocturna || (hour >= 0 && hour < 5) && !day.Equals("S") && !day.Equals("D"))
            {
                return (int)HoraTipo.Hon;
            }

            return 1;
        }
    }
}
