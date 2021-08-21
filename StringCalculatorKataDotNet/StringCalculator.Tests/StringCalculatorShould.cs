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
            var calculateValue = StringCalculator.Add(string.Empty);

            calculateValue.Should().Be(0);
        }
    }
}