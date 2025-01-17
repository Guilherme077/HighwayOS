﻿using Cosmos.Core;
using HighwayOS.System32.Graphical;
using HighwayOS.System32.Network;
using HighwayOS.System32.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.Terminal
{
    internal static class CmdProcessor
    {
        

        public static void Process(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            var command = args[0].ToLower();

            switch (command)
            {
                case "shutdown":
                    Kernel.Shutdown(args);
                    break;
                case "graphicmode":
                    Task_Manager.CreateTask(new GraphicManager());
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "network":
                    NetworkManager.Command(args);
                    break;
                case "task":
                    Task_Manager.Command(args);
                    break;
                default:
                    if (Task_Manager.IsTaskRunningByCmdName(args[0]))
                    {
                        Task_Manager.GetTaskByCmdName(args[0]).Command(args);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: '{command}' is not a valid command");
                        Console.WriteLine($"Type 'prompt help' or 'prompt help -a' for help =D");
                    }
                    
                    break;
            }
        }

    }
}
