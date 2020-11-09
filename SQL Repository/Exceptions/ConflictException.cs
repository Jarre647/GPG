using System;

namespace SQL_Repository.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException()
        {
        }
    }
}