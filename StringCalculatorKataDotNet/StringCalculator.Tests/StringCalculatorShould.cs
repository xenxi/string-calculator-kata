using FluentAssertions;
using NUnit.Framework;
using System;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;

        [Test]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[alicatao]\n9alicatao2alicatao6", 17)]
        public void allow_custom_delimiters_with_any_length_when_they_are_between_brackets(string aGivenString, int expectedValue)
        {
            var calculatedValue = stringCalculator.Add(aGivenString);

            calculatedValue.Should().Be(expectedValue);
        }

        [Test]
        [TestCase("//[*][a]\n1*2a3,2a5*2", 15)]
        [TestCase("//[***][alicatao]\n1***2alicatao3,2alicatao2", 10)]
        public void allow_multiple_custom_delimiters_with_any_length(string aGivenInputString, int expectedValue)
        {
            var calculatedValue = stringCalculator.Add(aGivenInputString);

            calculatedValue.Should().Be(expectedValue);
        }

        [Test]
        [TestCase("2,1000", 2)]
        [TestCase("1,1000", 1)]
        [TestCase("1,1000\n5,1000,1", 7)]
        public void ignore_numbers_bigger_than_1000(string aGivenInputString, int expectedValue)
        {
            var calculatedValue = stringCalculator.Add(aGivenInputString);

            calculatedValue.Should().Be(expectedValue);
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
        [TestCase("//-\n2-3,5,6-7", 23)]
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

        [Test]
        [TestCase("-1")]
        [TestCase("-2")]
        [TestCase("1\n-2\n4")]
        [TestCase("1,2\n-4")]
        public void throw_negative_numbers_exception_given_string_with_one_negative_number(string aGivenInputString)
        {
            Action action = () => stringCalculator.Add(aGivenInputString);

            action.Should().Throw<NegativesNotAllowed>();
        }

        [Test]
        [TestCase("-1,-5", "-1,-5")]
        [TestCase("1\n-2\n4,-5", "-2,-5")]
        [TestCase("-1,-2\n-4", "-1,-2,-4")]
        public void throw_negative_numbers_exception_with_negatives_passed(string aGivenInputString, string aExpectedExceptionMessage)
        {
            Action action = () => stringCalculator.Add(aGivenInputString);

            action.Should().Throw<NegativesNotAllowed>().Where(x => x.Message == aExpectedExceptionMessage);
        }
    }
}