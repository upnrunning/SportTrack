using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.SportsFeedModel
{
    [NotMapped]
    public class Standings
    {

    }

    [NotMapped]
    public class TeamEntry
    {
        public Team Team { get; set; }
        public int Rank { get; set; }
        [JsonProperty("stats")]
        public Info Info;
    }

    [NotMapped]
    public class Info
    {
        public KeyValuePair<string,StatType> GamesPlayed { get; set; }
        [JsonProperty("stats")]
        Dictionary<string, StatType> StatTypes { get; set; }
    }
}
