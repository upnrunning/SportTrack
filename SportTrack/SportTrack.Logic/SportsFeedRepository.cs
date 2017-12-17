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
        //private string _gameStatsJson;
        private string _overallSchedJson;
        private string _overallStandings;
        private string _divisionStandings;
        private string _conferenceStandings;
        private string _playoffStandings;

       

        public async Task SportsFeedGetDataAsync(string sport, int SeasonYear, string LeagueStructure)

        {
            
                SportsFeedApi sportsFeedApi = new SportsFeedApi();
                //_scoreBoardJson = await sportsFeedApi.RequestScoreBoard(sport, SeasonYear, LeagueStructure, date);

                //_overallSchedJson = await sportsFeedApi.RequestOverallSchedule(sport, SeasonYear, LeagueStructure);
                _overallStandings = await sportsFeedApi.RequestOverallStandings(sport, SeasonYear, LeagueStructure);
                //_divisionStandings = await sportsFeedApi.RequestDivisionStandnings(sport, SeasonYear, LeagueStructure);
                //_conferenceStandings = await sportsFeedApi.RequestConferenceStandings(sport, SeasonYear, LeagueStructure);
                //_playoffStandings = await sportsFeedApi.RequestPlayoffStandings(sport, SeasonYear, LeagueStructure);
                DeserializeJson(_overallSchedJson, _overallStandings, _divisionStandings, _conferenceStandings, _playoffStandings);
                Repository.RequestDates[sport] = DateTime.Now;
            
                  }

        private void DeserializeJson(string overallJSON, string overallStandings, string divisionStandings, string conferenceStandings, string playoffStandings)
        {
            try
            {
                //Repository.ScoreBoardList.Clear();
                //Repository.ScheduleList.Clear();
                Repository.OverallStandings.Clear();
                //Repository.PlayOffStandings.Clear();
                //Repository.DivisionStandings.Clear();
                //Repository.ConferenceStandings.Clear();

                //JObject sportsFeedSchedule = JObject.Parse(overallJSON); // if == null catch exception? (No games were found for this date)
                //IList<JToken> games = sportsFeedSchedule["fullgameschedule"]["gameentry"].Children().ToList();
                //foreach (var item in games)
                //{
                //    GameEntry gameentry = item.ToObject<GameEntry>();
                //    Repository.ScheduleList.Add(gameentry);
                //}

                //JObject scoreBoards = JObject.Parse(scoreboardJSON);
                //IList<JToken> scores = scoreBoards["scoreboard"]["gameScore"].Children().ToList();
                //foreach (var item in scores)
                //{
                //    ScoreBoard scoreboard = item.ToObject<ScoreBoard>();
                //    Repository.ScoreBoardList.Add(scoreboard);
                //}

                JObject overallStand = JObject.Parse(overallStandings);
                IList<JToken> ovStands = overallStand["overallteamstandings"]["teamstandingsentry"].Children().ToList();
                foreach (var item in ovStands)
                {
                    TeamEntryWrapper standing = item.ToObject<TeamEntryWrapper>();
                    Repository.OverallStandings.Add(standing);
                }

                //JObject conferenceStand = JObject.Parse(conferenceStandings);
                //IList<JToken> confStands = conferenceStand["conferenceteamstandings"]["conference"].Children().ToList();
                //foreach (var item in confStands)
                //{
                //    Structure standing = item.ToObject<Structure>();
                //    Repository.ConferenceStandings.Add(standing);
                //}

                //JObject divisionStand = JObject.Parse(divisionStandings);
                //IList<JToken> divisionStands = divisionStand["divisionteamstandings"]["division"].Children().ToList();
                //foreach (var item in divisionStands)
                //{
                //    Structure standing = item.ToObject<Structure>();
                //    Repository.DivisionStandings.Add(standing);
                //}

                //JObject playoffStand = JObject.Parse(playoffStandings);
                //IList<JToken> playoffStands = playoffStand["playoffteamstandings"]["conference"].Children().ToList();
                //foreach (var item in playoffStands)
                //{
                //    Structure standing = item.ToObject<Structure>();
                //    Repository.PlayOffStandings.Add(standing);
                //}
            }

            catch(Exception) { return; }
        }
    }
}
