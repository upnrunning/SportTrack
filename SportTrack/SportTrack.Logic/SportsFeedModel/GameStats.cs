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
    public class GameLog
    {
        [JsonProperty("game")]
        public GameEntry GameEntry { get; set; }
        public Team Team { get; set; }
        [JsonProperty("stats")]
        Dictionary<string, StatType> Statistics { get; set; }
    }

    [NotMapped]
    public class StatType
    {
        [JsonProperty("@abbreviation")]
        public string Abbreviation { get; set; }
        [JsonProperty("#text")]
        public double Value { get; set; }
    }

}
