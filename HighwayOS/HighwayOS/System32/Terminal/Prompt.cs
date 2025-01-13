using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.Terminal
{
    internal class Prompt : Task
    {
        public override string Name() { return "Prompt"; }
        public override bool AllowOnlyOne() { return true; }
        public override void Execute()
        {
            Console.Write("-> ");
            String[] console = Console.ReadLine().Split(" ");
            CmdProcessor.Process(console);
            Console.WriteLine("");
        }

        public override void OnStart()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("|   The Prompt has started!   |");
            Console.WriteLine("| Now, you can type commands! |");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        }


    }

    public static class PromptActions
    {
        public static void ShowSysInfo()
        {
            Console.WriteLine("System Information:");
            Console.WriteLine($"Memory: {CPU.GetAmountOfRAM()} MB");
            Console.WriteLine($"CPU: {CPU.GetCPUVendorName()}");
            Console.WriteLine($"System: HighwayOS Alpha");
        }

        public static void ShowHelp(String[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine("HELP: List of main commands. To show all commands available, type 'help all'");
                Console.WriteLine("  shutdown          - Shutdown the HighwayOS");
                Console.WriteLine("  help              - Show this message");
                Console.WriteLine("  sysinfo           - Show info about the PC");
                Console.WriteLine("  graphicmode       - Start Graphical mode");
                Console.WriteLine("  task all          - Show all the process that are running");
            }
            else if (args[1] == "all" || args[1] == "-a")
            {
                Console.WriteLine("HELP: List of all commands.");
                Console.WriteLine("  shutdown          - Shutdown the HighwayOS");
                Console.WriteLine("  help              - List the main commands");
                Console.WriteLine("       all          - List the main commands");
                Console.WriteLine("  clear             - clear the terminal");
                Console.WriteLine("  sysinfo           - Show info about the PC");
                Console.WriteLine("  graphicmode       - Start Graphical mode");
                Console.WriteLine("  task              - Task Manager options");
                Console.WriteLine("       init [task]  - Init a task");
                Console.WriteLine("       kill [task]  - Close a task");
                Console.WriteLine("       all          - Show all tasks that are running");
                Console.WriteLine("  network           - Network options");
                Console.WriteLine("          dhcp      - define a IP to SO");
                Console.WriteLine("          showip    - shows HigwayhOS IP");
            }

        }
    }
}
