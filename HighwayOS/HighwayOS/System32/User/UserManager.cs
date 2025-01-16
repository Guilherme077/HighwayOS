using HighwayOS.System32.Terminal;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.User
{
    internal class UserManager : Task
    {
        public override bool AllowOnlyOne() { return true; }
        public override string Name() { return "UserManager"; }

        public User LoggedUser { get; private set; }

        public List<User> Users { get; private set; }

        public UserManager() 
        {
            Users = new List<User>() { new User("admin", "admin", true), new User("guest", "123", false) };
        }

        public override void OnStart()
        {
           Console.WriteLine("UserManager Started");
            
        }

        public override void Execute()
        {
            if (LoggedUser == null)
            {
                Task_Manager.GetTask("Prompt").Command(new string[] { "notlogged"});
            }
            else 
            {
                Task_Manager.GetTask("Prompt").Command(new string[] { "logged", LoggedUser.Name });
            }

            
        }


        public void LogIn(string username, string password)
        {
            foreach (var user in Users)
            {
                //This method is not secure
                if (user.Name == username && user.Password == password) {
                    LoggedUser = user;
                    var prompt = Task_Manager.GetTask("Prompt");
                    Console.WriteLine($"LogIn: You have logged in as {user.Name}");
                    Task_Manager.RestartTaskList = true;
                }
            }
        }

        public override void Command(string[] args)
        {
            if(args[1] == "loggin")
            {
                Console.WriteLine($"LogIn: Trying to login as {args[2]}");
                LogIn(args[2], args[3]);
                

            } else if (args[1] == "logout")
            {
                Console.WriteLine($"Good bye {LoggedUser.Name}");
                LoggedUser = null;
                
            }
            else
            {
                Console.WriteLine("User: unknown command");
            }
        }
    }
}
