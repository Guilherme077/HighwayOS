using HighwayOS.System32.Terminal;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Text;
using Sys = Cosmos.System;


namespace HighwayOS
{
    public class Kernel : Sys.Kernel
    {
        CmdProcessor CmdProcessor = new CmdProcessor();
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Cosmos booted successfully.");
            Console.WriteLine("Welcome to HighwayOS");
            Console.WriteLine("Type a command!");

        }

        protected override void Run()
        {
            Console.Write("-> ");
            String[] console = Console.ReadLine().Split(" ");
            CmdProcessor.Process(console);
            Console.WriteLine("");
        }

        public static void Shutdown()
        {
            Sys.Power.Shutdown();
        }




    }
}
