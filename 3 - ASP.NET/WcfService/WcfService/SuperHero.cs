using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfService
{
    [DataContract]
    public class SuperHero
    {
        public int Id { get; set; }
        [DataMember]
        public string RealName { get; set; }
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public string HideOut { get; set; }

        public IEnumerable<SuperHero> AllHeros()
        {
            List<SuperHero> superHeroes = new List<SuperHero>()
            {
                new SuperHero(){Id=1, RealName="Peter Parker", Alias="Spiderman", HideOut="Basement"},
                new SuperHero(){Id=2, RealName="Thor", Alias="Thor", HideOut="Asgard"},
            };
            return superHeroes;
        }
    }
}