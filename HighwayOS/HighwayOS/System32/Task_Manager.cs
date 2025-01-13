using Cosmos.HAL.Drivers.Video.SVGAII;
using Cosmos.System.Graphics;
using HighwayOS.System32.Graphical;
using HighwayOS.System32.GeneralApplications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayOS.System32.Terminal;

namespace HighwayOS.System32
{
    public class Task_Manager
    {
        private static List<Task> Task_Running = new List<Task>();
        public static List<Task> AllTasks { get; private set; } = new List<Task>();
        private static bool RestartTaskList;
        public static Task Running;
        public static void Task_manager()
        {
            
            //Execute all the tasks in Task_Running list
            foreach (Task task in Task_Running)
            {
                Running = task;
                task.Execute();
                if (RestartTaskList)
                {
                    RestartTaskList = false;
                    break;
                }
            }
        }

        public static void CreateTask(Task task)
        {
            if (task.AllowOnlyOne() && IsTaskRunning(task))
            {
                Console.WriteLine($"ERROR: {task.Name()} is already running and accepts only one excecution.");
            }
            else
            {
                Task_Running.Add(task);
                task.OnStart();
            }
            
        }

        public static bool IsTaskRunning(Task task)
        {
            foreach(Task t in Task_Running)
            {
                if(t.Name() == task.Name())
                {
                    return true;
                }
            }
            return false;
        }

        public static void CreateTask(String taskName)
        {
            foreach(Task task in AllTasks)
            {
                if (task.Name().Equals(taskName))
                {
                    CreateTask(task);
                    
                }
                
            }
        }
        public static List<String> runningList()
        {
            List<String> list = new List<String>();

            for(int i = 0; i < Task_Running.Count(); i++)
            {
                if (Task_Running[i] == Running) list.Add(Task_Running[i].Name() + "*");
                else list.Add(Task_Running[i].Name());
            }

            return list; 
        }

        public static void DeleteTask(String name)
        {
            foreach (Task task in Task_Running)
            {
                if(task.Name().Equals(name))
                {
                    try
                    {
                        RestartTaskList = true;
                        Task_Running.Remove(task);
                        break;
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                }
            }

        }

        public static void AddAllTasks()
        {
            AllTasks.Add(new GraphicManager());
            AllTasks.Add(new Calc());
            AllTasks.Add(new Prompt());
        }

        public static void Command(String[] args)
        {
            switch (args[1])
            {
                case "init":
                    Console.WriteLine($"Trying to Create the {args[2]} task...");
                    Task_Manager.CreateTask(args[2]);
                    break;

                case "kill":
                    Console.WriteLine($"Trying to Kill the {args[2]} task...");
                    try
                    {
                        DeleteTask(args[2]);
                    }
                    catch { }
                    break;

                case "all":
                    Console.WriteLine("ACTIVE TASKS:");
                    foreach (String str in runningList())
                        Console.WriteLine(str);
                    break; //This is important avoid closed tasks load
            }
        }
    }
}
