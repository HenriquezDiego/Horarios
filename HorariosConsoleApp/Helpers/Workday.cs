namespace HorariosConsoleApp.Helpers
{
    public static class Workday
    {
        public const int HoraNocturna = 19;
        public static int CheckHour(int hour, string day,bool extra=false)
        {

            if (hour > 5 && hour < HoraNocturna)
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

            if (hour >= HoraNocturna || hour >= 0)
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
    }
}
