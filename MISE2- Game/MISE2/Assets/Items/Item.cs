using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2.Assets.Items
{
    class Item : ICarryable
    {
        public string Name { get; set; }
        public int Armor { get; set; }
        public Point Position { get; set; }
        public void Draw(Graphics g)
        {
            Rectangle rect = new Rectangle(
                this.Position + new Size(2 * 2, 2 * 2),
                World.Instance.Level.CellSize - new Size(2 * 4, 2 * 4)
                );
            g.FillEllipse(Brushes.Green, rect);
            g.DrawEllipse(Pens.Green, rect);
            g.DrawString(Name, new Font("Arial", 8), Brushes.White, rect, new StringFormat());
        }

        public Point GetPosition()
        {
            return Position;
        }
    }
}
