using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.BingModel
{
    [NotMapped]
    public class Provider
    {
        public string Name { get; set; }
        public Image Image { get; set; }
    }
}
