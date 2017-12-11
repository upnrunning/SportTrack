using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.SportsFeedModel
{
    [NotMapped]
    public class Team
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
