using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IX_RNA_Splicing
{
    class Sample
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    class Program
    {
        private const int CODON_SIZE = 3;

        static void Main(string[] args)
        {
            var file = File.ReadAllText("rosalind_splc.txt").Split(">").Skip(1).ToArray();

            Sample dnaSample = new Sample() 
            { 
                Name = file[0].Substring(0, 13),
                Value = file[0].Substring(13).Replace("\r\n", "")
            };

            var intronsFromFile = file.Skip(1).ToArray();

            List<Sample> introns = new List<Sample>();

            for(int i = 0; i < intronsFromFile.Length; i++)
            {
                introns.Add(new Sample()
                {
                    Name = intronsFromFile[i].Substring(0, 13),
                    Value = intronsFromFile[i].Substring(13).Replace("\r\n", "")
                });
            }

            foreach(var intron in introns)
                dnaSample.Value = dnaSample.Value.Replace(intron.Value, "");

            var rna = Transcription(dnaSample.Value);
            string proteinString = "";

            for (int i = 0; i + CODON_SIZE < rna.Length; i += CODON_SIZE)
                proteinString += TranslateToAminoAcid(rna.Substring(i, CODON_SIZE));

            Console.WriteLine(proteinString);
        }

        private static string Transcription(string dna)
        {
            return dna.Replace('T', 'U');
        }

        private static char TranslateToAminoAcid(string codon)
        {
            switch (codon)
            {
                case "UUU":
                    return 'F';
                case "UUC":
                    return 'F';
                case "UUA":
                    return 'L';
                case "UUG":
                    return 'L';
                case "UCU":
                    return 'S';
                case "UCC":
                    return 'S';
                case "UCA":
                    return 'S';
                case "UCG":
                    return 'S';
                case "UAU":
                    return 'Y';
                case "UAC":
                    return 'Y';
                case "UAA":
                    return '\0';
                case "UAG":
                    return '\0';
                case "UGU":
                    return 'C';
                case "UGC":
                    return 'C';
                case "UGA":
                    return '\0';
                case "UGG":
                    return 'W';
                case "CUU":
                    return 'L';
                case "CUC":
                    return 'L';
                case "CUA":
                    return 'L';
                case "CUG":
                    return 'L';
                case "CCU":
                    return 'P';
                case "CCC":
                    return 'P';
                case "CCA":
                    return 'P';
                case "CCG":
                    return 'P';
                case "CAU":
                    return 'H';
                case "CAC":
                    return 'H';
                case "CAA":
                    return 'Q';
                case "CAG":
                    return 'Q';
                case "CGU":
                    return 'R';
                case "CGC":
                    return 'R';
                case "CGA":
                    return 'R';
                case "CGG":
                    return 'R';
                case "AUU":
                    return 'I';
                case "AUC":
                    return 'I';
                case "AUA":
                    return 'I';
                case "AUG":
                    return 'M';
                case "ACU":
                    return 'T';
                case "ACC":
                    return 'T';
                case "ACA":
                    return 'T';
                case "ACG":
                    return 'T';
                case "AAU":
                    return 'N';
                case "AAC":
                    return 'N';
                case "AAA":
                    return 'K';
                case "AAG":
                    return 'K';
                case "AGU":
                    return 'S';
                case "AGC":
                    return 'S';
                case "AGA":
                    return 'R';
                case "AGG":
                    return 'R';
                case "GUU":
                    return 'V';
                case "GUC":
                    return 'V';
                case "GUA":
                    return 'V';
                case "GUG":
                    return 'V';
                case "GCU":
                    return 'A';
                case "GCC":
                    return 'A';
                case "GCA":
                    return 'A';
                case "GCG":
                    return 'A';
                case "GAU":
                    return 'D';
                case "GAC":
                    return 'D';
                case "GAA":
                    return 'E';
                case "GAG":
                    return 'E';
                case "GGU":
                    return 'G';
                case "GGC":
                    return 'G';
                case "GGA":
                    return 'G';
                case "GGG":
                    return 'G';
                default:
                    throw new Exception("Invalid codon");
            }
        }
    }
}
