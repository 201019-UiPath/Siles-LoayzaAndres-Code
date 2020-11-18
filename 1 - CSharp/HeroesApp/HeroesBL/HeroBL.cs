using HeroesLib;
using HeroesDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroesBL
{
    public static class HeroBL
    {
        static IRepository repo = new FileRepo(); //example of covariance

        public static void AddHero(Hero newHero) 
        {
            //You can add the business logic to check stuff
            repo.AddHero(newHero);
        }

        public static List<Hero> GetAllHeroes()
        {
            Task<List<Hero>> getHeroes = repo.GetAllHeroes();
            return getHeroes.Result;
        }
    }
}