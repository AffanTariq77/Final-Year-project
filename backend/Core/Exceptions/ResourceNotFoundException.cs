using System;

namespace AdventureAdorn.API.Core.Extenstions
{
    [Serializable]
    public class ResourceNotFoundException : ApplicationException
    {
        public ResourceNotFoundException(string message) : base(message)
        {
        }

        public ResourceNotFoundException(Exception exception, string message) : base(message, exception)
        {
        }
    }
}