using System.Linq;

namespace StringCalculatorKata.Tests
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            return sumMultipleNumberSeparatedByComma(inputString);
        }

        private int sumMultipleNumberSeparatedByComma(string inputString) => inputString
            .Split(",")
            .Select(stringNumber => int.Parse(stringNumber))
            .Sum();
    }
}