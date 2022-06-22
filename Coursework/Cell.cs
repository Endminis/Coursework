using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Cell
    {
        Point position, scale;

        bool isDestroyed = false;

        readonly bool isForPlayer = false;

        bool isShip = false;

        public int X => position.X;
        public int Y => position.Y;
        public int Width => scale.X;
        public int Height => scale.Y;
        public bool IsShip => isShip;
        public bool IsDestroyed => isDestroyed;


        public Cell(Point position, int size, bool forPlayer)
        {
            SetPosition(position);
            SetScale(new Point(size, size));
            this.isForPlayer = forPlayer;
        }
        public void SetShip(bool value) => isShip = value;
        public void SetPosition(Point value) => position = value;
        public void SetScale(Point value) => scale = value;
        public bool AttackCell() => isDestroyed = true;

        public void Draw(Graphics g)
        {
            if (!isDestroyed)
            {
                g.DrawRectangle(new Pen(Color.Blue), X, Y, Width, Height); 
                if (isForPlayer && isShip) 

                    Ship.Draw(g, X, Y);
            }
            else
                g.FillRectangle(Brushes.White, X, Y, Width, Height);
            g.DrawRectangle(new Pen(Color.Blue), X, Y, Width, Height);

        }
        public bool AttackCell(Point pos) 
        {
            if (pos.X > X && pos.X < X + Width && pos.Y > Y && pos.Y < Y + Height && !isDestroyed)
                return AttackCell();
            return false;
        }
    }
}
