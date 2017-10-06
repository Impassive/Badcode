using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotBuilder.Sources
{
    class CustomRandom
    {
        private double next = 0;
        public CustomRandom(int seed = 1)
        {
            next = Math.Abs(seed);
        }
        public double Next()
        {

            next = next * 148878.553 % 1000000;

            return ((next % 100) / 100);
        }
    }
}
