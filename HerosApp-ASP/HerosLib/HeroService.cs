using HerosDB.Models;
using HerosDB;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HerosLib
{
    public class HeroService
    {
        private ISuperHeroRepo repo;

        public HeroService(ISuperHeroRepo repo)
        {
            this.repo = repo;
        }
        public void AddHero(SuperHero newHero)
        {
            //Add some business logic here
            repo.AddAHeroAsync(newHero);
        }
        public List<SuperHero> GetAllHeroes()
        {
            Task<List<SuperHero>> getHerosTask = repo.GetAllHeroesAsync();
            return getHerosTask.Result;
        }
        public SuperHero GetHeroByName()
        {
            throw new NotImplementedException();
        }
    }
}