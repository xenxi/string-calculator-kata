namespace StringCalculatorKata.Tests
{
    public static class StringCalculator
    {
        public static int Add(string empty)
        {
            if (string.IsNullOrEmpty(empty))
                return 0;

            return 1;
        }
    }
}