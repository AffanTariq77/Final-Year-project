using System;

namespace AdventureAdorn.API.Core.Extenstions
{
    [Serializable]
    public class ResourceAlreadyExistsException : ApplicationException
    {
        public ResourceAlreadyExistsException(string message) : base(message)
        {
        }

        public ResourceAlreadyExistsException(Exception exception, string message) : base(message, exception)
        {
        }
    }
}