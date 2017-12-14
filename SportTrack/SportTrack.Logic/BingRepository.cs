using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportTrack.Logic.BingModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SportTrack.Logic
{
    [NotMapped]
    public class BingRepository
    {
        
        private string _newsJSON;

        public List<BingResult> SearchResults { get; set; }

        public BingRepository()
        {
            SearchResults = new List<BingResult>();
        }

        public async void GetBingDataAsync(string query)
        {
            BingApi bing = new BingApi();
            _newsJSON = await bing.BingRequestNews(query);
            JObject results = JObject.Parse(_newsJSON);
            IList<JToken> bingResults = results["value"].Children().ToList();
            foreach (var item in bingResults)
            {
                BingResult res = item.ToObject<BingResult>();
                SearchResults.Add(res);
            }
        }

    } 
}