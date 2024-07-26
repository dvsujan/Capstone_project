namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
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