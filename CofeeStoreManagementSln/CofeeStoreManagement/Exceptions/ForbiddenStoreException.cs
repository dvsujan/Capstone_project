using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    internal class ForbiddenStoreException : Exception
    {
        public ForbiddenStoreException()
        {
        }

        public ForbiddenStoreException(string? message) : base(message)
        {
        }

        public ForbiddenStoreException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}