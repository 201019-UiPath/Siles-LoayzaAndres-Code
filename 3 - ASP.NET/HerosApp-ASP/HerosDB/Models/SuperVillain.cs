using System.Collections.Generic;
namespace HerosDB.Models
{
    public class SuperVillain:SuperPerson
    {
        public List<SuperEnemy> Nemesis { get; set; }
    }
}