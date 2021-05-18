using System;
using System.IO;

namespace II_Transcribing_DNA_Into_RNA
{
    class Program
    {
        static void Main(string[] args)
        {
            var dna = File.ReadAllText("rosalind_rna.txt");
            var rna = dna.Replace('T', 'U');

            Console.WriteLine(rna);
        }
    }
}
