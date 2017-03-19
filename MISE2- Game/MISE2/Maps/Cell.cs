using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MISE2.Assets.enums;

namespace MISE2
{
    class Cell
    {
        // Properties
        private Point _coordinates;
        private Point _cellPosition;
        private CellTypes _cellType;
        private Size _cellSize;

        private static Pen penEmpty = new Pen(Color.LightGray, 1);
        private static Pen penExit = new Pen(Color.Green, 2);
        private  static Pen penWall = new Pen(Color.Black, 2);
        private static SolidBrush sbEmpty = new SolidBrush(Color.White);
        private static SolidBrush sbExit = new SolidBrush(Color.GreenYellow);
        private static SolidBrush sbWall = new SolidBrush(Color.SaddleBrown);

        public Cell(Point coordinates, Point position, Size cellSize)
        {
            this._coordinates = coordinates;
            this._cellPosition = position;
            this._cellSize = cellSize;
            this.CellType = CellTypes.Empty;
        }

        // Accessors
        public CellTypes CellType
        {
            get { return _cellType; }
            set { _cellType = value; }
        }

        public Point CellPosition
        {
            get { return _cellPosition; }
            private set { _cellPosition = value; }
        }

        public Point Coordinates
        {
            get { return _coordinates; }
            private set { _coordinates = value; }
        }

        // Methods
        public void DrawCell(Graphics g)
        {
            Pen p;
            Brush b;

            if (this.CellType == CellTypes.Exit)
            {
                p = Cell.penExit;
                b = Cell.sbExit;
            } else if (this.CellType == CellTypes.Wall)
            {
                p = Cell.penWall;
                b = Cell.sbWall;
            }
            else
            {
                p = Cell.penEmpty;
                b = Cell.sbEmpty;
            }

            Rectangle rect = new Rectangle(
                    this._cellSize.Width * this.Coordinates.X,
                    this._cellSize.Height * this.Coordinates.Y,
                    this._cellSize.Width,
                    this._cellSize.Height
                );
            g.FillRectangle(b, rect);
            g.DrawRectangle(p, rect);
        }
    }
}
