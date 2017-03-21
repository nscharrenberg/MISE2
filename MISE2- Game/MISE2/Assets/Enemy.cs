using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2.Assets
{
    class Enemy : Character
    {
        public Enemy(Point currentposition)
        {
            CurrentPosition = currentposition;
            HitPoint = 100;

            // Character Color
            sb = new SolidBrush(Color.Red);

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

    }
}
