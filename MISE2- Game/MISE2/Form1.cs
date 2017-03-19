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
            Character ch = new Character();
            Player pl = new Player();
            Enemy en = new Enemy(new Point(75, 35));
            ch.CurrentPosition = new Point(50, 50);
            ch.DrawCharacter(e.Graphics);

            pl.CurrentPosition = new Point(70, 50);
            pl.DrawCharacter(e.Graphics);

            
            en.DrawCharacter(e.Graphics);

        }
    }
}
