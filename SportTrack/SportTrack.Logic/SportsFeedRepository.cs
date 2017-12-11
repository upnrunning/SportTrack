using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SportTrack.Logic.SportsFeedModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SportTrack.Logic
{
    public class SportsFeedRepository
    {
        private Dictionary<string, DateTime> requestDates;
        private string _scoreBoardJson;
        private string _gameStatsJson;
        private string _overallSchedJson;

        //public List<ScoreBoard> ScoreBoardList { get; set; }
        //public List<GameStats> GameStatsList { get; set; }
        public List<GameEntry> ScheduleList { get; set;}

        public SportsFeedRepository()
        {
            requestDates = new Dictionary<string, DateTime>();   // Dictionary with dates of requests to the server. 
                                                                 // Used to avoid downloading data too often.
            //ScoreBoardList = new List<ScoreBoard>();
            //GameStatsList = new List<GameStats>();
            ScheduleList = new List<GameEntry>();
        }

        public async void GetDataAsync(string sport, int SeasonYear, string LeagueStructure, DateTime date, List<string> additionalParams)

        {
            if (!requestDates.ContainsKey(sport) || requestDates[sport] < DateTime.Now.AddHours(-6))
            {
                requestDates[sport] = DateTime.Now;
                SportsFeedApi sportsFeedApi = new SportsFeedApi();
                _scoreBoardJson = await sportsFeedApi.RequestScoreBoard(sport, SeasonYear, LeagueStructure, date, additionalParams);
                _gameStatsJson = await sportsFeedApi.RequestGameStats(sport, SeasonYear, LeagueStructure, additionalParams);
                _overallSchedJson = await sportsFeedApi.RequestOverallSchedule(sport, SeasonYear, LeagueStructure, additionalParams);
                DeserializeJson(_scoreBoardJson, _gameStatsJson, _overallSchedJson, sport);
            }
            else { } // Do nothing(?)... (Don't know yet what will happen here)
        }

        private void DeserializeJson(string scoreboardJSON, string gamestatsJSON, string overallJSON, string sport)
        {
            JObject sportsFeedSchedule = JObject.Parse(overallJSON); // if == null catch exception? (No games were found for this date)
            IList<JToken> games = sportsFeedSchedule["fullgameschedule"]["gameentry"].Children().ToList();
            foreach (var item in games)
            {
                GameEntry gameentry = item.ToObject<GameEntry>();
                ScheduleList.Add(gameentry);
            }
            

        }
    }
}
