using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.SportsFeedModel
{
    //[NotMapped]
    //public class StandingsDivConf
    //{
    //    [JsonProperty("division")]
    //    public Structure Structure { get; set; }

    //    [JsonProperty("conference")]
    //    private Structure Structure2 { set { Structure = value; } }
    //}

    //[NotMapped]
    //public class Structure
    //{
    //    public TeamEntry[] Standings { get; set; }
    //}


        [NotMapped]
    public class Structure
    {
        [JsonProperty("@name")]
        public string Name { get; set; }
        [JsonProperty("teamentry")]
        public TeamEntry[] Standings { get; set; }
    }

    [NotMapped]
    public class TeamEntry
    {
        public Team Team { get; set; }
        public int Rank { get; set; }
        [JsonProperty("stats")]
        Dictionary<string, StatType> StatTypes { get; set; }
    }

    //[NotMapped]
    //public class Info
    //{
    //    public KeyValuePair<string,StatType> GamesPlayed { get; set; }
    //    [JsonProperty("stats")]
        
    //}
}
