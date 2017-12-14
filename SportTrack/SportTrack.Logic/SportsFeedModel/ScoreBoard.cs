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


    public class ScoreBoard
    {
        [JsonProperty("game")]
        public GameEntry GameEntry { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        [JsonProperty("periodSummary")]
        public PeriodSummary PeriodSummary { get; set; }
        [JsonProperty("quarterSummary")]
        private PeriodSummary QuarterSummary{ set {PeriodSummary = value; } } // Wrapper for JSONDeserializer
    }


    [NotMapped]
    public class PeriodSummary
    {
        [JsonProperty("period")]
        public Period[] Periods { get; set; }

        [JsonProperty("quarter")]
        private Period[] Quarters { set { Periods = value; }  }
    }

    [NotMapped]
    public class Period
    {
        [JsonProperty("@number")]
        public int Number { get; set; }
        public int AwayScore { get; set; }
        public int HomeScore { get; set; }
    }
}
