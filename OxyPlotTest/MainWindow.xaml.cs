using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace OxyPlotTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Calc()
        {

            //            (graph1.Model.Series[0] as LineSeries).Points.Clear();
            Stopwatch st = new Stopwatch();
            integral integ = new integral();
            int n = Convert.ToInt32(this.nText.Text);
            double rez = 0;

            if (sposob.SelectedIndex == 0)
            {
                st.Start();
                rez = integ.calculatePosl(n);
                st.Stop();
            }
            else
            {
                st.Start();
                rez = integ.calculateParallel(n);
                st.Stop();
            }

            double time = (double)st.ElapsedMilliseconds;
            //                (graph1.Model.Series[0] as LineSeries).Points.Add(new DataPoint(time, n));

            this.resultText.Text = Convert.ToString(rez);
            this.timeText.Text = Convert.ToString(time) + " mс";
            st.Reset();
            //           graph1.InvalidatePlot();


        }

        private void ButtonCulc_Click(object sender, RoutedEventArgs e)
        {
            Calc();
        }

        Window1 posl = new Window1();
        Window2 parallel = new Window2();
        //       Bars bar = new Bars();

        private void PoslGraph_Click(object sender, RoutedEventArgs e)
        {
            posl.culc();
            posl.Show();
        }

        private void ParalGraph_Click(object sender, RoutedEventArgs e)
        {
            parallel.culc();
            parallel.Show();
        }

        private void barGraph_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
