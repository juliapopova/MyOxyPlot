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

        //public double integ (double x, double f, double h)
        //{
        //    f += ((func(x) + func(x + h)) / 2.0) * h;
        //    x += h;
        //    return f;
        //}

        public double calculatePosl(double n)
        {
            double h, x, f = 0.0;
            int a = 1, b = 1000;
            h = (b - a) / n;
            x = a;

            for (int i = 0; i < n - 1; i++)
                f += ((func(a + h * i) + func(a + h * (i + 1))) / 2.0);
               
            return f * h;
        }

        public double calculateParallel(double n)
        {
            double h;
            int a = 1, b = 1000;
            h = (b - a) / n;

            double rez = 0.0;

            object obj = new object();

            Parallel.For(0, Convert.ToInt32(n-1), () => 0.0, (i, s, tmp) =>
            {
                tmp += (func(a + h * i) + func(a + h * (i + 1))) / 2.0;
                return tmp;
            }, tmp => { lock (obj) rez += tmp; });
            return rez * h;
        }
    }
}
