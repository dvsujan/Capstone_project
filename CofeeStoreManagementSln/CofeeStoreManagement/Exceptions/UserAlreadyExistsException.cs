﻿namespace CofeeStoreManagement.Exceptions
{
    [Serializable]
    internal class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string? message) : base(message)
        {
        }

        public UserAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}