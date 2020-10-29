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
        private readonly DBMapper mapper = new DBMapper();
        private DBRepo repo;
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
                        Description = "If you dream it, he can build it"
                    }
                }
            },
            new Superpeople()
            {
                Realname = "Barnabus Saurus III",
                Workname = "Barney",
                Hideout = "Barney's house",
                Chartype = 2
            }
        };

        private void Seed(HeroContext testcontext)
        {
            testcontext.Charactertype.AddRange();
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
            using var assertContext = new HeroContext();
            Assert.NotNull(assertContext.Superpeople.Single(h => h.Workname == testHero.Alias));
            //Assert.NotNull(assertContext.Superpeople.
        }
    }
}