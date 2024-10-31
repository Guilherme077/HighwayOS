using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace HighwayOS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Highway booted successfully.");
            Console.WriteLine("This is a dev version!");
            Console.WriteLine("This is the first version of HighwayOS. =D");
            Console.WriteLine("Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
