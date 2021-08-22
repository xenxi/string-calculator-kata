using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            var delimitedNumbersString = new DelimitedNumbersString(inputString);

            var numbers = GetNumbers(delimitedNumbersString);

            return numbers.Sum();
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