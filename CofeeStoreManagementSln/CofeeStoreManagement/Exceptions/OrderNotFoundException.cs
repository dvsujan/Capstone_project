﻿using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException()
        {
        }

        public OrderNotFoundException(string? message) : base(message)
        {
        }

        public OrderNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}