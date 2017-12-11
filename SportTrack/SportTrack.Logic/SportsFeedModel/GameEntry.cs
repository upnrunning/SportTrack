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
    
    public class GameEntry
    {
        public int Id { get; set; }
        public string ScheduleStatus { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Team AwayTeam { get; set; }
        public Team HomeTeam { get; set; }
        public string Location { get; set; }
    }

}
