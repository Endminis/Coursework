using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class DestroyedShip 
    {
        Point position, scale;
        public int X => position.X;
        public int Y => position.Y;
        public int Width => scale.X;
        public int Height => scale.Y;

        static Image image;
        public static void SetImage(Image value) => image = value;
        public void SetPosition(Point value) => position = value;
        public void SetScale(Point value) => scale = value;
        public DestroyedShip(Point position, Point size)
        {
            SetPosition(position);
            SetScale(size);
        }

        public void Draw(Graphics g) => g.DrawImage(image, X, Y, Width, Height);
    }
}
