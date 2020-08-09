using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Rift_Wars
{
    public partial class frmGame : Form
    {
        Graphics g;
        Minion [] minion = new Minion[10];
        Champion champion = new Champion();
        Random yspeed = new Random();


        public frmGame()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                int x = 10 + (i * 75);
                minion[i] = new Minion(x);
            }
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });



        }

        private void frmGame_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            for (int i = 0; i < 10; i++)
            {
       
                int rndmspeed = yspeed.Next(5, 20);
                minion[i].y += rndmspeed;
                minion[i].DrawMinion(g);
                champion.DrawChampion(g);

            }

;
        }

        private void tmrMinion_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                minion[i].MoveMinion();
                //if a planet reaches the bottom of the Game Area reposition it at the top
                if (minion[i].y >= pnlGame.Height)
                {
                    minion[i].y = 30;
                }


            }
            pnlGame.Invalidate();//makes the paint event fire to redraw the panel

        }
    }
}
