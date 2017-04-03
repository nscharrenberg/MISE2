﻿using System;
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
using MISE2.Assets.Items;

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
        public List<ICarryable> items = new List<ICarryable>();
        public long StopWatch
        {
            get { return this._stopWatch.ElapsedMilliseconds; }
        }

        // Singleton
        public static World Instance
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
                _enemies.Add(new Enemy(World.Instance.Level.EmptySpace()));
            }

            items.Add(new Armor(World.newWorld.Level.EmptySpace()));
            items.Add(new Armor(World.newWorld.Level.EmptySpace()));
            items.Add(new Armor(World.newWorld.Level.EmptySpace()));
            items.Add(new Armor(World.newWorld.Level.EmptySpace()));
        }

        public void DrawWorld(Graphics g)
        {
            this.Level.DrawLevel(g);
            this.Player.DrawCharacter(g);

            foreach (Enemy enemy in _enemies)
            {
                enemy.DrawCharacter(g);
            }

            foreach (var item in items)
            {
                item.Draw(g);
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
                    if (Player.Armor == 0)
                    {
                        this.Player.HitPoint -= 5;
                    }
                    else
                    {
                        int dmg = Player.Armor - 2;
                        this.Player.HitPoint -= dmg;
                    }

                    enemy.HitPoint -= 20;
                }
            }

            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                if (_enemies[i].HitPoint == 0)
                {
                    _enemies.RemoveAt(i);
                    _killedEnemies.Add(new Enemy(World.Instance.Level.EmptySpace()));
                }
            }

            // Items
            foreach (var armor in items)
            {
                if (this.Player.CurrentPosition.Equals(armor.Position))
                {
                    Player.items.Add(armor);
                    Player.Armor += armor.Armor;
                    items.Remove(armor);
                    return;
                }
            }
        }
    }
}
