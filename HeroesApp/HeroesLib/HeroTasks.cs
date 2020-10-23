using System.Threading.Tasks;

namespace HeroesLib
{
    public delegate void HeroDel();

    public class HeroTasks : Hero, IHeroOperations, IHeroSuperPowers
    {
        string filepath = @"C:\Users\Cito\Revature\Training\Siles-LoayzaAndres-Code\HeroesApp\SuperPowers.txt";

        public async void DoWork() //"async" allows this method to execute asynchronously
        {
            System.Console.WriteLine("Work started...");
            await Task.Run(new System.Action(GetPowers)); //runs this method on a new thread
            System.Console.WriteLine("Saving humanity is my work");
            System.Console.WriteLine("Work finished");
        }

        public void GetPowers()
        {
            System.Console.WriteLine("Getting powers");
            System.Threading.Thread.Sleep(6000); //pauses this process
            string superPowers = System.IO.File.ReadAllText(filepath);
            System.Console.WriteLine($"Power obtained: {superPowers}");
        }

        public void ManageLife()
        {
            System.Console.WriteLine("I have a cranky partner to manage");
        }
    }
}