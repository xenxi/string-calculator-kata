namespace StringCalculatorKata
{
    public class DelimitedNumbersString
    {
        public DelimitedNumbersString(string inputString, string[] delimiters)
        {
            this.inputString = inputString;
            this.delimiters = delimiters;
        }

        public string[] delimiters { get; }
        public string inputString { get; }
    }
}