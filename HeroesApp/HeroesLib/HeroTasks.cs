namespace HeroesLib
{
    public delegate void HeroDel();

    public class HeroTasks : Hero, IHeroOperations, IHeroSuperPowers
    {
        string filepath = "SuperPowers.txt";

        public void DoWork()
        {
            System.Console.WriteLine("Saving humanity is my work");
        }

        public void GetPowers()
        {
            string superPowers = System.IO.File.ReadAllText(filepath);
            System.Console.WriteLine(superPowers);
        }

        public void ManageLife()
        {
            System.Console.WriteLine("I have a cranky partner to manage");
        }
    }
}