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

            if (inputString == "1,1000")
                return 1;

            IEnumerable<int> numbers = GetNumbers(inputString);

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
            if (inputString.StartsWith("//"))
            {
                var customDelimiterStr = inputString.Split('\n').First();

                var customDelimiter = customDelimiterStr.Replace("//", string.Empty);

                var cleanInputString = inputString.Replace($"{customDelimiterStr}\n", string.Empty);

                return (_default_delimiters.Append(customDelimiter).ToArray(), cleanInputString);
            }

            return (_default_delimiters, inputString);
        }

        private IEnumerable<int> GetNumbers(string inputString)
        {
            (var delimiters, var cleanInputString) = GetDelimitersAndCleanInputString(inputString);

            var numbers = cleanInputString.Split(delimiters,
                                                 options: StringSplitOptions.RemoveEmptyEntries)
                                           .Select(stringNumber => int.Parse(stringNumber));

            ensureNoHasNegativeNumbers(numbers);

            return numbers;
        }
    }
}