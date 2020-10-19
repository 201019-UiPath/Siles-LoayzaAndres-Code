//This is a C# file

using System; //predefined namespace

namespace helloWorld //custom-defined namespace
{
    class Program
    {

        //main method... execution starts here
        static void Main(string[] args) //command line arguments
        {
            Console.WriteLine("Hello World! "+DateTime.Now); //output to console syntax
            //"Console" is a class that belongs to the namespace "System"
            //"DateTime" is also a class in "System"
            string name;
            Console.WriteLine("Please enter your name");
            name = Console.ReadLine(); //takes user input in string form and returns it
            //Console.WriteLine("Welcome "+name); //string concatenation -> not ideal
            Console.WriteLine($"welcome {name}"); //string interpolation -> allocates variable into output string
        }
    }
}
