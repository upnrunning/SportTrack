using SportTrack.Logic.BingModel;
using SportTrack.Logic.SportsFeedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic
{
    public class Repository
    {
        public static Dictionary<string, DateTime> RequestDates { get; set; }
        public static List<ScoreBoard> ScoreBoardList { get; set; }
        public static List<GameLog> GameLogsList { get; set; }
        public static List<GameEntry> ScheduleList { get; set; }
        public static List<BingResult> SearchResults { get; set; }
        public static List<TeamEntry> OverallStandings { get; set; }
        public static List<Structure> DivisionStandings { get; set; }
        public static List<Structure> ConferenceStandings { get; set; }
        public static List<Structure> PlayOffStandings { get; set; }

        public Repository()
        {
            RequestDates = new Dictionary<string, DateTime>();   // Dictionary with dates of requests to the server. 
                                                                 // Used to avoid downloading data too often.
            ScoreBoardList = new List<ScoreBoard>();
            GameLogsList = new List<GameLog>();
            ScheduleList = new List<GameEntry>();
            SearchResults = new List<BingResult>();
            OverallStandings = new List<TeamEntry>();
            DivisionStandings = new List<Structure>();
            ConferenceStandings = new List<Structure>();
            PlayOffStandings = new List<Structure>();
        }
    }
}
