using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class IncorrectPasswordException : Exception
    {
        public IncorrectPasswordException()
        {
        }

        public IncorrectPasswordException(string? message) : base(message)
        {
        }

        public IncorrectPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}