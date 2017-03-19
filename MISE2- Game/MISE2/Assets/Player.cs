using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MISE2.Assets.enums;

namespace MISE2.Assets
{
    class Player : Character
    {
        private bool _powerUp;
        private Movements currentMovements = Movements.StandStill;

        public bool PowerUp
        {
            get { return _powerUp; }
            private set { _powerUp = value; }
        }

        private Movements CurrentMovements
        {
            get
            {
                Movements movements = this.currentMovements;
                this.currentMovements = Movements.StandStill;
                return movements;
            }

            set
            {
                if (value != Movements.StandStill)
                {
                    this.currentMovements = value;
                }
            }
        }

        public Player()
        {
            // Health
            HitPoint = 100;

            // Character Color
            sb = new SolidBrush(Color.DeepSkyBlue);

            // Text Alignment
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        public void MovementKeys(Keys keys)
        {
            if (keys == Keys.Up || keys == Keys.W)
            {
                this.currentMovements = Movements.MoveUp;
            } else if (keys == Keys.Down || keys == Keys.S)
            {
                this.currentMovements = Movements.MoveDown;
            } else if (keys == Keys.Right || keys == Keys.D)
            {
                this.currentMovements = Movements.MoveRight;
            } else if (keys == Keys.Left || keys == Keys.A)
            {
                this.currentMovements = Movements.MoveLeft;
            }
            else
            {
                this.currentMovements = Movements.StandStill;
            }
        }
    }
}
