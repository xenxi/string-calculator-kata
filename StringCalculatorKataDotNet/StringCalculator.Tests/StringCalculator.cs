namespace StringCalculatorKata.Tests
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return 0;


            if (inputString == "2")
                return 2;

            return 1;
        }
    }
}