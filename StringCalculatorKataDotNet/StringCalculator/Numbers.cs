using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class Numbers
    {
        private readonly IEnumerable<int> _numbers;

        public Numbers(IEnumerable<int> numbers)
        {
            _numbers = numbers ?? Enumerable.Empty<int>();
        }

        public IEnumerable<int> GetCollection()
        {
            var negativeNumbers = _numbers.Where(number => number < 0);

            if (negativeNumbers.Any())
                throw new NegativesNotAllowed(string.Join(",", negativeNumbers));

            return _numbers;
        }

    }
}