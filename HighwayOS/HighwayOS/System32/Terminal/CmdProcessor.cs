using Cosmos.Core;
using HighwayOS.System32.Graphical;
using HighwayOS.System32.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.Terminal
{
    internal class CmdProcessor : Task
    {
        public override string Name(){ return "CmdProcessor"; }
        public override void Execute()
        {
            Console.Write("-> ");
            String[] console = Console.ReadLine().Split(" ");
            Process(console);
            Console.WriteLine("");
        }

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
                    Task_Manager.CreateTask(new GraphicManager());
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "network":
                    Network(args);
                    break;
                case "deltask":
                    Task_Manager.DeleteTask(args[1]);
                    Console.WriteLine($"Trying to Delete the {args[1]} task...");
                    break;
                case "inittask":
                    Task_Manager.CreateTask(args[1]);
                    Console.WriteLine($"Trying to Create the {args[1]} task...");
                    break;
                case "runningtasks":
                    List<String> list = Task_Manager.runningList();
                    foreach(String str in list)
                    Console.WriteLine(str);
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
                Console.WriteLine("  shutdown          - Shutdown the HighwayOS");
                Console.WriteLine("  help              - Show this message");
                Console.WriteLine("  sysinfo           - Show info about the PC");
                Console.WriteLine("  graphicmode       - Start Graphical mode");
                Console.WriteLine("  runningtasks      - Show all the process that are running");
            }
            else if (args[1] == "all" || args[1] == "-a")
            {
                Console.WriteLine("HELP: List of all commands.");
                Console.WriteLine("  shutdown          - Shutdown the HighwayOS");
                Console.WriteLine("  help              - List the main commands");
                Console.WriteLine("       all          - List the main commands");
                Console.WriteLine("  sysinfo           - Show info about the PC");
                Console.WriteLine("  graphicmode       - Start Graphical mode");
                Console.WriteLine("  runningtasks      - Show all the process that are running");
                Console.WriteLine("  inittask [task]   - Init a task");
                Console.WriteLine("  deltask [task]    - Close a task");
                Console.WriteLine("  clear             - clear the terminal");
                Console.WriteLine("  network           - Network options");
                Console.WriteLine("          dhcp      - define a IP to SO");
                Console.WriteLine("          showip    - shows HigwayhOS IP");
            }
            
        }

        private void Network(String[] args)
        {
            if (args[1] == "dhcp" || args[1] == "-d")
            {
                Console.WriteLine("Starting the connection...");
                Console.WriteLine("Trying to obtain IP by DHCP");
                try
                {
                    NetworkManager.ConfigIPv4Auto();
                    Console.WriteLine("Connected");
                }
                catch {
                    Console.WriteLine("Failed");
                }
                
            }
            if (args[1] == "showip" || args[1] == "-s")
            {
                Console.WriteLine(NetworkManager.GetIP());
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
