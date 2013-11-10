using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace EcoSim.UI
{
    class Draw
    {
        static private List<int>[] CircleCache = new List<int>[1000];

        static private void CacheCircles(int Size)
        {
            if (CircleCache[Size] == null)
            {
                CircleCache[Size] = new List<int>();

                int rad2 = Size * Size;
                for (int i = -Size; i < Size; i++)
                {
                    int y2 = i * i;
                    int x = (int)Math.Sqrt(rad2 - y2);
                    CircleCache[Size].Add(x);
                }
            }
        }

        static IntPtr FindPtr(BitmapData bmpData, int x, int y)
        {
            IntPtr temp = bmpData.Scan0;
            //finding y
            temp += bmpData.Stride * y;
            //finding 
            temp += x * 4;
            return temp;
        }

        public static BitmapData LockBuffer(Bitmap buffer)
        {
            BitmapData bmpData = buffer.LockBits(new Rectangle(0, 0, buffer.Width, buffer.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            return bmpData;
        }

        public static void Pixel(BitmapData bmpData, int X, int Y, int Colour)
        {
            IntPtr temp = FindPtr(bmpData, X, Y);
            System.Runtime.InteropServices.Marshal.WriteInt32(temp, Colour);
        }

        public static Color GetBlendedColor(Color OldColor, Color NewColor)
        {
            byte InvA = (byte)(255 - OldColor.A);
            byte NewA = (byte)(OldColor.A + NewColor.A * InvA);
            return Color.FromArgb(
                NewA,
                (OldColor.R * OldColor.A + NewColor.R * NewColor.A * InvA) / NewA,
                (OldColor.G * OldColor.A + NewColor.G * NewColor.A * InvA) / NewA,
                (OldColor.B * OldColor.A + NewColor.B * NewColor.A * InvA) / NewA);
        }

        public static void Circle(BitmapData bmpData, int Size, int X, int Y, Color Colour)
        {
            CacheCircles(Size);

            int tempX;
            int i = 0;
            for (int tempY = Y - Size; tempY < Y + Size; tempY++)
            {
                if (tempY >= 0)
                {
                    if (tempY >= bmpData.Height)
                    {
                        break;
                    }
                    tempX = X - CircleCache[Size][i];
                    while (tempX < CircleCache[Size][i] + X)
                    {
                        if (tempX >= 0)
                        {
                            if (tempX >= bmpData.Width)
                            {
                                break;
                            }
                            IntPtr temp = FindPtr(bmpData, tempX, tempY);
                            System.Runtime.InteropServices.Marshal.WriteInt32(temp, Colour.ToArgb());
                        }
            
                      tempX++;
                    }
                }
                i++;
            }
        }

    }
}
