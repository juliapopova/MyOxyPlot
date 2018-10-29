using System;
using System.Windows;
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
            Stopwatch st = new Stopwatch();
            integral integ = new integral();
            int n = Convert.ToInt32(this.nText.Text);
            double a = 0, b = 1000;
            double rez = 0;

            Func<double, double> func = x => 2 * x - Math.Log(7 * x) - 12;

            if (sposob.SelectedIndex == 0)
            {
                st.Start();
                rez = integ.calculatePosl(n, a, b, func);
                st.Stop();
            }
            else
            {
                st.Start();
                rez = integ.calculateParallel(n,a,b, func);
                st.Stop();
            }

            double time = (double)st.ElapsedMilliseconds;

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
        Window3 bar = new Window3();

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
            bar.pait();
            bar.Show();
        }
    }
}
