namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    internal class CategoryDoesNotExistException : Exception
    {
        public CategoryDoesNotExistException()
        {
        }

        public CategoryDoesNotExistException(string? message) : base(message)
        {
        }

        public CategoryDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}