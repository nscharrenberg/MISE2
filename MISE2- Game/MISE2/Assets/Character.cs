using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISE2.Assets.enums;

namespace MISE2.Assets
{
    class Character
    {
        // Properties
        private Point _currentPosition;
        private int _hitPoint;

        /// <summary>
        /// Defining the looks of the Characters
        /// </summary>
        private static int _borderSize = 2;
        private Pen pen = new Pen(Color.Black, _borderSize);
        protected SolidBrush sb = new SolidBrush(Color.GreenYellow);
        private Font font = new Font("Arial", 6);
        public StringFormat sf = new StringFormat();

        // Accessors
        public int HitPoint
        {
            get { return _hitPoint; }
            set
            {
                if (value >= 0)
                {
                    _hitPoint = value;
                }
            }
        }
        
        public Point CurrentPosition
        {
            get
            {
                return _currentPosition;
            }

            set
            {
                _currentPosition = value;
            }
        }

        // Methods
        public void DrawCharacter(Graphics g)
        {
            Rectangle rect = new Rectangle(
                    this.CurrentPosition + new Size(_borderSize * 2, _borderSize * 2),
                    World.NewWorld.Level.CellSize - new Size(_borderSize * 4, _borderSize * 4)
                );

            g.FillEllipse(this.sb, rect);
            g.DrawEllipse(this.pen, rect);
            string hitPointToString = Convert.ToString(this.HitPoint);
            g.DrawString(hitPointToString, this.font, Brushes.Black, rect, this.sf);
        }

        public Point UpdateCharacter(Point position, Movements movement)
        {
            Size levelSize = World.NewWorld.Level.LevelSize;
            Size cellSize = World.NewWorld.Level.CellSize;
            Point updatedPosition = position;

            if (movement == Movements.MoveUp)
            {
                updatedPosition.Offset(0, cellSize.Height * -1);
            } else if (movement == Movements.MoveDown)
            {
                updatedPosition.Offset(0, cellSize.Height * 1);
            } else if (movement == Movements.MoveRight)
            {
                updatedPosition.Offset(cellSize.Width * 1, 0);
            } else if (movement == Movements.MoveLeft)
            {
                updatedPosition.Offset(cellSize.Width * -1, 0);
            }

            // Check if within Level
            if (updatedPosition.X < 0 || updatedPosition.X > levelSize.Width - cellSize.Width || updatedPosition.Y < 0 ||
                updatedPosition.Y > levelSize.Height - cellSize.Height)
            {
                return position;
            }

            // Check if cell is a Wall
            if (World.NewWorld.Level.CelltypePosition(updatedPosition) == CellTypes.Wall)
            {
                return position;
            }

            return updatedPosition;
        }
    }
}
