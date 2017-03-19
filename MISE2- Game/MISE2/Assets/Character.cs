﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected SolidBrush sb = new SolidBrush(Color.Red);
        private Font font = new Font("Arial", 10);
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
            CurrentPosition = new Point(50, 50);
            Rectangle rect = new Rectangle(
                    this.CurrentPosition + new Size(_borderSize * 2, _borderSize * 2),
                    new Size(_borderSize * 4, _borderSize * 4)
                );

            g.FillEllipse(this.sb, rect);
            g.DrawEllipse(this.pen, rect);
        }
    }
}
