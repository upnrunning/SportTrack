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
        
        private string _scoreBoardJson;
        private string _gameStatsJson;
        private string _overallSchedJson;

       

        public async void SportsFeedGetDataAsync(string sport, int SeasonYear, string LeagueStructure, DateTime date, List<string> additionalParams)

        {
            if (!Repository.RequestDates.ContainsKey(sport) || Repository.RequestDates[sport] < DateTime.Now.AddHours(-6))
            {
                Repository.RequestDates[sport] = DateTime.Now;
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
            Repository.ScoreBoardList.Clear();
            Repository.GameLogsList.Clear();
            Repository.ScheduleList.Clear();

            JObject sportsFeedSchedule = JObject.Parse(overallJSON); // if == null catch exception? (No games were found for this date)
            IList<JToken> games = sportsFeedSchedule["fullgameschedule"]["gameentry"].Children().ToList();
            foreach (var item in games)
            {
                GameEntry gameentry = item.ToObject<GameEntry>();
                Repository.ScheduleList.Add(gameentry);
            }

            JObject scoreBoards = JObject.Parse(scoreboardJSON);
            IList<JToken> scores = scoreBoards["scoreboard"]["gameScore"].Children().ToList();
            foreach(var item in scores)
            {
                ScoreBoard scoreboard = item.ToObject<ScoreBoard>();
                Repository.ScoreBoardList.Add(scoreboard);
            }

            JObject statistic = JObject.Parse(gamestatsJSON);
            IList<JToken> stats = statistic["teamgamelogs"]["gamelogs"].Children().ToList();
            foreach (var item in stats)
            {
                GameLog gamelog = item.ToObject<GameLog>();
                Repository.GameLogsList.Add(gamelog);
            }

        }
    }
}
