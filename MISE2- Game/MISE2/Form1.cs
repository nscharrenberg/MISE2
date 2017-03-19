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
        }

        private void gamePic_Paint(object sender, PaintEventArgs e)
        {
            // Character Design
            Character ch = new Character();
            Player pl = new Player();
            Enemy en = new Enemy(new Point(75, 35));
            Cell ce = new Cell(new Point(10, 10), new Point(2, 2), new Size(20, 20) );
            // Character
            ch.CurrentPosition = new Point(50, 50);
            ch.DrawCharacter(e.Graphics);

            // Player
            pl.CurrentPosition = new Point(70, 50);
            pl.DrawCharacter(e.Graphics);

            // Enemy
            en.DrawCharacter(e.Graphics);

            ce.CellType = CellTypes.Wall;
            ce.DrawCell(e.Graphics);



        }
    }
}
