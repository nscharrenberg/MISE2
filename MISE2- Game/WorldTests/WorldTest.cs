using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MISE2;
using MISE2.Assets;

namespace WorldTests
{
    [TestClass]


    public class WorldTest
    {
        private Player player;
        private Enemy enemy;

        /*
         * WORLD TESTS
         */
        private static void Generate()
        {
            World.Instance.Generate(new Size(50, 50), new Size(10, 10), 10);
        }

        private void GenerateAllWalls()
        {
            // Wall Percentage 100%
            World.Instance.Generate(new Size(50, 50), new Size(10, 10), 100);
        }

        private void GenerateNoWalls()
        {
            // Wall Percentage 100%
            World.Instance.Generate(new Size(20, 10), new Size(10, 10), 0);
        }

        [TestMethod]
        public void WorldGenerate()
        {
            World.Instance.Generate(new Size(40, 60), new Size(5, 7), 0);

            // Exit Point & Spawn Point can't be the same
            Assert.AreNotEqual(World.Instance.Player.CurrentPosition, World.Instance.Level.ExitPoint);
        }

        [TestMethod]
        public void WorldGameWon()
        {
            GenerateNoWalls();
            // Game Won is by Default False
            Assert.IsFalse(World.Instance.GameWon);

            // Game Won is set to True when player gets to the exit point.
            World.Instance.Player.MovementKeys(Keys.D);
            World.Instance.UpdateWorld();
            
            Assert.IsTrue(World.Instance.GameWon);
        }

        /*
         * PLAYER TESTS
         */
        private void GeneratePlayer()
        {
            Generate();
            this.player = new Player();
        }

        /// <summary>
        /// Check if the Player starts with 100 hitPoints
        /// </summary>
        [TestMethod]
        public void PlayerDamageCheck()
        {
            GeneratePlayer();
            Assert.AreEqual(100, this.player.HitPoint);
        }

        /// <summary>
        /// Check if Player spawns in starting position 0, 0
        /// </summary>
        [TestMethod]
        public void PlayerCheckNewPoint()
        {
            GeneratePlayer();
            Assert.AreEqual(new Point(0, 0), this.player.CurrentPosition);
        }

        [TestMethod]
        public void PlayerTestValidPositions()
        {
            GeneratePlayer();

            // Right
            this.player.MovementKeys(Keys.D);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(5, 0), this.player.CurrentPosition);

            // Left
            this.player.MovementKeys(Keys.A);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(0, 0), this.player.CurrentPosition);

            // Down
            this.player.MovementKeys(Keys.S);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(0, 5), this.player.CurrentPosition);

            // Up
            this.player.MovementKeys(Keys.W);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(0, 0), this.player.CurrentPosition);

        }

        [TestMethod]
        public void PlayerTestInvalidPositions()
        {
            GeneratePlayer();

            // Up
            this.player.MovementKeys(Keys.W);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(0, 0), this.player.CurrentPosition);
            
            // Walk Down
            this.player.MovementKeys(Keys.A);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(0, 0), this.player.CurrentPosition);
        }

        [TestMethod]
        public void PlayerTestWallPositions()
        {
            GeneratePlayer();
            GenerateAllWalls();

            // Right
            this.player.MovementKeys(Keys.D);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(0, 0), this.player.CurrentPosition);

            // Down
            this.player.MovementKeys(Keys.S);
            this.player.UpdatePlayer();

            Assert.AreEqual(new Point(0, 0), this.player.CurrentPosition);
        }

        /*
         * ENEMY TESTS
         */
        [TestMethod]
        public void GenerateEnemies()
        {
            Generate();
            this.enemy = new Enemy(new Point());
        }

        [TestMethod]
        public void EnemyDamageCheck()
        {
            GenerateEnemies();
            Assert.AreEqual(100, this.enemy.HitPoint);
        }

        [TestMethod]
        public void EnemyCheckNewPoint()
        {
            GenerateEnemies();
            Assert.AreEqual(new Point(0, 0), this.enemy.CurrentPosition);
        }

        [TestMethod]
        public void EnemyOtherCheckNewPoint()
        {
            Enemy oe = new Enemy(new Point(30, 30));
            Assert.AreEqual(new Point(30, 30), oe.CurrentPosition);
        }

        [TestMethod]
        public void EnemyOnEmptySpace()
        {
            // ADD CODE HERE TO CHECK IF ENEMY SPAWNS ON EMPTY CELL
        }

        /*
         * WORLD TESTS
         */


    }
}
