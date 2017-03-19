using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2
{
    class World
    {
        private bool _gameWin;
        private bool _gameOver;

        public bool GameOver
        {
            get { return _gameOver; }
            private set { _gameOver = value; }
        }

        public bool GameWin
        {
            get { return _gameWin; }
            private set { _gameWin = value; }
        }
    }
}
