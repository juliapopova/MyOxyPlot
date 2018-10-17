using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlotTest
{
    class integral
    {
        public double func(double x)
        {
            return 2 * x - Math.Log(7 * x) - 12;
        }


        public void calculate (double n)
        {
            double  h, x, f = 0.0;
            int a = 1, b = 1000;
            h = (b - a) / n;

           for (x = a; x < (b - h); x += h)
                f += ((func(x) + func(x + h)) / 2.0) * h;

        }
    }
}
