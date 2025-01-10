using Cosmos.Core.Memory;
using Cosmos.HAL.Drivers.Video;
using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.Graphical
{
    internal class GraphicManager : Task
    {
        public override String Name() {return "GraphicManager"; }
        public static VGACanvas canvas;// = new Canvas(new Mode(1920, 1080, ColorDepth.ColorDepth32)); //Set the graphic mode: 1920 -> width 1080 -> height
        [ManifestResourceStream(ResourceName = "HighwayOS.test.bmp")] public static byte[] test_image;
        public static Bitmap bmp = new Bitmap(test_image);//This is the test.bmp image loaded as bitmap
        //set the bitmap you want to be displayed as Build action: Embedded resource
        [ManifestResourceStream(ResourceName = "HighwayOS.cursor.bmp")] public static byte[] cursor;
        public static Bitmap curs = new Bitmap(cursor);
        //defines the cursor image
        //Important: If you want to draw a bitmap make sure that it is in 32bpp

        private static void ConfigGraphics() {
            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;
            //canvas = new VGACanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
            canvas = new VGACanvas();
            //Set the cursor to the middle of the screen
            MouseManager.X = 1920 / 2;
            MouseManager.Y = 1080 / 2;
            canvas.Clear(Color.DarkGreen);
        }

        private static void GraphicUpdate()
        {
           

            //Drawing the cursor
            canvas.DrawImageAlpha(curs, (int)MouseManager.X, (int)MouseManager.Y); //DrawImageAlpha is drawing transparent bitmaps

            //Calling the memory manager
            Heap.Collect();
            //This will help running your OS much longer

            canvas.Display(); //Always call canvas.Display() to draw to the screen
        }

        public override void Execute()
        {
            if (!Kernel.GraphicMode)
            {
                Kernel.GraphicMode = true;
                ConfigGraphics();
            }
            else
            {
                GraphicUpdate();
            }
        }
        public static void Stop()
        {
            Kernel.GraphicMode = false;
            canvas.Disable();
           
        }
    }
}
