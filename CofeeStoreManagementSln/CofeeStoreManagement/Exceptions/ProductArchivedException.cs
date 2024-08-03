namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    public class ProductArchivedException : Exception
    {
        public ProductArchivedException()
        {
        }

        public ProductArchivedException(string? message) : base(message)
        {
        }

        public ProductArchivedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}