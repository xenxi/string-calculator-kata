using System;
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

            if (inputString.StartsWith("//"))
                return sumNumberWithCustomDelimiter(inputString);

            return sumMultipleNumberSeparatedByComma(inputString);
        }

        private int sumMultipleNumberSeparatedByComma(string inputString)
        {
            return inputString
                        .Split(_default_delimiters, options: StringSplitOptions.RemoveEmptyEntries)
                        .Select(stringNumber => int.Parse(stringNumber))
                        .Sum();
        } 

        private int sumNumberWithCustomDelimiter(string inputString)
        {
            var customDelimiterStr = inputString.Split('\n').First();

            var customDelimiter = customDelimiterStr.Replace("//", string.Empty);

            var numbersString = inputString.Replace($"{customDelimiterStr}\n", string.Empty);

            var delimiters = _default_delimiters.Append(customDelimiter);

            return numbersString
            .Split(separator: delimiters.ToArray(), options: StringSplitOptions.RemoveEmptyEntries)
            .Select(stringNumber => int.Parse(stringNumber))
            .Sum();
        }
    }
}