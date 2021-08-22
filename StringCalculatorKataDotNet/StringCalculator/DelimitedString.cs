using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class DelimitedString
    {
        private readonly string[] _default_delimiters = new string[] { ",", "\n" };

        public DelimitedString(string inputString)
        {
            (this.delimiters, this.value) = GetDelimitersAndCleanInputString(inputString);

            this.Value = Split();
        }

        public IEnumerable<string> Value { get; }
        private string[] delimiters { get; }
        private string value { get; }
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

        private IEnumerable<string> Split()
        {
            return value.Split(delimiters, options: StringSplitOptions.RemoveEmptyEntries);
        }
    }
}