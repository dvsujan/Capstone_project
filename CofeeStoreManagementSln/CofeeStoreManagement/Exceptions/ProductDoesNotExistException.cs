using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException()
        {
        }

        public ProductDoesNotExistException(string? message) : base(message)
        {
        }

        public ProductDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}