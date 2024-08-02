using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    internal class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException()
        {
        }

        public UserDoesNotExistException(string? message) : base(message)
        {
        }

        public UserDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}