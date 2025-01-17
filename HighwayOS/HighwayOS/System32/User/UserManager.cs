﻿using HighwayOS.System32.Terminal;
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
        public override string CmdName(){ return "user"; }

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
                Task_Manager.GetTask("Prompt").Command(new string[] { "msg"});
            }
            else 
            {
                Task_Manager.GetTask("Prompt").Command(new string[] { "msg", LoggedUser.Name });
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
            if(args[1] == "login")
            {
                Console.WriteLine($"LogIn: Trying to login as {args[2]}");
                LogIn(args[2], args[3]);
                

            } else if (args[1] == "logout")
            {
                Console.WriteLine($"Good bye {LoggedUser.Name}");
                LoggedUser = null;
                
            } else if (args[1] == "help")
            {
                Console.WriteLine("USER HELP:");
                Console.WriteLine(" user ");
                Console.WriteLine("      login [user] [pass]  - Login at HighwayOS as an user");
                Console.WriteLine("      logout               - Logout from the current logged user");
            }
            else
            {
                Console.WriteLine("User: unknown command. Type 'user help'");
            }
        }
    }
}
