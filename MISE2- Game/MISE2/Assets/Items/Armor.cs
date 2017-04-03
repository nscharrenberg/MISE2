using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2.Assets.Items
{
    class Armor : Item, ICarryable
    {
        public Armor(Point position)
        {
            this.Position = position;
            this.Name = "Armor";
            this.Armor = 5;
        }
    }
}
