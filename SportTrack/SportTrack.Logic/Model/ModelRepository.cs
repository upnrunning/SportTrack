using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportTrack.Logic.Model
{
    public class ModelRepository
    {

        public void AddGoal(string Name, string Description, DateTime StartingDay, DateTime LastDay, string Type)
        {
            using (var context = new Context())
            {
                Objective task = new Objective
                {
                    Description = Description,
                    Name = Name,
                    StartingDay = StartingDay,
                    LastDay = LastDay,
                    Type = Type
                };
                context.Objectives.Add(task);
                context.SaveChanges();
            }
        }
        public void Remove (string _Name)
        {
            using (var context = new Context())
            {
                Objective task = new Objective
                {
                    Name = _Name
                };
                context.Objectives.Attach(task);
                context.Objectives.Remove(task);
                context.SaveChanges();
            }
        }
        public void Update(string _Name, string _Description, DateTime _StartingDay, DateTime _LastDay, string _Type)
        {
            using (var context = new Context())
            {
                Objective task = context.Objectives
                                   .Where(c => c.Name == _Name)
                                   .FirstOrDefault();
                task.Name = _Name;
                task.Description = _Description;
                task.StartingDay = _StartingDay;
                task.LastDay = _LastDay;
                task.Type = _Type;
                context.SaveChanges(); 
            }
        }
        public IEnumerable<Objective> GetGoals()
        {
            Context context = new Context();
            return context.Set<Objective>().ToList();
        }
        public static List<Objective> ReadAllRow()
        {
            Context context = new Context();
            List<Objective> AllTasks = new List<Objective>();
            
            foreach (var item in context.Objectives)
            {
                AllTasks.Add(item);
            }
            return AllTasks;
            
        }

    }
}
