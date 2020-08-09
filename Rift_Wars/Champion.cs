using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rift_Wars
{
    class Champion
    {
        public int x, y, width, height;
        public Image champion;
        public Rectangle champRec;

        public Champion()
        {
            x = 380;
            y = 440;
            width = 55;
            height = 90;
            champion = Properties.Resources.Veigar_Champion;
            champRec = new Rectangle(x, y, width, height);
        }
        //methods
        public void DrawChampion(Graphics g)
        {

            g.DrawImage(champion, champRec);
        }

        public void moveChampion(int mouseX)
        {
            champRec.X = mouseX - (champRec.Width / 2);
        }

    }
}
