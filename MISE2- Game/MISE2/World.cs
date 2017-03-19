using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISE2.Assets;

namespace MISE2
{
    class World
    {
        // Properties
        private Level _level;
        private Player _player;
        private List<Enemy> _enemies;

        public List<Enemy> Enemies
        {
            get { return _enemies; }
            private set { _enemies = value; }
        }

        public Player Player
        {
            get { return _player; }
            private set { _player = value; }
        }

        public Level Level
        {
            get { return _level; }
            private set { _level = value; }
        }

        public bool GameWon()
        {
            return true;
        }
    }
}
