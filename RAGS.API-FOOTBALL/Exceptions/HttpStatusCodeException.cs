using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCodeException() { }

        public HttpStatusCodeException(HttpStatusCode httpStatusCode, string message) : base(string.Format("code: {0}\ndata: {1}", httpStatusCode, message)) { }

        public HttpStatusCodeException(string message, Exception inner) : base(message, inner) { }
    }
}