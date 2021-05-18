using System;
using System.IO;
using System.Linq;

namespace ROSALIND_I
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = File.ReadAllText("rosalind_dna.txt");

            var countA = sequence.Where(c => c == 'A').Count();
            var countC = sequence.Where(c => c == 'C').Count();
            var countG = sequence.Where(c => c == 'G').Count();
            var countT = sequence.Where(c => c == 'T').Count();

            Console.WriteLine($"{countA} {countC} {countG} {countT}");
        }
    }
}
