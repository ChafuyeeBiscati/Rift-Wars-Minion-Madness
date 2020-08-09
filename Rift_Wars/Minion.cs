using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rift_Wars
{
    class Minion
    {
        public int x, y, width, height;
        public Image minionImage;

        public Rectangle minionRec;
        public int score;
        public Minion(int spacing)
        {
            x = spacing;
            y = 10;
            width = 50;
            height = 40;
            minionImage = Properties.Resources.Minion_Blue;
            minionRec = new Rectangle(x, y, width, height);
        }
        public void DrawMinion(Graphics g)
        {
            minionRec = new Rectangle(x, y, width, height);
            g.DrawImage(minionImage, minionRec);
        }
        public void MoveMinion()
        { 
            minionRec.Location = new Point(x, y);
        }


    }
}
