using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class CartEmptyException : Exception
    {
        public CartEmptyException()
        {
        }

        public CartEmptyException(string? message) : base(message)
        {
        }

        public CartEmptyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}