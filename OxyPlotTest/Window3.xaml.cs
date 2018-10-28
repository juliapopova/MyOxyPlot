using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace OxyPlotTest
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        public void pait ()
        {
            Stopwatch timerPosl = new Stopwatch();
            Stopwatch timerParall = new Stopwatch();
            double a = 0, b = 1000;
            int kol = 7;
            int n = 1000;

            Func<double, double> f = x => 2 * x - Math.Log(7 * x) - 12;

            integral integ = new integral();
            (graph3.Model.Series[0] as BarSeries).Items.Clear();
            for (int k = 0; k < kol; k++)
            {
                timerPosl.Start();
                integ.calculatePosl(n,a,b,f);
                timerPosl.Stop();

                timerParall.Start();
                integ.calculateParallel(n,a,b,f);
                timerParall.Stop();
                
                (graph3.Model.Series[0] as BarSeries).Items.Add(new BarItem(timerPosl.ElapsedMilliseconds));
                (graph3.Model.Series[1] as BarSeries).Items.Add(new BarItem(timerParall.ElapsedMilliseconds));

                timerParall.Reset();
                timerPosl.Reset();

                n *= 2;
            }

            graph3.InvalidatePlot();
    }
        
    }
}
