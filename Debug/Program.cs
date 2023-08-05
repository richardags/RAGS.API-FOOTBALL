using RAGS.API_FOOTBALL;
using RAGS.API_FOOTBALL.Models;
using Newtonsoft.Json;
using static RAGS.API_FOOTBALL.Models.Fixtures;

namespace Debug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            API_FOOTBALL api = new("YOU-API-KEY");

            int[] ids = new int[] { 996101, 1004299, 1004300, 1006659, 1023834, 1025901, 1027649, 1027816, 1029408, 1029410, 1029411, 1029677, 1029678, 1029680, 1029684, 1029685, 1031796, 1035835, 1036930, 1037656, 1041188, 1044276, 1048217, 1048457, 1048584, 1049792, 1050213, 1050216, 1061323, 1072533, 1083497, 1094378, 1094388, 1094392, 1094635, 1097183, 1097225, 1098113, 1098114, 1099835, 1104070, 1104737, 1104947, 1104966, 1104968, 1106556, 1106557, 1106588, 1106590, 1106592, 1106593, 1000661, 1018906, 1029415, 1031795, 1036929, 1037321, 1041043, 1041044, 1042033, 1042895, 1045880, 1045881, 1045882, 1045885, 1045886, 1045887, 1045888, 1045889, 1050215, 1053038, 1056143, 1056148, 1061315, 1062542, 1064406, 1067272, 1083086, 1106581, 1106582, 1106583, 1106584, 1106585, 1106586, 1106587, 1106632, 1106633 };
            Fixtures fixtures = api.GetFixtures(ids[0..19]);

            foreach (Response response in fixtures.response)
            {
                Console.WriteLine(string.Format("{0} {1} - {2} x {3} {4}-{5}", response.league.country.NameToString(), response.league.name, response.teams.home.name,
                    response.teams.away.name, response.goals.home, response.goals.away));

                Console.WriteLine(string.Format("Possession %: {0}/{1}", response.statistics[0].GetBallPossession,
                    response.statistics[1].GetBallPossession));

                Console.WriteLine(string.Format("Corner Kicks: {0} - Red Cards: {1} - Yellow Cards: {2} - Shots/On Target: {3}/{4}", response.statistics[0].GetCornerKicks, response.statistics[0].GetRedCards,
                    response.statistics[0].GetYellowCards, response.statistics[0].GetTotalShots, response.statistics[0].GetShotsOnGoal));
                
                Console.WriteLine(string.Format("Shots/On Target: {0}/{1} - Yellow Cards: {2} - Red Cards: {3} - Corner Kicks: {4}", response.statistics[1].GetTotalShots, response.statistics[1].GetShotsOnGoal,
                    response.statistics[1].GetYellowCards, response.statistics[1].GetRedCards, response.statistics[1].GetCornerKicks));

                Console.WriteLine();
            }


            Console.WriteLine("\nRemaining requests: " + api.GetRequestsRemaining);
            return;

            //get all timezone
            Fixtures fixturesInPlay = api.GetFixturesInPlay();

            foreach(Response response in fixturesInPlay.response)
            {
                Console.WriteLine(string.Format("{0} {1} ({2})", response.league.country.NameToString(), response.league.name, response.fixture.id));
                Console.WriteLine(string.Format("{0} x {1}", response.teams.home.name, response.teams.away.name));
                Console.WriteLine(string.Format("Gols: {0} - {1}\n", response.goals.home, response.goals.away));
            }

            Console.WriteLine("Total de juegos: " + fixturesInPlay.response.Length);

            //get all timezone
            Countries countries = api.GetAllCountries();
            Console.WriteLine(JsonConvert.SerializeObject(countries));

            //get all timezone
            Timezone timezone = api.GetAllTimezone();
            Console.WriteLine(JsonConvert.SerializeObject(timezone));

            //get requests remeaning, limit, reset timeoff
            Console.WriteLine(api.GetRequestsRemaining);
            Console.WriteLine(api.GetRequestsLimit);
            Console.WriteLine(api.GetRequestsReset);



            Console.ReadKey();
        }
    }
}