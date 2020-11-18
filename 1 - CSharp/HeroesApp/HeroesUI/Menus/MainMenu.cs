using System;
using HeroesLib;
using HeroesBL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HeroesUI
{
    /// <summary>
    /// The welcome menu for when the program starts
    /// </summary>
    public class MainMenu : IMenu
    {
        public void Start() {
            string userInput;
            do {
                Console.WriteLine("Welcome! What would you like to do today?");

                //Options
                Console.WriteLine("[0] Create a hero\n[1] Get all heroes");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0": 
                        Hero newHero = GetHeroDetails();
                        HeroBL.AddHero(newHero);
                        Console.WriteLine($"Hero {newHero.Name} was created with a superpower of {newHero.superPowers.Peek()}");
                        break;
                    case "1":
                        List<Hero> allHeroes = HeroBL.GetAllHeroes();
                        foreach(var hero in allHeroes) {
                            Console.WriteLine($"Hero {hero.Name}");
                        }
                        break;
                }
            } while (!userInput.Equals("0") && !userInput.Equals("1"));
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