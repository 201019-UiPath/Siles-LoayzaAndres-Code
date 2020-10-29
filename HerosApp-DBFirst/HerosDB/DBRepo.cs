using System.Collections.Generic;
using System.Threading.Tasks;
using HerosDB.Models;
using HerosDB.Entities;
namespace HerosDB
{
    public class DBRepo : ISuperHeroRepo
    {
        private readonly HeroContext context;
        private readonly IMapper mapper;

        public DBRepo(HeroContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddAHeroAsync(SuperHero hero)
        {
            context.Superpeople.AddAsync(mapper.ParseSuperHero(hero));
            context.SaveChangesAsync();
        }

        public Task<List<SuperHero>> GetAllHeroesAsync()
        {
            throw new System.NotImplementedException();
        }

        public SuperHero GetHeroByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}