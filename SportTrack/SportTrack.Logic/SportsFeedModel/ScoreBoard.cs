using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.SportsFeedModel
{
    [NotMapped]
    public class ScoreBoard
    {
        public GameEntry GameEntry { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }

    [NotMapped]
    public class ScoreBoardBasket : ScoreBoard
    {

    }

    [NotMapped]
    public class ScoreBoardHockey : ScoreBoard
    {

    }
    
    [NotMapped]
    public class ScoreBoardFootball : ScoreBoard
    {

    }

    [NotMapped]
    public class ScoreBoardBaseball : ScoreBoard
    {

    }
}
