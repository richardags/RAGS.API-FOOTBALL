using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL.Exceptions
{
    public class DeserializeObjectNullException : Exception
    {
        public DeserializeObjectNullException() { }

        public DeserializeObjectNullException(string message) : base(message) { }

        public DeserializeObjectNullException(string message, Exception inner) : base(message, inner) { }
    }
}