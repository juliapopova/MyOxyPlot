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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        public void culc()
        {
            (graph2.Model.Series[0] as LineSeries).Points.Clear();
            Stopwatch timer = new Stopwatch();
            double n = 100000;
            int kol = 7;
            Random rnd = new Random();
            integral integ = new integral();
            for (int k = 0; k < kol; k++)
            {
                timer.Start();
                integ.calculateParallel(n);
                timer.Stop();
                (graph2.Model.Series[0] as LineSeries).Points.Add(new DataPoint(timer.ElapsedMilliseconds, n / 100000));
                timer.Reset();

                n *= 2;
            }
            graph2.InvalidatePlot();
        }
    }
}
