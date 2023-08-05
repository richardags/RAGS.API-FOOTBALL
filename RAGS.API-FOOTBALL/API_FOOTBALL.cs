using Newtonsoft.Json;
using RAGS.API_FOOTBALL.Exceptions;
using RAGS.API_FOOTBALL.Models;
using RAGS.HttpClientHelper;
using System.Net;
using System.Net.Http.Headers;

namespace RAGS.API_FOOTBALL
{
    public class API_FOOTBALL
    {
        private static readonly Dictionary<string, string> requestHeaders = new();

        private int limit = -1;
        private int remaining = -1;
        private int reset = -1; //in seconds

        public API_FOOTBALL(string key) {
            requestHeaders.Add("X-RapidAPI-Key", key);
            requestHeaders.Add("X-RapidAPI-Host", URLBuilder.HOST);
        }

        public int GetRequestsLimit { get { return limit; } }
        public int GetRequestsRemaining { get { return remaining; } }
        public int GetRequestsResetInSeconds { get { return reset; } }
        /// <summary>
        /// UTC Datetime
        /// </summary>
        public DateTimeOffset GetRequestsReset { get { return DateTimeOffset.UtcNow.AddSeconds(reset); } }

        public bool IsLimitReached
        {
            get
            {
                return limit != -1 && remaining != -1 && remaining <= 0;
            }
        }

        /// <summary>
        /// Get the list of available timezone to be used in the fixtures endpoint.
        /// </summary>
        /// <returns>Return all the existing timezone.</returns>
        /// <exception cref="DeserializeObjectNullException"></exception>
        /// <exception cref="HttpStatusCodeException"></exception>
        /// <exception cref="Exception">HttpClientHelper exception</exception>
        public Timezone GetAllTimezone()
        {
            HttpClientHelperResult result = HttpClientHelperNS.Response(
                URLBuilder.Timezone,
                HttpMethod.Get,
                requestHeaders: requestHeaders);

            if (result.error == null)
            {
                if (result.httpStatusCode == HttpStatusCode.OK)
                {
                    Timezone? timezone = JsonConvert.DeserializeObject<Timezone>(result.data);

                    if (timezone != null)
                    {
                        UpdateInfoFromHeaders(result.headers);

                        return timezone;
                    }
                    else
                    {
                        throw new DeserializeObjectNullException();
                    }
                }
                else
                {
                    throw new HttpStatusCodeException(result.httpStatusCode, result.data);
                }
            }
            else
            {
                throw new HttpClientHelperException(result.error);
            }
        }
        /// <summary>
        /// Get the list of available countries for the leagues endpoint.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DeserializeObjectNullException"></exception>
        /// <exception cref="HttpStatusCodeException"></exception>
        /// <exception cref="Exception"></exception>
        public Countries GetAllCountries()
        {
            HttpClientHelperResult result = HttpClientHelperNS.Response(
                URLBuilder.Countries,
                HttpMethod.Get,
                requestHeaders: requestHeaders);

            if (result.error == null)
            {
                if (result.httpStatusCode == HttpStatusCode.OK)
                {
                    Countries? countries = JsonConvert.DeserializeObject<Countries>(result.data);

                    if (countries != null)
                    {
                        UpdateInfoFromHeaders(result.headers);

                        return countries;
                    }
                    else
                    {
                        throw new DeserializeObjectNullException();
                    }
                }
                else
                {
                    throw new HttpStatusCodeException(result.httpStatusCode, result.data);
                }
            }
            else
            {
                throw new HttpClientHelperException(result.error);
            }
        }
        /// <summary>
        /// Get all available fixtures in play
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DeserializeObjectNullException"></exception>
        /// <exception cref="HttpStatusCodeException"></exception>
        /// <exception cref="HttpClientHelperException"></exception>
        public Fixtures GetFixturesInPlay()
        {
            HttpClientHelperResult result = HttpClientHelperNS.Response(
                URLBuilder.FixturesInPlay,
                HttpMethod.Get,
                requestHeaders: requestHeaders);

            if (result.error == null)
            {
                if (result.httpStatusCode == HttpStatusCode.OK)
                {
                    Fixtures? fixtures = JsonConvert.DeserializeObject<Fixtures>(result.data);

                    if (fixtures != null)
                    {
                        UpdateInfoFromHeaders(result.headers);

                        return fixtures;
                    }
                    else
                    {
                        throw new DeserializeObjectNullException();
                    }
                }
                else
                {
                    throw new HttpStatusCodeException(result.httpStatusCode, result.data);
                }
            }
            else
            {
                throw new HttpClientHelperException(result.error);
            }
        }
        /// <summary>
        /// Get fixture from one fixture {id}
        /// events, lineups, statistics fixture and players fixture are returned in the response
        /// </summary>
        /// <param name="id">fixture id</param>
        /// <returns></returns>
        /// <exception cref="DeserializeObjectNullException"></exception>
        /// <exception cref="HttpStatusCodeException"></exception>
        /// <exception cref="HttpClientHelperException"></exception>
        public Fixtures GetFixture(int id)
        {
            HttpClientHelperResult result = HttpClientHelperNS.Response(
                URLBuilder.Fixture(id),
                HttpMethod.Get,
                requestHeaders: requestHeaders);

            if (result.error == null)
            {
                if (result.httpStatusCode == HttpStatusCode.OK)
                {
                    Fixtures? fixtures = JsonConvert.DeserializeObject<Fixtures>(result.data);

                    if (fixtures != null)
                    {
                        UpdateInfoFromHeaders(result.headers);

                        return fixtures;
                    }
                    else
                    {
                        throw new DeserializeObjectNullException();
                    }
                }
                else
                {
                    throw new HttpStatusCodeException(result.httpStatusCode, result.data);
                }
            }
            else
            {
                throw new HttpClientHelperException(result.error);
            }
        }
        /// <summary>
        /// Get fixture from severals fixtures {ids}
        /// events, lineups, statistics fixture and players fixture are returned in the response
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="DeserializeObjectNullException"></exception>
        /// <exception cref="HttpStatusCodeException"></exception>
        /// <exception cref="HttpClientHelperException"></exception>
        public Fixtures GetFixtures(int[] ids)
        {
            if(ids.Length > 20)
            {
                throw new MaximumFixtureIDsLengthExceededException();
            }

            HttpClientHelperResult result = HttpClientHelperNS.Response(
                URLBuilder.Fixtures(ids),
                HttpMethod.Get,
                requestHeaders: requestHeaders);

            if (result.error == null)
            {
                if (result.httpStatusCode == HttpStatusCode.OK)
                {
                    Fixtures? fixtures = JsonConvert.DeserializeObject<Fixtures>(result.data);

                    if (fixtures != null)
                    {
                        UpdateInfoFromHeaders(result.headers);

                        return fixtures;
                    }
                    else
                    {
                        throw new DeserializeObjectNullException();
                    }
                }
                else
                {
                    throw new HttpStatusCodeException(result.httpStatusCode, result.data);
                }
            }
            else
            {
                throw new HttpClientHelperException(result.error);
            }
        }

        private void UpdateInfoFromHeaders(HttpResponseHeaders headers)
        {
            IEnumerable<string> limitValues;
            if (headers.TryGetValues("x-ratelimit-requests-limit", out limitValues))
            {
                limit = int.Parse(limitValues.First());
            }
            IEnumerable<string> remainingValues;
            if (headers.TryGetValues("x-ratelimit-requests-remaining", out remainingValues))
            {
                remaining = int.Parse(remainingValues.First());
            }
            IEnumerable<string> resetValues;
            if (headers.TryGetValues("x-ratelimit-requests-reset", out resetValues))
            {
                reset = int.Parse(resetValues.First());
            }
        }
    }
}