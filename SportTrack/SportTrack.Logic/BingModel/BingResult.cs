using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.BingModel
{
    [NotMapped]
   public class BingResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime DatePublished { get; set; }
        public Image Image { get; set; }

    }

}
