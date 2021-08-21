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

            var calculateValue = stringCalculator.Add(aGivenEmptyString);

            calculateValue.Should().Be(0);
        }

        [Test]
        public void return_0_given_null_string()
        {
            string aGivenNullString = null;

            var calculateValue = stringCalculator.Add(aGivenNullString);

            calculateValue.Should().Be(0);
        }

        [Test]
        public void return_1_given_string_with_1()
        {
            var aGivenStringOne = "1";

            var calculateValue = stringCalculator.Add(aGivenStringOne);

            calculateValue.Should().Be(1);
        }

        [Test]
        public void return_2_given_string_with_2()
        {
            var calculatedValue = stringCalculator.Add("2");

            calculatedValue.Should().Be(2);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void returnNumberGivenInStringWithOneNumber(string aGivenInputString, int expectedNumber)
        {
            var calculatedValue = stringCalculator.Add(aGivenInputString);

            calculatedValue.Should().Be(expectedNumber);
        }
    }
}