using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {
        Map playerMap;
        Map enemyMap;
        Player bot;
        readonly int count = 6;
        Image back;
        public Form1() => InitializeComponent();

        new void Update() 
        {
            Bitmap frame = new(pictureBox1.Width, pictureBox1.Height); 
            Graphics g = Graphics.FromImage(frame); 
            g.DrawImage(back, 0, 0, frame.Width, frame.Height); 
            for (int i = 0; i < count; i++) 
                for (int j = 0; j < count; j++)
                {
                    playerMap.Cells[i, j].Draw(g);
                    enemyMap.Cells[i, j].Draw(g);
                }
            if (playerMap.DestroyedShips.Count != 0)
                foreach (var i in playerMap.DestroyedShips)
                    i.Draw(g);
            if (enemyMap.DestroyedShips.Count != 0)
                foreach (var i in enemyMap.DestroyedShips)
                    i.Draw(g);

            pictureBox1.BackgroundImage = frame;
            if(Map.CheckIfEmpty(enemyMap.Cells, "ÏÅÐÅÌÎÃÀ!", this) || Map.CheckIfEmpty(playerMap.Cells,
                "ÏÎÐÀÇÊÀ...", this))
            {
                this.Start();
            }
        }
        public void Start()
        {
            back = Image.FromFile("Water.png");
            Ship.SetImage(Image.FromFile("Ship.png"));
            Ship.SetSize(new Point(40, 40)); 
            DestroyedShip.SetImage(Image.FromFile("DestroyedShip.png"));
            playerMap = new Map(50, true, count);
            enemyMap = new Map(500, false, count);
            bot = new Player();
            Map.CreateShips(playerMap.Cells, 50); 
            Map.CreateShips(enemyMap.Cells, 900);
            Update();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Start();
        }
        public void PlayerAttack(object sender, MouseEventArgs e) 
        {
                foreach (Cell i in enemyMap.Cells)
                {
                    if (i.AttackCell(new Point(e.X, e.Y))) 
                    {
                    if (i.IsShip)
                    
                        enemyMap.DestroyShip(i); 
                     else if(!i.IsShip)
                        bot.PcAttack(playerMap); 
                        Update();
                        return;
                    }
               }

        }

    }
}
