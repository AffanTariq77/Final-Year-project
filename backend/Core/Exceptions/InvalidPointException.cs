using System;
using System.Runtime.Serialization;

namespace AdventureAdorn.API.Core.Extenstions
{
    public class InvalidPointException : Exception
    {
        public InvalidPointException()
        {
        }

        public InvalidPointException(string message)
            : base(message)
        {
        }

        public InvalidPointException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected InvalidPointException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}