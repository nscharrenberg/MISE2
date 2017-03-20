using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISE2
{
    public static class Randomize
    {
        static Random rand = new Random();

        public static int Next()
        {
            return Randomize.rand.Next();
        }

        public static int Next(int value)
        {
            return Randomize.rand.Next(value);
        }

        public static int Next(int min, int max)
        {
            return Randomize.rand.Next(min, max);
        }
    }
}
