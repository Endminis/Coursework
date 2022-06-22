using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Map   
    {
       public  Cell[,] Cells { get; set; }
        public List<DestroyedShip> DestroyedShips { get; set; }
        public static int Count { get; set; }

        public Map(int offset, bool player, int count)
        {
            int cellSize = 40; 
            Count = count;
            DestroyedShips = new List<DestroyedShip>();
            Cells = new Cell[count, count];
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    Cells[i, j] = new Cell(new Point(offset + (cellSize * i), 70 + (cellSize * j)), cellSize, player);
                }
        }
        public void DestroyShip(Cell cell) => DestroyedShips.Add(new DestroyedShip(new Point(cell.X, cell.Y), new Point(40, 40)));

        public static void CreateShips(Cell[,] cells, int offset)
        {
            int x, y;
            Random random;
            for (int i = 0; i < Count; i++)
            {
                random = new(DateTime.Now.Millisecond - offset);
                do
                {
                    x = random.Next(0, Count);
                    y = random.Next(0, Count);
                } while (cells[x, y].IsShip);
                cells[x, y].SetShip(true);
            }

        }
      public static bool CheckIfEmpty(Cell[,] cells, string s, Form form) 
        {
            foreach (var i in cells)
                if (i.IsShip && !i.IsDestroyed)
                {
                    return false;
                }

            DialogResult result = MessageBox.Show("Бажаєте завершити роботу програми?\nYes - так\nNo - новий раунд", s,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                form.Close();
                return true;
            }
            else
            {
                return true;           
            }
        }

    }
}
