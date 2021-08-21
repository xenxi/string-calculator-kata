namespace StringCalculatorKata.Tests
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;

            if (inputString.Contains(","))
            {
                var numbers = inputString.Split(",");

                return int.Parse(numbers[0]) + int.Parse(numbers[1]);
            }

            return int.Parse(inputString);
        }
    }
}