using System;
using HerosDB;
using HerosDB.Entities;
namespace HeroUI
{
    public class MainMenu : IMenu
    {
        private string userInput;
        private HeroMenu heroMenu;        
        private VillainMenu villainMenu;
        public MainMenu(HeroContext context, IMapper mapper)
        {
            this.heroMenu = new HeroMenu(new DBRepo(context, mapper), new MessagingService());
            this.villainMenu = new VillainMenu(new DBRepo(context, mapper), new MessagingService());
        }
        public void start()
        {
            do{
                Console.WriteLine("Welcome Friend! Are you a hero or a villain?");
                Console.WriteLine("[0] Hero?");
                Console.WriteLine("[1] Villain?");
                Console.WriteLine("[2] Exit?");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        //call the hero menu;
                        heroMenu.start();
                        break;
                    case "1":
                        //call the villain menu;
                        villainMenu.start();
                        break;
                    case "2":
                        Console.WriteLine("Goodbye Friend");
                        break;
                    default:
                    //call the invalid message
                    break;
                }

            }while(!(userInput.Equals("2")));
        }
    }
}