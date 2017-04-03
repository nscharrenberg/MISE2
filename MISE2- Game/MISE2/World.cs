using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MISE2.Assets;
using MISE2.Assets.enums;

namespace MISE2
{
    public class World
    {
        // Properties
        private Level _level;
        private Player _player;
        private Enemy _enemy;
        private List<Enemy> _enemies = new List<Enemy>();
        private List<Enemy> _killedEnemies = new List<Enemy>();
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

        public int KilledEnemies
        {
            get { return _killedEnemies.Count(); }
        }
        public Enemy AnEnemy
        {
            get {  return _enemy; }
            private set { _enemy = value; }
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

        public bool GameWon
        {
            get { return this.Player.CurrentPosition.Equals(this.Level.ExitPoint); }
        }

        public bool GameLose
        {
            get { return this.Player.HitPoint == 0; }
        }

        public void Generate(Size levelSize, Size cellCount, int wp)
        {
            this._stopWatch.Start();
            
            this.Level = new Level(levelSize, cellCount, wp);
            this.Player = new Player();

            // Draw Enemies
            int aantal = 5;
            for (int i = 0; i < aantal; i++)
            {
                _enemies.Add(new Enemy(World.NewWorld.Level.EmptySpace()));
            }
        }

        public void DrawWorld(Graphics g)
        {
            this.Level.DrawLevel(g);
            this.Player.DrawCharacter(g);

            foreach (Enemy enemy in _enemies)
            {
                enemy.DrawCharacter(g);
            }
        }

        public void UpdateWorld()
        {
            this.Player.UpdatePlayer();

            foreach (var enemy in _enemies)
            {
                enemy.UpdateEnemy();

                if (this.Player.CurrentPosition.Equals(enemy.CurrentPosition))
                {
                    this.Player.HitPoint -= 5;

                    enemy.HitPoint -= 50;
                }
            }

            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                if (_enemies[i].HitPoint == 0)
                {
                    _enemies.RemoveAt(i);
                    _killedEnemies.Add(new Enemy(World.NewWorld.Level.EmptySpace()));
                }
            }
        }
    }
}
