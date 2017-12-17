using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SportTrack.Logic.BingModel;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace SportTrack.Logic
{
    [NotMapped]
    public class BingRepository
    {
        
        private string _newsJSON;

        public async Task GetBingDataAsync(string query)
        {

            try {
                Repository.SearchResults.Clear();
                Repository.RequestDates[query] = DateTime.Now;
                BingApi bing = new BingApi();
                _newsJSON = await bing.BingRequestNews(query);
                JObject results = JObject.Parse(_newsJSON);
                IList<JToken> bingResults = results["value"].Children().ToList();
                Repository.SearchResults.Clear();
                foreach (var item in bingResults)
                {
                    BingResult res = item.ToObject<BingResult>();
                    Repository.SearchResults.Add(res);
                }

           
            }
            
            catch (Exception) { return; }

            }

    } 
}