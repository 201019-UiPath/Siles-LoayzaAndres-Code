using System.Collections.Generic;
using HeroesLib;
using System.IO;
using System.Text.Json; //this package has to be downloaded from NuGet for this project
using System.Threading.Tasks;

namespace HeroesDB
{
    /// <summary>
    /// Repository using files
    /// </summary>
    public class FileRepo : IRepository
    {
        const string filepath = "HeroesDB/HeroesDataPlace/Heroes.txt";

        /// <summary>
        /// Adds hero to file
        /// </summary>
        /// <param name="hero"></param>
        public async void OverwriteHero(Hero hero)
        {
            using(FileStream fs = File.Create(filepath))
            {
                await JsonSerializer.SerializeAsync(fs, hero);
                System.Console.WriteLine("Hero is being written to file");
            }
        }


        public async void AddHero(Hero hero)
        {
            using(FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write))
            {
                await JsonSerializer.SerializeAsync(fs, hero); //THIS DOES NOT WORK; TRY SERIALIZING THE LIST OF HEROES INSTEAD
                System.Console.WriteLine("Hero is being written to file");
            }
        }

        /// <summary>
        /// Gets all heroes from file
        /// </summary>
        /// <returns></returns>
        public async Task<List<Hero>> GetAllHeroes()
        {
            List<Hero> allHeroes = new List<Hero>();
            using (FileStream fs = File.OpenRead(filepath))
            {
                allHeroes.Add(await JsonSerializer.DeserializeAsync<Hero>(fs));
            }

            return allHeroes;
        }
    }
}