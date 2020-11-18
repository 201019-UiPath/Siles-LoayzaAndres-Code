using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpLib
{
    public class TestDemo
    {
        public void GetFullName(String firstName, string middleName, string lastName)
        {
            if (middleName != "" || middleName != null)
            {
                Console.WriteLine($"{firstName} {middleName} {lastName}");
            }
            else
                Console.WriteLine($"{firstName} {lastName}");
        }

        public List<string> LoadFile()
        {
            List<string> output = new List<string>();
            List<string> lines = File.ReadAllLines("text.txt").ToList();
            for (int i=0; i<lines.Count-1; i++)
            {
                if (i % 2 == 0)
                {
                    output.Add(lines[i]);
                }
            }
            return output;
        }
    }
}
