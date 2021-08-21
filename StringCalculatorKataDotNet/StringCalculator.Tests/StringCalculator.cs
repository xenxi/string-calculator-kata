using System.Linq;

namespace StringCalculatorKata.Tests
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            if (areMultipleNumbersSeparatedByComma(inputString))
                return sumMultipleNumberSeparatedByComma(inputString);

            return int.Parse(inputString);
        }

        private int sumMultipleNumberSeparatedByComma(string inputString)
        {
            return inputString.Split(",").Select(stringNumber => int.Parse(stringNumber)).Sum();
        }

        private bool areMultipleNumbersSeparatedByComma(string inputString)
        {
            return inputString.Contains(",");
        }
    }
}