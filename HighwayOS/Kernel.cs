using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sys = Cosmos.System;
using IL2CPU.API.Attribs;
using Cosmos.Core.IOGroup;
using Cosmos.System;
using Cosmos.Core.Memory;

namespace HighwayOS
{
    public class Kernel : Sys.Kernel
    {
        public static VBECanvas canvas = new VBECanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32)); // Set graphic Mode
        [ManifestResourceStream(ResourceName = "HighwayOS.imgTest.bmp")] public static byte[] imgTest;
        public static Bitmap bmp = new Bitmap(imgTest);
        [ManifestResourceStream(ResourceName = "HighwayOS.cursor.bmp")] public static byte[] cursor;
        public static Bitmap curs =new Bitmap(cursor);
        protected override void BeforeRun()
        {

            MouseManager.ScreenWidth = 1920;
            MouseManager.ScreenHeight = 1080;
            MouseManager.X = 1920 / 2;
            MouseManager.Y = 1080 / 2;
            




        }

        protected override void Run()
        {

            canvas.DrawFilledRectangle(new Pen(Color.LightCyan), 0, 0, 1920, 1080);

            canvas.DrawImage(bmp, 50, 50);

            int MousePosX = (int)MouseManager.X;
            int MousePosY = (int)MouseManager.Y;
            if(MousePosX > 1920 - 3)
            {
                MousePosX = 1918;
            }
            if (MousePosY > 1080 - 3)
            {
                MousePosY = 1078;
            }


            canvas.DrawImageAlpha(curs, MousePosX, MousePosY);
            Heap.Collect();

            canvas.Display(); //Allways draw the screen

            
        }
    }
}
