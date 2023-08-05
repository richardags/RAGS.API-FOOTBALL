using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAGS.API_FOOTBALL
{
    internal class URLBuilder
    {
        public const string HOST = "api-football-v1.p.rapidapi.com";
        private static readonly string URL_BASE = string.Format("https://{0}/v3/", HOST);

        public static string Timezone {
            get
            {
                return URL_BASE + "timezone";
            }
        }
        public static string Countries
        {
            get
            {
                return URL_BASE + "countries";
            }
        }
        public static string FixturesInPlay
        {
            get
            {
                return URL_BASE + "fixtures?live=all";
            }
        }
        public static string Fixture(int id)
        {
            return string.Format("{0}fixtures?id={1}", URL_BASE, id);
        }
        public static string Fixtures(int[] ids)
        {
            return string.Format("{0}fixtures?ids={1}", URL_BASE, string.Join("-", ids));
        }
    }
}