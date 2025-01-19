using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureAdorn.API.Core.Extenstions
{
    [Serializable]
    public class NotValidException : ApplicationException
    {
        public NotValidException(string message) : base(message)
        {
        }

        public NotValidException(Exception exception, string message) : base(message, exception)
        {
        }

        public NotValidException(IEnumerable<string> errors): base(string.Join("-> ", errors))
        {
        }
    }
}
