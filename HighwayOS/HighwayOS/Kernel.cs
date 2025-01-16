using Cosmos.System;
using HighwayOS.System32;
using HighwayOS.System32.GeneralApplications;
using HighwayOS.System32.Graphical;
using HighwayOS.System32.Terminal;
using System;
using Console = System.Console;
using Sys = Cosmos.System;


namespace HighwayOS
{
    public class Kernel : Sys.Kernel
    {
        
        public static bool GraphicMode = false;

        

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Cosmos booted successfully.");
            Task_Manager.AddAllTasks();
            Task_Manager.CreateTask("UserManager");
            Console.WriteLine("Welcome to HighwayOS");
            Console.WriteLine();
            Task_Manager.CreateTask(new Prompt());

        }

        protected override void Run()
        {
            
            

            Task_Manager.Task_manager(); //Run the tasks

            if (KeyboardManager.AltPressed)
            {
                Task_Manager.CreateTask(new Prompt());
            }
            

        }

        public static void Shutdown(string[] args)
        {
            
            if (args.Length <= 1) 
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("|                             |");
                Console.WriteLine("|        SHUTTING DOWN        |");
                Console.WriteLine("|                             |");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Sys.Power.Shutdown(); 
            }
            else if (args[1] == "reboot" || args[1] == "-r") 
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("|                             |");
                Console.WriteLine("|          REBOOTING          |");
                Console.WriteLine("|                             |");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Sys.Power.Reboot(); 
            } 
            else { Console.WriteLine("ERROR: Unknown command. Use 'shutdown' or 'shutdown -r'"); }
        }
    }
}
