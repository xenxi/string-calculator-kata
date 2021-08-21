using System;

namespace StringCalculatorKata
{
    public class NegativesNotAllowed : Exception
    {
        public NegativesNotAllowed() : base()
        {
        }

        public NegativesNotAllowed(string message) : base(message)
        {
        }

        public NegativesNotAllowed(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}