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

        public void AddGoal(string _Name, string _Description, DateTime _StartingDay, DateTime _LastDay, string _Type)
        {
            using (var context = new localsql())
            {
                Objective task = new Objective
                {
                    Description = _Description,
                    Name = _Name,
                    StartingDay = _StartingDay,
                    LastDay = _LastDay,
                    Type = _Type
                };
                context.Objectives.Add(task);
                context.SaveChanges();
            }
        }
        public void Remove (string _Name)
        {
            using (var context = new localsql())
            {
                Objective task = new Objective();
                foreach (var item in context.Set<Objective>().ToList())
                {
                    if (item.Name.ToString() == _Name)
                    {
                        context.Objectives.Attach(item);
                        context.Objectives.Remove(item);
                        context.SaveChanges();
                    }
                }
             
                
            }
        }
        public void Update(string _Name, string _Description, DateTime _StartingDay, DateTime _LastDay, string _Type)
        {
            using (var context = new localsql())
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
            localsql context = new localsql();
            return context.Set<Objective>().ToList();
        }
        public static List<Objective> ReadAllRow()
        {
            localsql context = new localsql();
            List<Objective> AllTasks = new List<Objective>();
            
            foreach (var item in context.Objectives)
            {
                AllTasks.Add(item);
            }
            return AllTasks;
            
        }
        public static List<User> ReadAllUser()
        {
            localsql context = new localsql();
            List<User> Users = new List<User>();
            foreach (var item in context.User)
            {
                Users.Add(item);
            }
            return Users;
        }
        public bool CheckingLogin(string _login)
        {
            using (localsql a = new localsql())
            {
                foreach (var item in a.User)
                {
                    if (item.Nickname == _login)
                    {
                        return false;
                    }

                    
                }
                return true;
            }
            
        }
        public void AddUser(string _Nickname, string _Name, int _Age, string _Password)
        {
            Random rnd = new Random();
            using (var context = new localsql())
            {
                User task = new User
                {
                    Nickname = _Nickname,
                    Name = _Name,
                    Age = _Age,
                    Password = _Password,
                    Salt = rnd.Next(10000, 1000000).ToString()
                };
                context.User.Add(task);
                context.SaveChanges();
            }
        }

    }
}
