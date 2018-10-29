using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlotTest
{
    public class integral
    {
        //public double func(double x)
        //{
        //    return 2 * x - Math.Log(7 * x) - 12;
        //}

        public double calculatePosl(int n, double a, double b, Func<double, double>func)
        {
            if (a > b)
                throw new ArgumentException("a > b");

            double h, x, f = 0.0;
            h = (b - a) / n;
            x = a;

            for (int i = 1; i < n - 1; i++)
                f += func(a + h * i);
            f += (func(a) + func(b)) / 2;
               
            return f * h;
        }

        public double calculateParallel(int n, double a, double b, Func<double, double>func)
        {
            if (a > b)
                throw new Exception("a > b");

            double h;
            h = (b - a) / n;

            double rez = 0.0;

            object obj = new object();

            Parallel.For(0, Convert.ToInt32(n-1), () => 0.0, (i, s, tmp) =>
            {
                tmp += func(a + h * i);
                return tmp;
            }, tmp => { lock (obj) rez += tmp; });

            rez += (func(a) + func(b)) / 2;
            return rez * h;
        }
    }
}
