namespace HorariosConsoleApp.Services
{
    public class Factory : IFactory
    {
        public Tipo Builder(int type)
        {
            switch (type)
            {
                case 0 :
                    return new Algo();
                case 1 :
                    return new Otro();
                default:
                    return null;
            }
        }
    }
}
