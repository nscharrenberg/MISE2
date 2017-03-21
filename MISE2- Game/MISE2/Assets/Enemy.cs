using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISE2.Assets.enums;

namespace MISE2.Assets
{
    class Enemy : Character
    {
        private int delay = 200;
        private long previousMove;
        public Enemy(Point currentposition)
        {
            CurrentPosition = currentposition;
            HitPoint = 100;

            // Character Color
            sb = new SolidBrush(Color.Red);

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        public void UpdateEnemy()
        {
            if (World.NewWorld.StopWatch - this.previousMove >= this.delay)
            {
                Movements[] moves = new Movements[5]
                {
                    Movements.MoveUp,
                    Movements.MoveDown, 
                    Movements.MoveRight, 
                    Movements.MoveLeft, 
                    Movements.StandStill
                };
                Movements movements = moves[Randomize.Next(moves.Length)];

                this.CurrentPosition = UpdateCharacter(this.CurrentPosition, movements);
                this.previousMove = World.NewWorld.StopWatch;

            }
        }
    }
}
