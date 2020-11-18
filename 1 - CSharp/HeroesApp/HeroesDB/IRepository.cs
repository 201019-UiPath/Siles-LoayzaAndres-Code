using System.Collections.Generic;
using HeroesLib;
using System.Threading.Tasks;

namespace HeroesDB
{
    /// <summary>
    /// Data access interface for Heroes
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adds hero to data storage place
        /// </summary>
        /// <param name="hero"></param>
         void AddHero(Hero hero);

         /// <summary>
         /// Gets all heroes from data storage place
         /// </summary>
         /// <returns></returns>
         Task<List<Hero>> GetAllHeroes();

    }
}