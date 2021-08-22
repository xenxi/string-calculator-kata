using System;
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

            var numbers = GetNumbers(new DelimitedNumbersString(cleanInputString, delimiters));

            return numbers.Sum();
        }

        private (string[] delimiters, string cleanInputString) GetDelimitersAndCleanInputString(string inputString)
        {
            var delimiters = new DelimitedNumbersString(inputString);

            return (delimiters.delimiters, delimiters.inputString);
        }

        private Numbers GetNumbers(DelimitedNumbersString delimitedNumbersString)
        {
            var numbers = delimitedNumbersString.inputString.Split(delimitedNumbersString.delimiters,
                                                 options: StringSplitOptions.RemoveEmptyEntries)
                                           .Select(stringNumber => int.Parse(stringNumber));

            return new Numbers(numbers);
        }
    }
}