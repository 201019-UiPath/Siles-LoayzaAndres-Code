using System;
using HeroesLib;

namespace HeroesUI
{
    class Program:Hero
    {
        static void Main(string[] args)
        {
            Hero obj = new Hero();
            #region default constructor
            /*Hero obj = new Hero();
            Console.WriteLine($"Hero ID: {obj.id} \nHero Name: {obj.name}");*/
            #endregion
            #region explicit constructor
            /*obj.Id = 5;
            Console.WriteLine($"Hero ID: {obj.Id} \nHero Name: {obj.name}");*/
            #endregion
            #region arrays
            /*
            Console.Write("Please enter your hero's id: ");
            obj.Id=Int32.Parse(Console.ReadLine()); //typecast string to int
            Console.Write("Please enter your Superhero name: ");
            obj.Name=Console.ReadLine();
            Console.Write("Please enter the first superpower: ");
            obj.superPowers[0] = Console.ReadLine();
            Console.Write($"ID: {obj.Id}\nName: {obj.Name}\nSuperpowers: {obj.superPowers[0]}");
            */
            #endregion

            obj.ja[0] = new int[2];
            obj.ja[1] = new int[3];
            obj.ja[2] = new int[1];
            obj.ja[0][0] =10;
            obj.ja[1][2] =15;
            int[,,] td = new int[2, 4, 3]; //3-D array
            //Console.WriteLine(obj.ja.Rank); //dimension of the array (1D, 2D, etc.) (jagged arrays are techincally 1D)
            //Console.WriteLine(obj.ja.Length);//maximum size of the array (num of elements)

            Console.WriteLine("Values in Jagged Array:");
            //loop through all rows
            foreach (var row in obj.ja)
            {
                //loop through all columns
                foreach (var val in row)
                {
                    Console.Write($"{val} ");
                }
                Console.Write("\n");
            }
        }
    }
}
