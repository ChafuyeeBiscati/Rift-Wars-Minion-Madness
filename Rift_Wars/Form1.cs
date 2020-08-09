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
        int score, lives;
        //declare a list  missiles from the missile class
        List<Projectile> projectiles = new List<Projectile>();



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
            score = 0;
            lblScore.Text = score.ToString();
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
            tmrMinion.Enabled = true;
            MessageBox.Show("Use the left and right arrow keys to move the spaceship. \n Don't get hit by the planets! \n Every planet that gets past scores a point. \n If a planet hits a spaceship a life is lost! \n \n Enter your Name press tab and enter the number of lives \n Click Start to begin", "Game Instructions");



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

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }

        }

        private void frmGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tmrChampion_Tick(object sender, EventArgs e)
        {


        }

        private void pnlGame_MouseMove(object sender, MouseEventArgs e)
        {
            champion.moveChampion(e.X);
            this.Invalidate();
        }

        private void tmrMinion_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                minion[i].MoveMinion();
                if (champion.champRec.IntersectsWith(minion[i].minionRec))
                {
                    //reset planet[i] back to top of panel
                    minion[i].y = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                    txtLives.Text = lives.ToString();// display number of lives
                    CheckLives();
                }

                //if a planet reaches the bottom of the Game Area reposition it at the top
                if (minion[i].y >= pnlGame.Height)
                {
                    score += 1;//update the score
                    lblScore.Text = score.ToString();// display score
                    minion[i].y = 30;
                }


            }
            pnlGame.Invalidate();//makes the paint event fire to redraw the panel

        }

        private void frmGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                projectiles.Add(new Projectile(champion.champRec));
            }

        }

        private void CheckLives()
        {
            if (lives == 0)
            {
                tmrMinion.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }

    }
}
