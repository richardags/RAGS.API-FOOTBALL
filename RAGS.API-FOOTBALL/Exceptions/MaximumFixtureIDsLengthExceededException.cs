using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL.Exceptions
{
    public class MaximumFixtureIDsLengthExceededException : Exception
    {
        public MaximumFixtureIDsLengthExceededException() { }

        public MaximumFixtureIDsLengthExceededException(HttpStatusCode httpStatusCode, string message) : base(string.Format("code: {0}\ndata: {1}", httpStatusCode, message)) { }

        public MaximumFixtureIDsLengthExceededException(string message, Exception inner) : base(message, inner) { }
    }
}