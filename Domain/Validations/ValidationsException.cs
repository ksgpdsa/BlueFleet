namespace Domain.Validations
{
    internal class ValidationsException : Exception
    {
        public ValidationsException(string error) : base(error)
        {

        }

        public static void When(bool hasError, string message)
        {
            if (hasError)
            {
                throw new ValidationsException(message);
            }
        }
    }
}
