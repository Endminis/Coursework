using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class Player
    {
        public void PcAttack(Map playerMap)
        {
            Random random = new();
            int x, y;
            Cell cell;
            do
            {
                x = random.Next(0, Map.Count);
                y = random.Next(0, Map.Count);
            } while ((cell = playerMap.Cells[x, y]).IsDestroyed);
            cell.AttackCell();
            if (cell.IsShip)
            {
                playerMap.DestroyShip(cell);
                PcAttack(playerMap);
            }
        }

    }
}
