using System;
using OxyPlotTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TestIntegral
{
    [TestClass]
    public class TestIntegral
    {
        [TestMethod]
        public void TestIntegral_2X_0to100()
        {
            integral integ = new integral();
            double a = 0, b = 100;
            int n = 10000000;
            Func<double, double> func = x => 2 * x;
            double resultreal = integ.calculatePosl(n, a, b, func);

            double resultright = 10000.0;

            Assert.AreEqual(resultright, resultreal, 0.1);
        }

        [TestMethod]
        public void TestIntegralParallell_2X_0to100 ()
        {
            integral integ = new integral();
            double a = 0, b = 100;
            int n = 10000000;
            Func<double, double> func = x => 2 * x;
            double resultreal = integ.calculateParallel(n, a, b, func);

            double resultright = 10000.0;

            Assert.AreEqual(resultright, resultreal, 0.1);
        }

        [TestMethod]
        public void TestTime ()
        {
            integral integ = new integral();

            double a = 0, b = 100;
            int n = 10000000;
            Func<double, double> func = x => 2 * x;

            Stopwatch timerPosl = new Stopwatch();
            Stopwatch timerParall = new Stopwatch();

            timerPosl.Start();
            integ.calculatePosl(n, a, b, func);
            timerPosl.Stop();

            timerParall.Start();
            integ.calculateParallel(n, a, b, func);
            timerParall.Stop();

            Assert.IsTrue(timerParall.ElapsedMilliseconds < timerPosl.ElapsedMilliseconds);
        }

        [TestMethod]
        public void ParallelANDPoslEqual ()
        {
            integral integ = new integral();

            double a = 0, b = 100;
            int n = 10000000;
            Func<double, double> func = x => 2 * x;

            double rezPosl = integ.calculatePosl(n, a, b, func);
            double rezParallel = integ.calculateParallel(n, a, b, func);

            Assert.AreEqual(rezPosl, rezParallel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RightParametrs ()
        {
            integral integ = new integral();
            double a = 0, b = 100;
            int n = 10000000;
            Func<double, double> func = x => 2 * x;
            integ.calculatePosl(n, b, a, func);
        }

    }
}
