using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.SportsFeedModel
{
    public class Context : DbContext 
    {
        public DbSet<GameEntry> GameEntry { get; set; }
        public DbSet<GameStats> GameStats { get; set; }
        public DbSet<ScoreBoard> ScoreBoard { get; set; }

    }
}
