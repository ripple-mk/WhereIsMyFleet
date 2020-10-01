using System;

namespace WhereIsMyFleet.Core.Abstractions.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
