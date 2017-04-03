using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2.Assets
{
    public interface ICarryable
    {
        string Name { get; set; }
        int Armor { get; set; }
        Point Position { get; set; }
        void Draw(Graphics g);
    }
}
