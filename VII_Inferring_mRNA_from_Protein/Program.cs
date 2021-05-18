using System;
using System.IO;

namespace VII_Inferring_mRNA_from_Protein
{
    class Program
    {
        public const long ONE_MILLION = 1000000;

        static void Main(string[] args)
        {
            var dataset = File.ReadAllText("rosalind_mrna.txt");
            dataset = dataset.Replace("\r", "").Replace("\n", "");

            long possibleRNAStringCount = CodonPossibilitiesByProteinTranslated('\0');


            foreach (var symbol in dataset)
            {
                var possibleRNACountForSymbol = CodonPossibilitiesByProteinTranslated(symbol);
                possibleRNAStringCount *= possibleRNACountForSymbol;
                possibleRNAStringCount = possibleRNAStringCount % ONE_MILLION;
            }

            Console.WriteLine(possibleRNAStringCount);
        }

        private static long CodonPossibilitiesByProteinTranslated(char protein)
        {
            switch (protein)
            {
                case 'F':
                    return 2;
                case 'L':
                    return 6;
                case 'S':
                    return 6;
                case 'Y':
                    return 2;
                case '\0':
                    return 3;
                case 'C':
                    return 2;
                case 'W':
                    return 1;
                case 'P':
                    return 4;
                case 'H':
                    return 2;
                case 'Q':
                    return 2;
                case 'R':
                    return 6;
                case 'I':
                    return 3;
                case 'M':
                    return 1;
                case 'T':
                    return 4;
                case 'N':
                    return 2;
                case 'K':
                    return 2;
                case 'V':
                    return 4;
                case 'A':
                    return 4;
                case 'D':
                    return 2;
                case 'E':
                    return 2;
                case 'G':
                    return 4;
                default:
                    throw new Exception("Invalid Protein Code");
            }
        }
    }
}
