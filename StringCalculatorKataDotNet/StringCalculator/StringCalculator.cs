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

            var numbers = GetNumbers(cleanInputString, delimiters);

            return numbers.Sum();
        }

        private (string[] delimiters, string cleanInputString) GetDelimitersAndCleanInputString(string inputString)
        {
            if (inputString.StartsWith("//"))
            {
                var customDelimiterStr = inputString.Split('\n').First();

                var customDelimiters = customDelimiterStr.Replace("//", string.Empty).Split("[").Select(strDelimiter => strDelimiter.Replace("]", string.Empty));

                var cleanInputString = inputString.Replace($"{customDelimiterStr}\n", string.Empty);

                return (_default_delimiters.Union(customDelimiters).ToArray(), cleanInputString);
            }

            return (_default_delimiters, inputString);
        }

        private Numbers GetNumbers(string inputString, string[] delimiters)
        {
            var numbers = inputString.Split(delimiters,
                                                 options: StringSplitOptions.RemoveEmptyEntries)
                                           .Select(stringNumber => int.Parse(stringNumber));

            return new Numbers(numbers);
        }
    }
}