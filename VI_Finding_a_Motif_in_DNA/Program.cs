using System;
using System.IO;

namespace VI_Finding_a_Motif_in_DNA
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataset = File.ReadAllText("rosalind_subs.txt");

            var parameters = dataset.Replace("\r", "").Split('\n');

            var dnaString = parameters[0];
            var dnaSubstring = parameters[1];
            var substringSize = dnaSubstring.Length;
            string positions = "";

            for(int i = 0; i + substringSize < dnaString.Length; i++)
            {
                if(dnaString.Substring(i, substringSize) == dnaSubstring)
                {
                    if (positions.Length != 0)
                        positions += $" {i + 1}";
                    else
                        positions = $"{i + 1}";
                }
            }

            Console.WriteLine(positions);
        }
    }
}
