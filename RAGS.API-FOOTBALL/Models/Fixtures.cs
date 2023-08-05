using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static RAGS.API_FOOTBALL.Models.Countries;
using static RAGS.API_FOOTBALL.Models.Fixtures.Data.Fixture;
using static RAGS.API_FOOTBALL.Models.Fixtures.Data.Teams;
using static System.Formats.Asn1.AsnWriter;

namespace RAGS.API_FOOTBALL.Models
{
    public class Fixtures
    {
        public class Data
        {
            public class Fixture
            {
                public enum Timezone
                {
                    UTC
                }
                public class Periods
                {
                    public int first;
                    public object? second;
                }
                public class Venue
                {
                    public object? id;
                    public required string name;
                    public required string city;
                }
                public class Status
                {
                    [JsonProperty("long")]
                    public required string _long;
                    [JsonProperty("short")]
                    public required string _short;
                    public int elapsed;
                }              

                public int id;
                public object? referee;
                public Timezone timezone;
                public required string date;
                public int timestamp;
                public required Periods periods;
                public required Venue venue;
                public required Status status;
            }
            public class League
            {
                public int id;
                public string name;
                public CountriesNames country;
                public string logo;
                public string? flag;
                public int season;
                public string round;
            }
            public class Teams
            {
                public class Team
                {
                    public int id;
                    public string name;
                    public string logo;
                    public bool? winner;
                }

                public Team home;
                public Team away;
            }
            public class Goals
            {
                public int home;
                public int away;
            }
            public class Score
            {
                public class ScoreType
                {
                    public int? home;
                    public int? away;
                }

                public ScoreType halftime;
                public ScoreType fulltime;
                public ScoreType extratime;
                public ScoreType penalty;
            }
            public class Statistics
            {
                internal class StatisticJsonConverter : JsonConverter
                {
                    public override bool CanConvert(System.Type objectType)
                    {
                        return objectType == typeof(Statistic);
                    }
                    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
                    {
                        JToken jToken = JToken.Load(reader);

                        Statistic.Type type = jToken["type"].ToObject<Statistic.Type>();

                        switch (type)
                        {
                            case Statistic.Type.BallPossession:
                            case Statistic.Type.PassesPercentage:
                                return new Statistic() { type = type, value = int.Parse(jToken.Value<string>("value").Replace("%", "")) };
                            case Statistic.Type.ShotsOnGoal:
                            case Statistic.Type.ShotsOffGoal:
                            case Statistic.Type.TotalShots:
                            case Statistic.Type.BlockedShots:
                            case Statistic.Type.ShotsInsidebox:
                            case Statistic.Type.ShotsOutsidebox:
                            case Statistic.Type.Fouls:
                            case Statistic.Type.CornerKicks:
                            case Statistic.Type.Offsides:
                            case Statistic.Type.YellowCards:
                            case Statistic.Type.RedCards:
                            case Statistic.Type.GoalkeeperSaves:
                            case Statistic.Type.TotalPasses:
                            case Statistic.Type.PassesAccurate:
                            case Statistic.Type.ExpectedGoals:
                                return new Statistic() { type = type, value = jToken["value"].Type != JTokenType.Null ? jToken.Value<int>("value") : 0 };
                            default:
                                throw new Exception();
                        }

                    }
                    public override bool CanWrite
                    {
                        get { return false; }
                    }
                    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                    {
                        throw new NotImplementedException();
                    }
                }

                public class Team
                {
                    public int id;
                    public required string name;
                    public required string logo;
                }
                [JsonConverter(typeof(StatisticJsonConverter))]
                public class Statistic
                {
                    [JsonConverter(typeof(StringEnumConverter))]
                    public enum Type
                    {
                        [EnumMember(Value = "Shots on Goal")]
                        ShotsOnGoal,
                        [EnumMember(Value = "Shots off Goal")]
                        ShotsOffGoal,
                        [EnumMember(Value = "Total Shots")]
                        TotalShots,
                        [EnumMember(Value = "Blocked Shots")]
                        BlockedShots,
                        [EnumMember(Value = "Shots insidebox")]
                        ShotsInsidebox,
                        [EnumMember(Value = "Shots outsidebox")]
                        ShotsOutsidebox,
                        [EnumMember(Value = "Fouls")]
                        Fouls,
                        [EnumMember(Value = "Corner Kicks")]
                        CornerKicks,
                        [EnumMember(Value = "Offsides")]
                        Offsides,
                        [EnumMember(Value = "Ball Possession")]
                        BallPossession, //string
                        [EnumMember(Value = "Yellow Cards")]
                        YellowCards,
                        [EnumMember(Value = "Red Cards")]
                        RedCards,
                        [EnumMember(Value = "Goalkeeper Saves")]
                        GoalkeeperSaves,
                        [EnumMember(Value = "Total passes")]
                        TotalPasses,
                        [EnumMember(Value = "Passes accurate")]
                        PassesAccurate,
                        [EnumMember(Value = "Passes %")]
                        PassesPercentage, //string
                        [EnumMember(Value = "expected_goals")]
                        ExpectedGoals
                    }

                    public Type type;
                    public int value;                    
                }

                public required Team team;
                public required Statistic[] statistics;
                                
                public int GetBallPossession
                {
                    get
                    {
                        return statistics.First(e => e.type == Statistic.Type.BallPossession).value;
                    }
                }
                public int GetYellowCards
                {
                    get
                    {
                        return statistics.First(e => e.type == Statistic.Type.YellowCards).value;
                    }
                }
                public int GetRedCards
                {
                    get
                    {
                        return statistics.First(e => e.type == Statistic.Type.RedCards).value;
                    }
                }
                public int GetCornerKicks
                {
                    get
                    {
                        return statistics.First(e => e.type == Statistic.Type.CornerKicks).value;
                    }
                }
                public int GetTotalShots
                {
                    get
                    {
                        return statistics.First(e => e.type == Statistic.Type.TotalShots).value;
                    }
                }
                public int GetShotsOnGoal
                {
                    get
                    {
                        return statistics.First(e => e.type == Statistic.Type.ShotsOnGoal).value;
                    }
                }
            }

            public Fixture fixture;
            public League league;
            public Teams teams;
            public Goals goals;
            public Score score;
            //public Event events;
            //public Lineups lineups;
            public Statistics[] statistics;
        }

        public required Data[] response;
    }
}