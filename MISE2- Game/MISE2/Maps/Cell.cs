using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISE2.Assets.enums;

namespace MISE2
{
    class Cell
    {
        private Point _coordinates;
        private Point _cellPosition;
        private CellTypes _cellType;

        public CellTypes CellType
        {
            get { return _cellType; }
            private set { _cellType = value; }
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
    }
}
