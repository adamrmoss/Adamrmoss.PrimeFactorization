using System;
using System.Collections.Generic;
using System.Linq;

namespace Adamrmoss.PrimeFactorization
{
    public class IntegerFactorizer
    {
        public IntegerFactorizer()
        {
            this.knownPrimes = new List<int>();
        }

        private readonly List<int> knownPrimes;

        public IReadOnlyList<int> GetPrimeFactors(int intToFactorize)
        {
            var factors = new List<int>();
            var unfactored = intToFactorize;

            if (unfactored < 0)
            {
                factors.Add(-1);
                unfactored *= -1;
            }

            var max = (int) Math.Sqrt(unfactored);
            this.extendKnownPrimes(max);

            while (unfactored > 1)
            {
                var factor = this.knownPrimes.FirstOrDefault(prime => isDivisibleBy(unfactored, prime));
                if (factor == default(int))
                {
                    factor = unfactored;
                }

                factors.Add(factor);
                unfactored /= factor;
            }

            return factors;
        }

        private void extendKnownPrimes(int max)
        {
            var min = this.knownPrimes.Any()
                ? this.knownPrimes.Max() + 1
                : 2;

            for (var i = min; i <= max; i++)
            {
                if (this.knownPrimes.All(prime => !isDivisibleBy(i, prime)))
                {
                    this.knownPrimes.Add(i);
                }
            }
        }

        private static bool isDivisibleBy(int x, int d)
            => x % d == 0;
    }
}
