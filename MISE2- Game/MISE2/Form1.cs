using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MISE2.Assets;
using MISE2.Assets.enums;

namespace MISE2
{
    public partial class gameFrm : Form
    {
        public gameFrm()
        {
            InitializeComponent();
            GameInfo();
        }

        private void GameInfo()
        {
            World.NewWorld.Generate(gamePic.Size, new Size(10, 10), 10);
        }

        private void gamePic_Paint(object sender, PaintEventArgs e)
        {
            World.NewWorld.DrawWorld(e.Graphics);

            /* DUMMY DATA
            // Character Design
            Character ch = new Character();
            Player pl = new Player();
            Enemy en = new Enemy(new Point(75, 35));
            // Character
            ch.CurrentPosition = new Point(50, 50);
            ch.DrawCharacter(e.Graphics);

            // Player
            pl.CurrentPosition = new Point(70, 50);
            pl.DrawCharacter(e.Graphics);

            // Enemy
            en.DrawCharacter(e.Graphics);
            */
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            World.NewWorld.UpdateWorld();
            gamePic.Refresh();
            

            if (World.NewWorld.GameWon())
            {
                gameTimer.Enabled = false;
                MessageBox.Show("You Won!");
                GameInfo();
            }
            if (World.NewWorld.GameLose())
            {
                gameTimer.Enabled = false;
                MessageBox.Show("Game Over!");
                GameInfo();
            }
        }

        private void gameFrm_KeyDown(object sender, KeyEventArgs e)
        {
            World.NewWorld.Player.MovementKeys(e.KeyCode);
        }
    }
}
