using System;

namespace HeroesLib
{
    #region old way of creating class members
    /*public class Hero
    {
        private int id;
        public int Id{
            get{
                return id;
            }
            set{
                id=value;
            }
        }
        public string name;

        //default constructor
        public Hero() {
            this.id=1;
            this.name="Bombasto";
        }

        //explicit constructor
        public Hero(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int getId() {
            return this.id;
        }
    }*/
    #endregion

    #region modern way of creating class members
    public class Hero {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] superPowers = new string[10];

        public int[][] ja = new int[3][];
    }
    #endregion
}

