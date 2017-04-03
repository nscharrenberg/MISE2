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
    public class Player : Character
    {
        private bool _powerUp;
        private Movements currentMovements = Movements.StandStill;
        public int Armor = 0;

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

        public void MovementKeys(object w)
        {
            throw new NotImplementedException();
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
            else if (keys == Keys.Space || keys == Keys.Control)
            {
                this.currentMovements = Movements.Attack;
            }
            else
            {
                this.currentMovements = Movements.StandStill;
            }
        }

        public void UpdatePlayer()
        {
            CurrentPosition = UpdateCharacter(CurrentPosition, CurrentMovements);
        }
    }
}
