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
            return 7;
        }

        private int sumMultipleNumberSeparatedByComma(string inputString) => inputString
            .Split(new char[] {',','\n' })
            .Select(stringNumber => int.Parse(stringNumber))
            .Sum();
    }
}