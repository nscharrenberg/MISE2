using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2.Assets
{
    class Character
    {
        private Point _currentPosition;
        private int _hitPoint;

        public int HitPoint
        {
            get { return _hitPoint; }
            private set { _hitPoint = value; }
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
    }
}
