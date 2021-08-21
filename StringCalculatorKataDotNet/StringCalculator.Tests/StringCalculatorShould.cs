using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void SetUp()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void return_0_given_empty_string()
        {
            string aGivenEmptyString = string.Empty;

            var calculatedValue = stringCalculator.Add(aGivenEmptyString);

            calculatedValue.Should().Be(0);
        }

        [Test]
        public void return_0_given_null_string()
        {
            string aGivenNullString = null;

            var calculatedValue = stringCalculator.Add(aGivenNullString);

            calculatedValue.Should().Be(0);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void return_number_given_in_string_with_one_number(string aGivenInputString, int expectedNumber)
        {
            var calculatedValue = stringCalculator.Add(aGivenInputString);

            calculatedValue.Should().Be(expectedNumber);
        }

        [Test]
        public void return_3_given_string_with_1_and_2_separated_by_comma()
        {
            var calculatedValue = stringCalculator.Add("1,2");

            calculatedValue.Should().Be(3);
        }
    }
}