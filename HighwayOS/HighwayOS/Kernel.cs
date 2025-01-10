using Cosmos.System;
using HighwayOS.System32;
using HighwayOS.System32.Graphical;
using HighwayOS.System32.Terminal;
using System;
using Console = System.Console;
using Sys = Cosmos.System;


namespace HighwayOS
{
    public class Kernel : Sys.Kernel
    {
        CmdProcessor CmdProcessor = new CmdProcessor();
        public static bool GraphicMode = false;

        

        protected override void BeforeRun()
        {
            Task_Manager.AddAllTasks();
            Console.Clear();
            Console.WriteLine("Cosmos booted successfully.");
            Console.WriteLine("Welcome to HighwayOS");
            Console.WriteLine("Type a command!");
            Task_Manager.CreateTask(CmdProcessor);

        }

        protected override void Run()
        {
            
            

            Task_Manager.Task_manager();

            if (KeyboardManager.AltPressed)
            {
                Task_Manager.DeleteTask("GraphicManager");
                GraphicManager.Stop();

            }
            

        }

        public static void Shutdown()
        {
            Sys.Power.Shutdown();
        }




    }
}
