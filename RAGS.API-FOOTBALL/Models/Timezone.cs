using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL.Models
{
    public class Timezone
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Get
        {
            timezone
        }
        public class Paging
        {
            public int current;
            public int total;
        }

        public Get get;
        public object? parameters;
        public object? errors;
        public int results;
        public Paging paging = new();
        public List<string> response = new();
    }
}