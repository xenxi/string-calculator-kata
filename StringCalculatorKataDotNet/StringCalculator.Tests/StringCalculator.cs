using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Tests
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

            IEnumerable<int> numbers = GetNumbers(inputString);

            return numbers.Sum();
        }

        private (string[] delimiters, string cleanInputString) GetDelimiters(string inputString)
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
            if (inputString.StartsWith("//"))
                return GetNumbersWithCustomDelimiter(inputString);

            (var delimiters, var cleanInputString) = GetDelimiters(inputString);

            return cleanInputString.Split(delimiters, options: StringSplitOptions.RemoveEmptyEntries)
                        .Select(stringNumber => int.Parse(stringNumber));
        }

        private IEnumerable<int> GetNumberSeparatedByComma(string inputString)
        {
            return inputString
                        .Split(_default_delimiters, options: StringSplitOptions.RemoveEmptyEntries)
                        .Select(stringNumber => int.Parse(stringNumber));
        }

        private IEnumerable<int> GetNumbersWithCustomDelimiter(string inputString)
        {
            var customDelimiterStr = inputString.Split('\n').First();

            var customDelimiter = customDelimiterStr.Replace("//", string.Empty);

            var numbersString = inputString.Replace($"{customDelimiterStr}\n", string.Empty);

            var delimiters = _default_delimiters.Append(customDelimiter);

            return numbersString
            .Split(separator: delimiters.ToArray(), options: StringSplitOptions.RemoveEmptyEntries)
            .Select(stringNumber => int.Parse(stringNumber));
        }
    }
}