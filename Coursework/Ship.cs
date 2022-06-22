using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Ship
    {
        static Image image;
        static int Width, Height;
        static public void SetImage(Image value) => image = value;
        static public void SetSize(Point size) 
        {
            Width = size.X;
            Height = size.Y;
        }
        public static void Draw(Graphics g, int X, int Y) => g.DrawImage(image, X, Y, Width, Height);
    }
}
