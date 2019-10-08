namespace HorariosConsoleApp.Services
{
    public interface IFactory
    {
        Tipo Builder(int type);
    }
}
