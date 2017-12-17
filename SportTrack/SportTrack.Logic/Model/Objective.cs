using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.Model
{
    public class Objective
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartingDay { get; set; }
        public DateTime LastDay { get; set; }
        public String Type { get; set; }
    }
}
