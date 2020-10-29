using Xunit;
using HerosDB.Entities;
using HerosDB.Models;
using HerosDB;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HerosTest.HerosDBTest
{
    public class DBRepoTest
    {
<<<<<<< HEAD
        private readonly IMapper mapper = new DBMapper();
        private DBRepo repo;
        //Test data
=======
        private readonly DBMapper mapper = new DBMapper();
        private DBRepo repo;
>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
        private readonly SuperHero testHero = new SuperHero()
        {
            RealName = "Diana",
            Alias = "Wonder Woman",
            HideOut = "Themyscira",
            SuperPowers = new List<SuperPower>()
            {
                new SuperPower()
                {
                    Name = "Flight",
                    Description = "She can glide through the air on currents in the wind"
                },
                new SuperPower()
                {
                    Name = "Super Abilities",
                    Description = "Superhuman strength, agility, and reflexes"
                }
            }
        };
<<<<<<< HEAD
=======

>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
        private readonly List<Superpeople> testPeople = new List<Superpeople>()
        {
            new Superpeople()
            {
                Realname = "Bob",
                Workname = "Bob the builder",
                Hideout = "The building garage",
                Chartype = 1,
                Powers = new List<Powers>()
                {
                    new Powers()
                    {
                        Name = "Builder Memory",
                        Description = "Never loses his tools, always remembers where they are"
                    },
                    new Powers()
                    {
                        Name = "Super Builder",
<<<<<<< HEAD
                        Description = "If you dream it he can build it"
=======
                        Description = "If you dream it, he can build it"
>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
                    }
                }
            },
            new Superpeople()
            {
                Realname = "Barnabus Saurus III",
                Workname = "Barney",
<<<<<<< HEAD
                Hideout = "This house",
                Chartype = 2
            }
        };
        private readonly List<Charactertype> charactertypes = new List<Charactertype>()
        {
            new Charactertype() { Chartype = "Superhero"},
            new Charactertype() { Chartype = "Supervillain"}
        };
        private void Seed(HeroContext testcontext)
        {
            testcontext.Charactertype.AddRange(charactertypes);
=======
                Hideout = "Barney's house",
                Chartype = 2
            }
        };

        private void Seed(HeroContext testcontext)
        {
            testcontext.Charactertype.AddRange();
>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
            testcontext.Superpeople.AddRange(testPeople);
            testcontext.SaveChanges();
        }

        [Fact]
        public void AddHeroShouldAdd()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("AddHeroesShouldAdd").Options;
            using var testContext = new HeroContext(options);
            repo = new DBRepo(testContext, mapper);

            //Act
            repo.AddAHeroAsync(testHero);

            //Assert
<<<<<<< HEAD
            using var assertContext = new HeroContext(options);
            Assert.NotNull(assertContext.Superpeople.Single(h => h.Workname == testHero.Alias));

        }

        [Fact]
        public async void GetHeroesShouldGet()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("GetHeroesShouldGet").Options;
            using var testContext = new HeroContext(options);
            Seed(testContext);

            //Act
            using var assertContext = new HeroContext(options);
            repo = new DBRepo(assertContext, mapper);
            var result = await repo.GetAllHeroesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void GetHeroByNameShouldGetHeroByName()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("GetHeroByNameShouldGetHeroByName").Options;
            using var testContext = new HeroContext(options);
            Seed(testContext);

            //Act 
            using var assertContext = new HeroContext(options);
            repo = new DBRepo(assertContext, mapper);
            var result = repo.GetHeroByName("Bob the builder");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Bob", result.RealName);
=======
            using var assertContext = new HeroContext();
            Assert.NotNull(assertContext.Superpeople.Single(h => h.Workname == testHero.Alias));
            //Assert.NotNull(assertContext.Superpeople.
>>>>>>> d53fbc2392e1a1b2a4e71eb3710a8c6107c1011c
        }
    }
}