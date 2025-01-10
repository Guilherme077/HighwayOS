using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.GeneralApplications
{
    internal class Calc : Task
    {
        public override string Name()
        {
            return "Calc";
        }

        public override void Execute()
        {
            Console.WriteLine("Hello");
        }
    }
}
