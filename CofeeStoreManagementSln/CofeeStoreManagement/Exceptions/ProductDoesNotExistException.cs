namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    internal class ProductDoesNotExistException : Exception
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