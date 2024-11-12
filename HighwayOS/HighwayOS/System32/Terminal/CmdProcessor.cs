using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.Terminal
{
    internal class CmdProcessor
    {
        public void Process(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            var command = args[0].ToLower();

            switch (command)
            {
                case "shutdown":
                    Kernel.Shutdown();
                    break;
                case "help":
                    ShowHelp(args);
                    break;
                case "sysinfo":
                    ShowSysInfo();
                    break;
                case "graphicmode":
                    Task_Manager.Task_Running.Add("GraphicManager");
                    break;
                case "clear":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine($"ERROR: '{command}' is not a valid command");
                    Console.WriteLine($"Type 'help' for help =D");
                    break;
            }
        }

        private void ShowHelp(String[] args)
        {
            if(args.Length == 1) 
            {
                Console.WriteLine("HELP: List of main commands. To show all commands available, type 'help all'");
                Console.WriteLine("  shutdown        - Shutdown the HighwayOS");
                Console.WriteLine("  help            - Show this message");
                Console.WriteLine("  sysinfo         - Show info about the PC");
                Console.WriteLine("  graphicmode     - Start Graphical mode");
            }
            else if (args[1] == "all")
            {
                Console.WriteLine("HELP: List of all commands.");
                Console.WriteLine("  shutdown        - Shutdown the HighwayOS");
                Console.WriteLine("  help            - Show this message");
                Console.WriteLine("  sysinfo         - Show info about the PC");
                Console.WriteLine("  graphicmode     - Start Graphical mode");
                Console.WriteLine("  clear           - clear the terminal");
            }
            
        }
        private void ShowSysInfo()
        {
            Console.WriteLine("System Information:");
            Console.WriteLine($"Memory: {CPU.GetAmountOfRAM()} MB");
            Console.WriteLine($"CPU: {CPU.GetCPUVendorName()}");
            Console.WriteLine($"System: HighwayOS Alpha");
        }

    }
}
