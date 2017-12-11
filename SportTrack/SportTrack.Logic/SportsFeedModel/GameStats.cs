using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.SportsFeedModel
{
    [NotMapped]
    public class GameStats
    {
        public GameEntry GameEntry { get; set; }
        public Team Team { get; set; }
    }

    public class GameStatsBasket : GameStats // starting from here - specific stats for each sport
    {

    }

    public class GameStatsHockey : GameStats
    {

    }

    public class GameStatsFootball : GameStats
    {

    }

    public class GameStatsBaseball : GameStats
    {

    }

}
