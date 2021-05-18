using System;
using System.IO;
using System.Linq;

namespace III_Complementing_a_Strand_of_DNA
{
    class Program
    {
        static void Main(string[] args)
        {
            string dna = File.ReadAllText("rosalind_revc.txt");

            var reversedDNAArray = dna.Reverse().ToArray();

            for(int i = 0; i < reversedDNAArray.Length; i++)
            {
                switch (reversedDNAArray[i])
                {
                    case 'A':
                        reversedDNAArray[i] = 'T';
                        break;
                    case 'T':
                        reversedDNAArray[i] = 'A';
                        break;
                    case 'C':
                        reversedDNAArray[i] = 'G';
                        break;
                    case 'G':
                        reversedDNAArray[i] = 'C';
                        break;
                    default:
                        break;
                }
            }

            var reverseComplement = new string(reversedDNAArray);

            Console.WriteLine(reverseComplement);
        }
    }
}
