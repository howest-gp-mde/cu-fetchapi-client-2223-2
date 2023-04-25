using System;
using System.Collections.Generic;
using System.Text;

namespace Mde.FetchClient.Exceptions
{
    public class UnauthorizedApiException : Exception
    {
        public UnauthorizedApiException(string message) : base(message)
        {
        }
    }
}
