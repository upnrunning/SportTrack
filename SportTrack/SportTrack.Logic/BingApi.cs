using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SportTrack.Logic
{
    public class BingApi
    {
        private string _responseJSON;
        private int _responseCount = 30;
        const string accessKey = "2226d21693004636a67f2d4561752367";
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/news/search?";

        public async Task<string> BingRequestNews(string query)
        {
            using (var client = new HttpClient())
            { 
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", accessKey);
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["q"] = query; 
                queryString["mkt"] = "en-US";
                queryString["count"] = Convert.ToString(_responseCount);
                string url = uriBase + queryString;
                _responseJSON = await client.GetStringAsync(url);
                return _responseJSON;
            }
        }

    }
}
