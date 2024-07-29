namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
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