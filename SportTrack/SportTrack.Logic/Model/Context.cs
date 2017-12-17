using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.Model
{
    public class localsql : DbContext
    {
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<User> User { get; set; }
        public localsql() : base("localsql")
        {

        }
       

    }
}
