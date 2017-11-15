using System;
using System.Linq;

namespace Adamrmoss.PrimeFactorization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = args.First();

            var integerLoader = new IntegerLoader();
            var integersToFactorize = integerLoader.GetIntegersFromFile(filePath);

            var integerFactorizer = new IntegerFactorizer();
            foreach (var integerToFactorize in integersToFactorize)
            {
                var factors = integerFactorizer.GetPrimeFactors(integerToFactorize);
                Console.WriteLine(string.Join(',', factors));
            }
        }
    }
}
