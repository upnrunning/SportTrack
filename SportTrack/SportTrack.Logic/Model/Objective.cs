using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.Model
{
    public class Objective
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartingDay { get; set; }
        public DateTime LastDay { get; set; }
        public String Type { get; set; }
    }
}
