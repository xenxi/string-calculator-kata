using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void return_0_given_empty_string()
        {
            string aGivenEmptyString = string.Empty;

            var calculateValue = StringCalculator.Add(aGivenEmptyString);

            calculateValue.Should().Be(0);
        }

        [Test]
        public void return_0_given_null_string()
        {
            string aGivenNullString = null;

            var calculateValue = StringCalculator.Add(aGivenNullString);

            calculateValue.Should().Be(0);
        }

        [Test]
        public void return_1_given_string_with_one()
        {
            var aGivenStringOne = "1";

            var calculateValue = StringCalculator.Add(aGivenStringOne);

            calculateValue.Should().Be(1);
        }
    }
}