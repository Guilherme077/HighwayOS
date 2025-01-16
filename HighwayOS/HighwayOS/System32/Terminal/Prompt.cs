using Cosmos.Core;
using Cosmos.System;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace HighwayOS.System32.Terminal
{
    internal class Prompt : Task
    {
        List<string> BufferLines = new List<string>();
        string Line;
        (int x, int y) LinePos;
        int LineSelected = -1;
        bool WriteNewLine = true;
        string UserMsg = "NoUser" + " -> ";
        
        public override string Name() { return "Prompt"; }
        public override bool AllowOnlyOne() { return true; }
        public override void Execute()
        {

            if (WriteNewLine)
            {
                StartLine();
                WriteNewLine = false;
            }


            ConsoleKeyEx key = KeyboardManager.ReadKey().Key;
            LinePos = Console.GetCursorPosition();

            switch (key)
            {
                case ConsoleKeyEx.Enter:
                    string command = Line;
                    BufferLines.Add(Line);
                    Line = "";
                    LineSelected = -1;
                    Console.SetCursorPosition(0, LinePos.y + 1);
                    CmdProcessor.Process(command.Split(" "));
                    WriteNewLine = true;

                    break;

                case ConsoleKeyEx.Backspace:
                    Console.SetCursorPosition(UserMsg.Length + Line.Length - 1, LinePos.y);
                    Console.Write(" ");
                    StartLine();
                    Line = Line.Substring(0, Line.Length - 1);
                    Console.Write(Line);
                    break;

                case ConsoleKeyEx.UpArrow:
                    if(LineSelected == -1) LineSelected = BufferLines.Count;

                    if (!(LineSelected == 0 || BufferLines.Count == 0))
                    {
                        LineSelected--;
                       
                        for (int i = UserMsg.Length; i < UserMsg.Length + Line.Length; i++)
                        {
                            Console.SetCursorPosition(i, LinePos.y);
                            Console.Write(" ");
                        }
                        Line = BufferLines[LineSelected];
                        StartLine();
                        Console.Write(Line);
                    }
                    
                    break;

                case ConsoleKeyEx.DownArrow:
                    if (LineSelected == -1) LineSelected = BufferLines.Count;

                    if (!(LineSelected >= BufferLines.Count -1 || BufferLines.Count == 0))
                    {
                        LineSelected++;

                        for (int i = UserMsg.Length; i < UserMsg.Length + Line.Length; i++)
                        {
                            Console.SetCursorPosition(i, LinePos.y);
                            Console.Write(" ");
                        }
                        Line = BufferLines[LineSelected];
                        StartLine();
                        Console.Write(Line);
                    }
                    
                    break;

                default:
                    Console.SetCursorPosition(LinePos.x, LinePos.y);
                    Line = Line + KeyboardABNT2.ConvertToABNT((int)key, KeyboardManager.ShiftPressed);
                    Console.Write(KeyboardABNT2.ConvertToABNT((int)key, KeyboardManager.ShiftPressed));
                    break;
            }

            



            //Console.Write("-> ");
            //String[] console = Console.ReadLine().Split(" ");
            //CmdProcessor.Process(console);
            //Console.WriteLine("");
        }

        private void StartLine()
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.Write(UserMsg);
            Console.SetCursorPosition(UserMsg.Length, Console.GetCursorPosition().Top);
        }

        public override void Command(string[] args)
        {
            if (args.Length == 1)
            {
                UserMsg = "NoUser" + " -> ";
            }
            else 
            {
                UserMsg = args[1] + " -> ";  
            }
        }

        public override void OnStart()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("|   The Prompt has started!   |");
            Console.WriteLine("| Now, you can type commands! |");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.Write(UserMsg);
            Console.SetCursorPosition(UserMsg.Length, Console.GetCursorPosition().Top);
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
                Console.WriteLine("  shutdown                  - Shutdown the HighwayOS");
                Console.WriteLine("           reboot           - Restart the HighwayOS");
                Console.WriteLine("  help                      - List the main commands");
                Console.WriteLine("       all                  - List the main commands");
                Console.WriteLine("  clear                     - Clear the terminal");
                Console.WriteLine("  sysinfo                   - Show info about the PC");
                Console.WriteLine("  graphicmode               - Start Graphical mode");
                Console.WriteLine("  user                      - User options");
                Console.WriteLine("       login [user] [pass]  - Login as an user in HighwayOS");
                Console.WriteLine("       logout               - Logout of the logged user");
                Console.WriteLine("  task                      - Task Manager options");
                Console.WriteLine("       init [task]          - Init a task");
                Console.WriteLine("       kill [task]          - Close a task");
                Console.WriteLine("       all                  - Show all tasks that are running");
                Console.WriteLine("  network                   - Network options");
                Console.WriteLine("          dhcp              - Define a IP to OS");
                Console.WriteLine("          showip            - Shows HigwayhOS IP");
            }
            
        }
    }
}
