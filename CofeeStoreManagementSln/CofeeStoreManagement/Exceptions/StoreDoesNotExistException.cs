using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    internal class StoreDoesNotExistException : Exception
    {
        public StoreDoesNotExistException()
        {
        }

        public StoreDoesNotExistException(string? message) : base(message)
        {
        }

        public StoreDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}