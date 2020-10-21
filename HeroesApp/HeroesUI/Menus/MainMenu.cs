using System;
using HeroesLib;
using System.Text.RegularExpressions;

namespace HeroesUI
{
    /// <summary>
    /// The welcome menu for when the program starts
    /// </summary>
    public class MainMenu : IMenu
    {

        public void Start() {
            do {
                Console.WriteLine("Welcome! What would you like to do today?");

                //Options
                Console.WriteLine("[0] Create a hero");
            } while (!Console.ReadLine().Equals("0"));
            Hero newHero = GetHeroDetails();
            Console.WriteLine($"Hero {newHero.Name} was created with a superpower of {newHero.superPowers.Peek()}");
        }

        public Hero GetHeroDetails()
        {
            Hero hero = new Hero();
            do {
                Console.WriteLine("Enter hero name: ");
                hero.Name = Console.ReadLine();
            } while (Regex.IsMatch(hero.Name, "[\\d]")); //rejects strings with digits

            Console.WriteLine("Enter hero superpower: ");
            hero.AddSuperPower(Console.ReadLine());
            Console.WriteLine("Hero created!");
            return hero;
        }

    }
}