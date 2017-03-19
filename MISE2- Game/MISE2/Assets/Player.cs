using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2.Assets
{
    class Player
    {
        private bool _powerUp;

        public bool PowerUp
        {
            get { return _powerUp; }
            private set { _powerUp = value; }
        }
    }
}
