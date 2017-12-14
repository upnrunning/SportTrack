using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.BingModel
{
    [NotMapped]
    public class Image
    {
        public ThumbNail ThumbNail { get; set; }
    }

    [NotMapped]
    public class ThumbNail
    {
        public string ContentUrl { get; set; }
    }
}
