using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MISE2
{
    class Level
    {
        private Size _levelSize;
        private Size _cellSize;
        private Size _cellCount;
        private Point _exitPoint;

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
    }
}
