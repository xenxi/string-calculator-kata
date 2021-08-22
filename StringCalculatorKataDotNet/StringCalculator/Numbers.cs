using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class Numbers
    {
        private readonly IList<int> _numbers;

        public Numbers(IEnumerable<int> numbers)
        {
            _numbers = (numbers ?? Enumerable.Empty<int>()).ToList();

            ensureNoHasNegativeNumbers();
        }

        private void ensureNoHasNegativeNumbers()
        {
            var negativeNumbers = _numbers.Where(number => number < 0);

            if (negativeNumbers.Any())
                throw new NegativesNotAllowed(string.Join(",", negativeNumbers));
        }

        public int Sum()
        {
            return _numbers.Where(number => number != 1000).Sum();
        }
    }
}