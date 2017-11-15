using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Adamrmoss.PrimeFactorization
{
    public class IntegerLoader
    {
        public IReadOnlyList<int> GetIntegersFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"{filePath} Not Found", filePath);

            var fileLines = File.ReadAllLines(filePath);

            return fileLines
                .Where(line => line.Trim() != "")
                .Select(parseLine).ToList();
        }

        private static int parseLine(string line)
            => int.TryParse(line, out var result)
                ? result
                : throw new FormatException($"{line} cannot be parsed as an int.");
    }
}
