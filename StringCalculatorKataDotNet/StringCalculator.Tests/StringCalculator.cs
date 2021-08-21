using System;
using System.Linq;

namespace StringCalculatorKata.Tests
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            if (inputString.StartsWith("//"))
                return sumNumberWithCustomDelimiter(inputString);

            return sumMultipleNumberSeparatedByComma(inputString);
        }

        private int sumNumberWithCustomDelimiter(string inputString)
        {
            var customDelimiterStr = inputString.Split('\n').First();

            var customDelimiter = customDelimiterStr.Replace("//", string.Empty);

            var numbersString = inputString.Replace($"{customDelimiterStr}\n", string.Empty);

            var delimiters = new string[] { ",", "\n", customDelimiter };

            return numbersString
            .Split(separator: delimiters, options: StringSplitOptions.RemoveEmptyEntries)
            .Select(stringNumber => int.Parse(stringNumber))
            .Sum();
        }

        private int sumMultipleNumberSeparatedByComma(string inputString) => inputString
            .Split(new char[] { ',', '\n' })
            .Select(stringNumber => int.Parse(stringNumber))
            .Sum();
    }
}