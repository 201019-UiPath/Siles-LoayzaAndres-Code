namespace HerosDB.Models
{
    public class SuperEnemy
    {
        public int Id { get; set; }
        public int SuperHeroId { get; set; }
        public SuperHero SuperHero { get; set; }
        public int SuperVillainId {get; set; }
        public SuperVillain SuperVillain { get; set; }
    }
}