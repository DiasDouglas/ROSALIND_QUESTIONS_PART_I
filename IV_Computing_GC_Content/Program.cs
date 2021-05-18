using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace IV_Computing_GC_Content
{
    class Sample
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dataset = File.ReadAllText("rosalind_gc.txt");
            var samples = dataset
                .Replace("\r\n", "")
                .Split('>')
                .Where(s => s.Length > 0)
                .Select(sample =>
                    new Sample()
                    {
                        Name = sample.Substring(0, 13),
                        Value = sample.Substring(13)
                    }
                );

            var sampleResult = samples.OrderByDescending(s => s.Value.Count(symbol => symbol == 'C' || symbol == 'G')).FirstOrDefault();

            var ratio = 100 * (((float) sampleResult.Value.Count(v => v == 'C' || v == 'G')) / sampleResult.Value.Length);
            var ratioString = ratio.ToString(CultureInfo.InvariantCulture).Replace(',', '.');

            Console.WriteLine($"{sampleResult.Name}\n{ratioString}");
        }
    }
}
