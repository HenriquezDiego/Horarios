namespace HorariosConsoleApp.Helpers
{
    public static class Workday
    {
        public static int CheckHour(int hour, string day)
        {
            
            if (hour > 5 && hour < 22 && day.Equals("S"))
            {
                return (int) HoraTipo.Hds;
            }

            if (hour == 22 || hour == 23 || (hour >= 0 && hour < 6) && day.Equals("S"))
            {
                return (int)HoraTipo.Hns;
            }

            if (hour > 5 && hour < 22 && day.Equals("D"))
            {
                return (int) HoraTipo.Hdd;
            }

            if (hour == 22 || hour == 23 || (hour >= 0 && hour < 6) && day.Equals("D"))
            {
                return (int)HoraTipo.Hnd;
            }

            if (hour > 5 && hour < 22 && !day.Equals("S") && !day.Equals("D"))
            {
                return (int)HoraTipo.Hod;
            }

            if (hour == 22 || hour == 23 || (hour >= 0 && hour < 6) && !day.Equals("S") && !day.Equals("D"))
            {
                return (int)HoraTipo.Hon;
            }

            return 1;
        }
    }
}
