using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsumeHeroesApp_HttpClient.Models
{
    class SuperHero
    {
        public int id { get; set; }
        public string realName { get; set; }
        public string alias { get; set; }
        public string hideOut { get; set; }
        public List<SuperPower> superPowers { get; set; }
        //public List<string> Nemesis { get; set; }
    }
}
