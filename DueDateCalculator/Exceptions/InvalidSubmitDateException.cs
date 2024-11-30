namespace DueDateCalculator.Exceptions
{
    public class InvalidSubmitDateException : Exception
    {
        public InvalidSubmitDateException()
        {
        }

        public InvalidSubmitDateException(string message)
            : base(message)
        {
        }

        public InvalidSubmitDateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
