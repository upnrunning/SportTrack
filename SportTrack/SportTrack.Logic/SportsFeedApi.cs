using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportTrack.Logic
{
    

    public class InvalidStructureException : Exception { }
    public class InvalidDateException : Exception { }

    public class SportsFeedApi
    {

        private Dictionary<string, string> _sportStats = new Dictionary<string, string>  // which parameters to get for each sport
    {
        {"nba", "W,L,PTS,PTSA" },
        {"nhl", "W,L,GF,GA,Pts"},
        {"nfl", "W,L,T,PF,PA"},
        {"mlb", "W,L,RF,RA" }
    };

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private string FormatStructure(int seasonYear, string leagueStructure)
        {
            if (seasonYear > DateTime.Now.Year + 1) throw new InvalidStructureException();

            string formatted;
            if (leagueStructure == "regular") formatted = seasonYear.ToString() + "-" + (seasonYear + 1).ToString() + "-regular";
            else if (leagueStructure == "playoff") formatted = seasonYear.ToString() + "-playoff";
            else if (leagueStructure == "current" || leagueStructure == "latest" || leagueStructure == "upcoming") formatted = leagueStructure;
            else throw new InvalidStructureException();

            return formatted;
        }

        private string FormatDate(DateTime date)
        {
            if (date > DateTime.Now || date.Year < 2007) throw new InvalidDateException(); // API doesn't have info about competitions before 2007
            string formatted = date.ToString("yyyyMMdd");
            return formatted;

        }

        public async Task<string> RequestDailySchedule(string sport, int seasonYear, string leagueStructure, DateTime fordate, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                // Here goes the processing of all optional parameters...
                string structure = FormatStructure(seasonYear, leagueStructure);
                string date = FormatDate(fordate);
                string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/daily_game_schedule.json?fordate={date}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;
            }
        }

        public async Task<string> RequestScoreBoard(string sport, int seasonYear, string leagueStructure, DateTime fordate, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                // Here goes the processing of all optional parameters...
                string structure = FormatStructure(seasonYear, leagueStructure);
                string date = FormatDate(fordate);
                string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/scoreboard.json?fordate={date}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;
            }
        }

        public async Task<string> RequestGameStats(string sport, int seasonYear, string leagueStructure, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                // Here goes the processing of all optional parameters...
                string structure = FormatStructure(seasonYear, leagueStructure);
                string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/team_gamelogs.json?team=bos";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;
            }
        }

        public async Task<string> RequestOverallSchedule(string sport, int seasonYear, string leagueStructure, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                    // Here goes the processing of all optional parameters...
                    string structure = FormatStructure(seasonYear, leagueStructure);
                    string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/full_game_schedule.json";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                    string JsonEncodedResponse = await client.GetStringAsync(url);
                    return JsonEncodedResponse;
                
            }
        }

        public async Task<string> RequestOverallStandings(string sport, int seasonYear, string leagueStructure, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                
                // Here goes the processing of all optional parameters...
                string structure = FormatStructure(seasonYear, leagueStructure);
                string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/overall_team_standings.json?teamstats="+_sportStats[sport];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;

            }
        }

        public async Task<string> RequestConferenceStandings(string sport, int seasonYear, string leagueStructure, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                // Here goes the processing of all optional parameters...
                string structure = FormatStructure(seasonYear, leagueStructure);
                string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/conference_team_standings.json?teamstats=" + _sportStats[sport];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;

            }
        }

        public async Task<string> RequestDivisionStandnings(string sport, int seasonYear, string leagueStructure, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                // Here goes the processing of all optional parameters...
                string structure = FormatStructure(seasonYear, leagueStructure);
                string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/division_team_standings.json?teamstats=" + _sportStats[sport];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;

            }
        }

        public async Task<string> RequestPlayoffStandings(string sport, int seasonYear, string leagueStructure, List<string> additionalParams)
        {
            using (var client = new HttpClient())
            {
                // Here goes the processing of all optional parameters...
                string structure = FormatStructure(seasonYear, leagueStructure);
                string url = $"https://api.mysportsfeeds.com/v1.1/pull/{sport}/{structure}/playoff_team_standings.json?teamstats=" + _sportStats[sport];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;
            }
        }

    }
}
