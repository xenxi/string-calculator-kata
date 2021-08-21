using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void return_0_for_empty_string()
        {
            string aGivenEmptyString = string.Empty;

            var calculateValue = StringCalculator.Add(aGivenEmptyString);

            calculateValue.Should().Be(0);
        }

        [Test]
        public void return_0_for_null()
        {
            string aGivenNullString = null;

            var calculateValue = StringCalculator.Add(aGivenNullString);

            calculateValue.Should().Be(0);
        }
    }
}