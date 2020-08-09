using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rift_Wars
{
    class Projectile
    {
        public int x, y, width, height;

        public Image projectile;//variable for the missile's image

        public Rectangle projectileRec;//variable for a rectangle to place our image in

        // in the following constructor we pass in the values of spaceRec which
        // gives us the position of the spaceship which we can then use to place the
        // missile where the spaceship is located
        public Projectile(Rectangle champRec)
        {
            x = champRec.X + 37; // move missile to middle of spaceship
            y = champRec.Y;
            width = 20;
            height = 20;
            projectile = Properties.Resources.Projectile;
            projectileRec = new Rectangle(x, y, width, height);
        }

        public void draw(Graphics g)
        {
            y -= 30;//speed of missile
            projectileRec = new Rectangle(x, y, width, height);
            g.DrawImage(projectile, projectileRec);
        }

    }
}
