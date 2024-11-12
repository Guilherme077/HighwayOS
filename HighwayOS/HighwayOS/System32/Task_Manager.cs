using Cosmos.System.Graphics;
using HighwayOS.System32.Graphical;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32
{
    public class Task_Manager
    {
        public static List<String> Task_Running = new List<String>();
        //[ManifestResourceStream(ResourceName = "SoundTest.SystemFiles.Task_manager.bmp")] public static byte[] Solitaire;
        //public static Bitmap based = new Bitmap(Solitaire);
        public static void Task_manager()
        {
            
            //In here we have a foreach which goes thru every item in the Tasks list
            //ImprovedVBE.DrawImageAlpha(based, 0, 50);
            foreach (String task in Task_Running)
            {
                if(task == "GraphicManager")
                {
                    GraphicManager.Execute();
                }
            }
        }
    }
}
