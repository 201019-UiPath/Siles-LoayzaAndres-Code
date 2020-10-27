using System.IO;
using HerosDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HerosDB
{
    public class HerosContext : DbContext
    {
        public DbSet<SuperHero> SuperHeroes {get; set;}
        public DbSet<SuperPower> SuperPowers {get; set;}
        public DbSet<SuperVillain> SuperVillains {get; set;}

        /// <summary>
        /// Tells the HerosContext where the database is
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if( !optionsBuilder.IsConfigured )
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@"C:\Users\Cito\Revature\Training\Siles-LoayzaAndres-Code\HerosApp-Demo\appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("HerosDB"); //refers to the specific string in appsettings.json
                optionsBuilder.UseNpgsql(connectionString); //connects the database
            }
        }

        /// <summary>
        /// Manually defines the relationship between SuperHero and SuperVillain
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperEnemy>()
                .HasOne(e => e.SuperHero)
                .WithMany(hero => hero.Nemesis)
                .HasForeignKey(e => e.SuperHeroId);
                
            modelBuilder.Entity<SuperEnemy>()
                .HasOne(e => e.SuperVillain)
                .WithMany(v => v.Nemesis)
                .HasForeignKey(e => e.SuperVillainId);
        }
    }
}