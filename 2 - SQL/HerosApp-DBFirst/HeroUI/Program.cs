using HerosDB;
using HerosDB.Entities;
namespace HeroUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu main = new MainMenu(new HeroContext(), new DBMapper());
            main.start();
        }

    }
}
