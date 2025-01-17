﻿using Cosmos.Core.IOGroup;
using Cosmos.HAL.Drivers;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = Cosmos.System.Graphics.Image;

namespace HighwayOS.System32.Graphical
{
    public class ImprovedVBE
    {
        //public static byte[] frame_buffer;
        //public static Bitmap frame = new Bitmap(frame_buffer);

        [ManifestResourceStream(ResourceName = "HighwayOS.canvas.bmp")] public static byte[] Canvas;
        [ManifestResourceStream(ResourceName = "HighwayOS.canvas.bmp")] public static byte[] Canvas2;
        //public static int[] data;
        public static Bitmap cover = new Bitmap(Canvas);
        public static Bitmap cover2 = new Bitmap(Canvas2);

        public void init()
        {
            //cover = new Bitmap(Canvas);
        }
        public static void display(VGACanvas c)
        {
            c.DrawImage(cover, 0, 0);
            //clear(c, Color.Black);
            //cover.rawData = data.rawData;
            clear(0);
        }

        public static void clear(int col)
        {
            if (col == 0)
            {
                int x = 0;
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = cover2.RawData[x];
                    x++;
                }
            }
            else
            {
                int x = 0;
                foreach (int i in cover.RawData)
                {
                    cover.RawData[x] = col;
                    x++;
                }
            }
        }
        public static void DrawPixel(Canvas c, int x, int y, Color col)
        {
            if (y * 1920 == 0)
            {
                y = 1;
                cover.RawData[x * y] = col.ToArgb();
            }
            else
            {
                cover.RawData[y * 1920 - (1920 - x)] = col.ToArgb();
            }
        }
        public static void DrawPixelfortext(int x, int y, int color)
        {
            //16777215 white
            if (y * 1920 == 0)
            {
                y = 1;
                cover.RawData[x * y] = color;
            }
            else
            {
                cover.RawData[y * 1920 - (1920 - x)] = color;
            }
        }

        public static void DrawFilledRectangle(int color, int X, int Y, int Width, int Height)
        {
            for (int j = Y; j < Y + Height; j++)
            {
                for (int i = X; i < X + Width; i++)
                {
                    cover.RawData[j * 1920 - (1920 - i)] = color;
                }
            }
        }
        public static void DrawLine(Canvas c, int color, int X, int Y, int Height)
        {
            DrawFilledRectangle(color, X, Y, 1, Height);
        }

        public static void DrawImage(Image image, int x, int y)
        {
            int counter = 0;
            int prewy = y;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if (_y * 1920 - (1920 - _x) < 1920 * 1080)
                    {
                        if (_x > 1900)
                        {
                            cover.RawData[_y * 1920 - (1920 - _x)] = 0;
                            counter++;
                        }
                        else
                        {
                            cover.RawData[_y * 1920 - (1920 - _x)] = image.RawData[counter];
                            counter++;
                        }
                    }
                }
                prewy++;
            }
        }
        public static void DrawImageArray(int Width, int Height, List<int> rawData, int x, int y)
        {
            int counter = 0;
            int prewy = y;
            for (int _y = y; _y < y + Height; _y++)
            {
                for (int _x = x; _x < x + Width; _x++)
                {
                    if (_y * 1920 - (1920 - _x) < 1920 * 1080)
                    {
                        if (_x > 1900)
                        {
                            cover.RawData[_y * 1920 - (1920 - _x)] = 0;
                            counter++;
                        }
                        else
                        {
                            cover.RawData[_y * 1920 - (1920 - _x)] = rawData[counter];
                            counter++;
                        }
                    }
                }
                prewy++;
            }
        }

        public static void DrawImageAlpha2(Image image, int x, int y)
        {
            int counter = 0;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if (_y * 1920 - (1920 - _x) < 1920 * 1080)
                    {
                        if (image.RawData[counter] == 0)
                        {
                            counter++;
                        }
                        else
                        {
                            cover.RawData[_y * 1920 - (1920 - _x)] = image.RawData[counter];
                            counter++;
                        }
                    }
                }
            }
        }

        public static void DrawImageAlpha(Image image, int x, int y)
        {
            int counter = 0;
            for (int _y = y; _y < y + image.Height; _y++)
            {
                for (int _x = x; _x < x + image.Width; _x++)
                {
                    if (_y <= 1079)
                    {
                        if (_x <= 1920)
                        {
                            if (image.RawData[counter] == 0)
                            {
                                counter++;
                            }
                            else
                            {
                                cover.RawData[_y * 1920 - (1920 - _x)] = image.RawData[counter];
                                counter++;
                            }
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        counter += (int)image.Width;
                    }
                }
            }
        }

        static string ASC16Base64 = "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AAB4zMzM2MzGxsbMAAAAAAAA/sbGwMDAwMDAwAAAAAAAAAAA/mxsbGxsbGwAAAAAAAAA/sZgMBgwYMb+AAAAAAAAAAAAftjY2NjYcAAAAAAAAAAAZmZmZmZ8YGDAAAAAAAAAAHbcGBgYGBgYAAAAAAAAAH4YPGZmZjwYfgAAAAAAAAA4bMbG/sbGbDgAAAAAAAA4bMbGxmxsbGzuAAAAAAAAHjAYDD5mZmZmPAAAAAAAAAAAAH7b29t+AAAAAAAAAAAAAwZ+29vzfmDAAAAAAAAAHDBgYHxgYGAwHAAAAAAAAAB8xsbGxsbGxsYAAAAAAAAAAP4AAP4AAP4AAAAAAAAAAAAYGH4YGAAA/wAAAAAAAAAwGAwGDBgwAH4AAAAAAAAADBgwYDAYDAB+AAAAAAAADhsbGBgYGBgYGBgYGBgYGBgYGBgYGNjY2HAAAAAAAAAAABgYAH4AGBgAAAAAAAAAAAAAdtwAdtwAAAAAAAAAOGxsOAAAAAAAAAAAAAAAAAAAAAAAABgYAAAAAAAAAAAAAAAAAAAAGAAAAAAAAAAADwwMDAwM7GxsPBwAAAAAANhsbGxsbAAAAAAAAAAAAABw2DBgyPgAAAAAAAAAAAAAAAAAfHx8fHx8fAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
        static MemoryStream ASC16FontMS = new MemoryStream(Convert.FromBase64String(ASC16Base64));

        public static void _DrawACSIIString(string s, int x, int y, int color)
        {
            string[] lines = s.Split('\n');
            for (int l = 0; l < lines.Length; l++)
            {
                for (int c = 0; c < lines[l].Length; c++)
                {
                    int offset = (Encoding.ASCII.GetBytes(lines[l][c].ToString())[0] & 0xFF) * 16;
                    ASC16FontMS.Seek(offset, SeekOrigin.Begin);
                    byte[] fontbuf = new byte[16];
                    ASC16FontMS.Read(fontbuf, 0, fontbuf.Length);

                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((fontbuf[i] & 0x80 >> j) != 0)
                            {
                                DrawPixelfortext(x + j + c * 8, y + i + l * 16, color);
                            }
                        }
                    }
                }
            }
        }

        public static void getimagepart(Bitmap image, int x, int y, int width, int height, int draw_x, int draw_y)
        {
            int counter = 0;
            for (int _y = draw_y; _y < draw_y + image.Height; _y++)
            {
                for (int _x = draw_x; _x < draw_x + image.Width; _x++)
                {
                    if (_y >= draw_y + y && _y <= draw_y + y + height)
                    {
                        if (_x >= draw_x + x && _x <= draw_x + x + width)
                        {
                            if (image.RawData[counter] == 0)
                            {
                                counter++;
                            }
                            else
                            {
                                cover.RawData[_y * 1920 - (1920 - _x)] = image.RawData[counter];
                                counter++;
                                draw_x++;
                            }
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        counter++;
                    }
                }
                draw_y++;
            }
        }
    }
}
