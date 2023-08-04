using Newtonsoft.Json;
using RAGS.API_FOOTBALL.Exceptions;
using RAGS.API_FOOTBALL.Models;
using RAGS.HttpClientHelper;
using System.Net;
using System.Reflection.PortableExecutable;

namespace RAGS.API_FOOTBALL
{
    public class API_FOOTBALL
    {
        Dictionary<string, string> requestHeaders = new();

        public API_FOOTBALL(string key) {
            requestHeaders.Add("X-RapidAPI-Key", key);
            requestHeaders.Add("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
        }

        /// <summary>
        /// Get the list of available timezone to be used in the fixtures endpoint.
        /// </summary>
        /// <returns>Return all the existing timezone.</returns>
        /// <exception cref="DeserializeObjectNullException">data null</exception>
        /// <exception cref="HttpStatusCodeException">HTTP code wrong</exception>
        /// <exception cref="Exception">HttpClientHelper exception</exception>
        public Timezone GetTimezones()
        {
            HttpClientHelperResult result = HttpClientHelperNS.Response(
                "https://api-football-v1.p.rapidapi.com/v3/timezone",
                HttpMethod.Get,
                requestHeaders: requestHeaders);

            if (result.error == null)
            {
                if (result.httpStatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<Timezone>(result.data) ?? throw new DeserializeObjectNullException();
                }
                else
                {
                    throw new HttpStatusCodeException(result.httpStatusCode, result.data);
                }
            }
            else
            {
                throw new Exception(null, result.error);
            }
        }
    }
}