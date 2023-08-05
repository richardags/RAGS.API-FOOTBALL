using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RAGS.API_FOOTBALL.Models
{
    public class ModelBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Get
        {
            timezone, countries, fixtures
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
    }
}