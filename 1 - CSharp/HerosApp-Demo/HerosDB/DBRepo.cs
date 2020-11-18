using System.Collections.Generic;
using System.Threading.Tasks;
using HerosDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HerosDB
{
    public class DBRepo : ISuperHeroRepo
    {
        private HerosContext context;

        public DBRepo(HerosContext context)
        {
            this.context = context;
        }

        public void AddAHeroAsync(SuperHero hero)
        {
            context.SuperHeroes.AddAsync(hero);
            context.SaveChangesAsync();
        }

        public Task<List<SuperHero>> GetAllHeroesAsync()
        {
            return context.SuperHeroes.Where(x => x.Id != null).ToListAsync(); //uses Linq
                                                                               //"=>" means "such that"
        }

        public SuperHero GetHeroByName(string name)
        {
            return (SuperHero) context.SuperHeroes.Where(x => x.Alias == name);
        }
    }
}