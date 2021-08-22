using System.Linq;

namespace StringCalculatorKata
{
    public class DelimitedNumbersString
    {
        private readonly string[] _default_delimiters = new string[] { ",", "\n" };

        public DelimitedNumbersString(string inputString)
        {
            (this.delimiters, this.inputString) = GetDelimitersAndCleanInputString(inputString);
        }

        public DelimitedNumbersString(string inputString, string[] delimiters)
        {
            this.inputString = inputString;
            this.delimiters = delimiters;
        }

        public string[] delimiters { get; }
        public string inputString { get; }

        private (string[] delimiters, string cleanInputString) GetDelimitersAndCleanInputString(string inputString)
        {
            if (inputString.StartsWith("//"))
            {
                var customDelimiterStr = inputString.Split('\n').First();

                var customDelimiters = customDelimiterStr.Replace("//", string.Empty).Split("[").Select(strDelimiter => strDelimiter.Replace("]", string.Empty));

                var cleanInputString = inputString.Replace($"{customDelimiterStr}\n", string.Empty);

                return (_default_delimiters.Union(customDelimiters).ToArray(), cleanInputString);
            }

            return (_default_delimiters, inputString);
        }
    }
}