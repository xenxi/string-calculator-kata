namespace StringCalculatorKata.Tests
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            if (areTwoNumbers(inputString))
                return sumTwoNumbers(inputString);

            return int.Parse(inputString);
        }

        private int sumTwoNumbers(string inputString)
        {
            var numbers = inputString.Split(",");

            return int.Parse(numbers[0]) + int.Parse(numbers[1]);
        }

        private bool areTwoNumbers(string inputString)
        {
            return inputString.Contains(",");
        }
    }
}