using System.Collections.Generic;
using System.Threading.Tasks;
using HerosDB.Models;
using HerosDB.Entities;
<<<<<<< HEAD
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HerosDB
{
    public class DBRepo : ISuperHeroRepo, IVillainRepo
=======
namespace HerosDB
{
    public class DBRepo : ISuperHeroRepo
>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
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

<<<<<<< HEAD
        public void AddAVillain(SuperVillain superVillain)
        {
            context.Superpeople.Add(mapper.ParseSuperVillain(superVillain));
            context.SaveChanges();
        }

        public Task<List<SuperHero>> GetAllHeroesAsync()
        {
           return Task.Run<List<SuperHero>>(
               () => mapper.ParseSuperHero(
                   context.Superpeople
                   .Include("Powers")
                   .Where(x => x.Chartype == context.Charactertype.Single(c => c.Chartype == "Superhero").Id)
                   .ToList()
               ));
        }

        public List<SuperVillain> GetAllVillains()
        {
            return mapper.ParseSuperVillain(
                    context.Superpeople
                    .Where(x => x.Chartype == context.Charactertype.Single(y => y.Chartype == "Supervillain").Id)
                    .Include("Powers")
                    .ToList());
=======
        public Task<List<SuperHero>> GetAllHeroesAsync()
        {
            throw new System.NotImplementedException();
>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
        }

        public SuperHero GetHeroByName(string name)
        {
<<<<<<< HEAD
            return mapper.ParseSuperHero(context.Superpeople.Include("Powers").First(x => x.Workname == name));
        }

        public SuperVillain GetVillainByName(string name)
        {
            return mapper.ParseSuperVillain(context.Superpeople.Include("Powers").SingleOrDefault(x => x.Workname == name));
=======
            throw new System.NotImplementedException();
>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
        }
    }
}