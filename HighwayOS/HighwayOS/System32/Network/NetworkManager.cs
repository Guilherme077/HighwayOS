﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Network;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4.UDP.DHCP;

namespace HighwayOS.System32.Network
{
    internal class NetworkManager
    {
        public static void ConfigIPv4Auto()
        {
            using (var xClient = new DHCPClient())
            {
                /** Send a DHCP Discover packet **/
                //This will automatically set the IP config after DHCP response
                xClient.SendDiscoverPacket();
            }
        }
        public static String GetIP()
        {
            return NetworkConfiguration.CurrentAddress.ToString();
        }
    }
}