using System.Collections.Generic;
namespace HerosDB.Models
{
    /// <summary>
    /// Hero Class
    /// </summary>
    public class SuperHero:SuperPerson
    {
        public List<SuperEnemy> Nemesis { get; set; }
    }
}