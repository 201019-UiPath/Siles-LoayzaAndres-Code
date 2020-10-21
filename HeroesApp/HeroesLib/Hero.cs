using System;
using System.Collections.Generic;

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
        #region arrays
        /*
        public string[] superPowers = new string[10]; //1-D array
        public int[][] ja = new int[3][]; //jaggged array
        */
        #endregion

        //public static List<string> superPowers = new List<string>();
        public static Stack<string> superPowers = new Stack<string>(); //LIFO
        public static Dictionary<string, string> hideOuts = new Dictionary<string, string>();

        public Hero()
        {
            superPowers.Push("Strength");
            superPowers.Push("Fly");
            superPowers.Push("Invisibility");
            superPowers.Push("X-Ray Vision");
            hideOuts.Add("Thor", "Asgard");
            hideOuts.Add("Batman", "Batcave");
            hideOuts.Add("Superman", "Fortress of Solitude");
        }

        //method
        //NOTE: methods in C# are always PascalCase by convention
        public static Stack<string> GetSuperPowers() {
            return superPowers;
        }

        public void AddSuperPower(string superPower) {
            if(superPower != null && superPower != "") {
                superPowers.Push(superPower);
            }
        }

        public void RemoveSuperPower(/*string superPower*/) {
            /*
            if (superPowers.Contains(superPower)) {
                superPowers.Remove(superPower);
            }*/
            superPowers.Pop();
        }
    }
    #endregion
}

