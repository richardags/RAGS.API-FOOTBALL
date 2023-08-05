using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL.Models
{
    public class Countries : ModelBase
    {
        public class Country
        {
            public required CountriesNames name;
            public required CountriesCode? code;
            public required string? flag;
        }
        public required Country[] response;
    }
}