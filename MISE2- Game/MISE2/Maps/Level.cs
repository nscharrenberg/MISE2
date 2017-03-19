using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MISE2.Assets.enums;

namespace MISE2
{
    class Level
    {
        // Property
        private Size _levelSize;
        private Size _cellSize;
        private Size _cellCount;
        private Point _exitPoint;
        private Cell[] _cells;

        // Constructor
        public Level(Size levelSize, Size cellCount, int wp)
        {
            this._levelSize = levelSize;
            this._cellSize = new Size(levelSize.Width / cellCount.Width, levelSize.Height / cellCount.Height);
            this._cellCount = cellCount;
            this._cells = new Cell[_cellCount.Width * _cellCount.Height];
            for (int i = 0; i < _cells.Length; i++)
            {
                Point coordinates = new Point(i % _cellCount.Width,i / _cellCount.Width);
                this._cells[i] = new Cell(coordinates, this.CoordinatesToPosition(coordinates), this._cellSize);

                Random rand = new Random();
                if (i > 0 && rand.Next(100) <= wp)
                {
                    this._cells[i].CellType = CellTypes.Wall;
                }
            }
        }

        // Accessor
        public Point ExitPoint
        {
            get { return _exitPoint; }
            private set { _exitPoint = value; }
        }

        public Size CellCount
        {
            get { return _cellCount; }
            private set { _cellCount = value; }
        }

        public Size CellSize
        {
            get { return _cellSize; }
            private set { _cellSize = value; }
        }

        public Size LevelSize
        {
            get { return _levelSize; }
            private set { _levelSize = value; }
        }

        // Methods
        public void DrawLevel(Graphics g)
        {
            foreach (Cell cell in this._cells)
            {
                cell.DrawCell(g);
            }
        }

        private Point CoordinatesToPosition(Point coordinates)
        {
            return new Point(coordinates.X * this._cellSize.Width, coordinates.Y * this._cellSize.Height);
        }

        private Point PositionToCoordinates(Point position)
        {
            Size s = this._cellSize;
            return new Point(
                (position.X - (position.X / s.Width)) / s.Width,
                (position.Y - (position.Y / s.Height)) / s.Height
                );
        }

        public CellTypes CelltypePosition(Point position)
        {
            Point coordinates = this.PositionToCoordinates(position);
            int coordinatesArray = (coordinates.Y * this._cellCount.Width) + coordinates.X;
            return this._cells[coordinatesArray].CellType;
        }
    }
}
