using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;

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
        [TestCase("1,2,4", 7)]
        [TestCase("2,3,5,6,7", 23)]
        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        public void return_sum_given_string_with_multiple_numbers_separated_by_comma(string aGivenString, int expectedValue)
        {
            var calculatedValue = stringCalculator.Add(aGivenString);

            calculatedValue.Should().Be(expectedValue);
        }

        [Test]
        [TestCase("1\n2\n4", 7)]
        [TestCase("2\n3,5,6\n7", 23)]
        public void return_sum_given_string_with_multiple_numbers_separated_by_comma_or_new_line(string aGivenString, int expectedValue)
        {
            var calculatedValue = stringCalculator.Add(aGivenString);

            calculatedValue.Should().Be(expectedValue);
        }

        [Test]
        [TestCase("//;\n1\n2;4", 7)]
        public void return_sum_given_string_with_multiple_numbers_separated_by_custom_delimiter(string aGivenString, int expectedValue)
        {
            var calculatedValue = stringCalculator.Add(aGivenString);

            calculatedValue.Should().Be(expectedValue);
        }

        [SetUp]
        public void SetUp()
        {
            stringCalculator = new StringCalculator();
        }
    }
}