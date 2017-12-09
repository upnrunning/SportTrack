using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportTrack.Logic
{
    public class SportsFeedApi
    {

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public async Task<string> Request(string sport)
        {
            using (var client = new HttpClient())
            {
                string url = "https://api.mysportsfeeds.com/v1.1/pull/" + sport + "/2017-2018-regular/cumulative_player_stats.json?playerstats=G,A,Pts,Sh";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode("upnrunning" + ":" + "teamprojectsharp"));
                string JsonEncodedResponse = await client.GetStringAsync(url);
                return JsonEncodedResponse;
            }
            }
        }
    }
