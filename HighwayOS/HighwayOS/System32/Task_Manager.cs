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
        public static List<int> Task_ID { get; private set; } = new List<int>();
        public static List<Task> AllTasks { get; private set; } = new List<Task>();
        public static int Task_IDCount = 0;
        //[ManifestResourceStream(ResourceName = "SoundTest.SystemFiles.Task_manager.bmp")] public static byte[] Solitaire;
        //public static Bitmap based = new Bitmap(Solitaire);
        public static void Task_manager()
        {
            
            //In here we have a foreach which goes thru every item in the Tasks list
            //ImprovedVBE.DrawImageAlpha(based, 0, 50);
            foreach (Task task in Task_Running)
            {
                task.Execute();
            }
        }

        public static void CreateTask(Task task)
        {
            Task_Running.Add(task);
            Task_IDCount++;
            Task_ID.Add(Task_IDCount);
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

            foreach(Task task in Task_Running)
            {
                list.Add(task.Name());
            }

            return list; 
        }

        public static void DeleteTask(int ID)
        {
            foreach(Task task in Task_Running)
            {
                if(Task_ID.IndexOf(ID) == Task_Running.IndexOf(task))
                {
                    Task_Running.Remove(task);
                    Task_ID.Remove(ID);
                }
            }
        }

        public static bool DeleteTask(String name)
        {
            bool deleted = false;
            foreach (Task task in Task_Running)
            {
                if(task.Name() == name)
                {
                    Task_Running.Remove(task);
                    Task_ID.RemoveAt(Task_Running.IndexOf(task));
                    deleted = true;
                }
            }

            return deleted;
        }

        public static void AddAllTasks()
        {
            AllTasks.Add(new GraphicManager());
            AllTasks.Add(new Calc());
            AllTasks.Add(new CmdProcessor());
        }
    }
}
