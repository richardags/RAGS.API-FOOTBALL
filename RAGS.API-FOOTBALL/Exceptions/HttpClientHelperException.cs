using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL.Exceptions
{
    public class HttpClientHelperException : Exception
    {
        public HttpClientHelperException() { }

        public HttpClientHelperException(string message) : base(message) { }

        public HttpClientHelperException(Exception inner) : base(null, inner) { }
    }
}
