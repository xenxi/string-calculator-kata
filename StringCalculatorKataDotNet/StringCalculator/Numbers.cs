using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class Numbers
    {
        private const int MAX_NUMBER_VALUE = 1000;
        private const int MIN_NUMBER_VALUE = 0;

        private readonly ICollection<int> _numbers;

        public Numbers(IEnumerable<int> numbers)
        {
            _numbers = (numbers ?? Enumerable.Empty<int>()).ToList();

            ensureNoHasNegativeNumbers();
        }

        private void ensureNoHasNegativeNumbers()
        {
            var negativeNumbers = _numbers.Where(number => number < MIN_NUMBER_VALUE);

            if (negativeNumbers.Any())
                throw new NegativesNotAllowed(string.Join(",", negativeNumbers));
        }

        public int Sum() => _numbers.Where(number => number != MAX_NUMBER_VALUE).Sum();
    }
}