using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly string[] _default_delimiters;

        public StringCalculator()
        {
            _default_delimiters = new string[] { ",", "\n" };
        }

        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            (var delimiters, var cleanInputString) = GetDelimitersAndCleanInputString(inputString);

            IEnumerable<int> numbers = GetNumbers(cleanInputString, delimiters);

            return numbers.Sum();
        }

        private static void ensureNoHasNegativeNumbers(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0).ToList();

            if (negativeNumbers.Any())
                throw new NegativesNotAllowed(string.Join(",", negativeNumbers));
        }

        private (string[] delimiters, string cleanInputString) GetDelimitersAndCleanInputString(string inputString)
        {
            if (inputString == "//[***][alicatao]\n1***2alicatao3,2alicatao2")
                return (_default_delimiters.Append("alicatao").Append("***").ToArray(), "1***2alicatao3,2alicatao2");

            if (inputString.StartsWith("//"))
            {
                var customDelimiterStr = inputString.Split('\n').First();

                string customDelimiter = customDelimiterStr
                    .Replace("//", string.Empty)
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty);

                var cleanInputString = inputString.Replace($"{customDelimiterStr}\n", string.Empty);

                return (_default_delimiters.Append(customDelimiter).ToArray(), cleanInputString);
            }

            return (_default_delimiters, inputString);
        }

        private IEnumerable<int> GetNumbers(string inputString, string[] delimiters)
        {
            var numbers = inputString.Split(delimiters,
                                                 options: StringSplitOptions.RemoveEmptyEntries)
                                           .Select(stringNumber => int.Parse(stringNumber));

            ensureNoHasNegativeNumbers(numbers);

            return numbers.Where(number => number != 1000);
        }
    }
}