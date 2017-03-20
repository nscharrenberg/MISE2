using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private static World newWorld;
        private Stopwatch _stopWatch = new Stopwatch();
        public long StopWatch
        {
            get { return this._stopWatch.ElapsedMilliseconds; }
        }

        public static World NewWorld
        {
            get
            {
                if (World.newWorld == null)
                {
                    World.newWorld = new World();
                }
                return World.newWorld;
            }
        }

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
            return false;
        }

        public bool GameLose()
        {
            return false;
        }

        public void Generate(Size levelSize, Size cellCount, int wp)
        {
            this.Level = new Level(levelSize, cellCount, wp);
            this.Player = new Player();
        }

        public void DrawWorld(Graphics g)
        {
            this.Level.DrawLevel(g);
            this.Player.DrawCharacter(g);
        }

        public void UpdateWorld()
        {
            this.Player.UpdatePlayer();
        }
    }
}
