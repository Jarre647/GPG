using System;

namespace SQLRepository.Exceptions
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
