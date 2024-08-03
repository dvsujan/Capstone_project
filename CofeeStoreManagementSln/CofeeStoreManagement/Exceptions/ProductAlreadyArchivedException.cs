namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    public class ProductAlreadyArchivedException : Exception
    {
        public ProductAlreadyArchivedException()
        {
        }

        public ProductAlreadyArchivedException(string? message) : base(message)
        {
        }

        public ProductAlreadyArchivedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}