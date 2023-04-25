using System;
using System.Collections.Generic;
using System.Text;

namespace Mde.FetchClient.Services.Implementation.Models
{

    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
