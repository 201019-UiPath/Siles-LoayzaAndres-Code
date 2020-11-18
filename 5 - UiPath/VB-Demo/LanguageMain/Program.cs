using System;

namespace LanguageMain
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharpLib.TestDemo testcsharp = new CSharpLib.TestDemo();
            testcsharp.GetFullName("Andres", "", "Siles");
            var resultsCsharp = testcsharp.LoadFile();
            foreach (var item in resultsCsharp)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*************************");
            VbLib.TestDemo testvb = new VbLib.TestDemo(); //makes a reference to a VB class in C# code
            testvb.GetFullName("Andres", "S", "Siles"); //language interactivity in .Net
            var resultsVb = testvb.LoadFile();
            foreach(var item in resultsVb)
            {
                Console.WriteLine(item);
            }
        }
    }
}
