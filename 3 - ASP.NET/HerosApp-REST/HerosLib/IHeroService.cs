using System.Collections.Generic;
using HerosDB.Models;

namespace HerosLib
{
    public interface IHeroService
    {
        void AddHero(SuperHero newHero);
        List<SuperHero> GetAllHeroes();
        SuperHero GetHeroByName(string name);
    }
}