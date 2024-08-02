using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class InvalidOrderStatusException : Exception
    {
        public InvalidOrderStatusException()
        {
        }

        public InvalidOrderStatusException(string? message) : base(message)
        {
        }

        public InvalidOrderStatusException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}