using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlotTest
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.MyModel1 = new PlotModel { Title = "График зависимости количества разбиений от времени. Последовательный вариант"};          
            FunctionSeries ser = new FunctionSeries();
            MyModel1.Series.Add(ser);

            MyModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = " Время, мс"});
            MyModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Количество разбиений" });


            this.MyModel2 = new PlotModel { Title = "График зависимости количества разбиений от времени. Параллельный вариант" };
            FunctionSeries ser2 = new FunctionSeries();
            MyModel2.Series.Add(ser2);

            MyModel2.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = " Время, мс" });
            MyModel2.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Количество разбиений" });

            this.MyModel3 = new PlotModel { Title = "График сравнения параллельного и последовательного варианта" };
            BarSeries bar = new BarSeries();
            BarSeries bar1 = new BarSeries();

            bar.StrokeThickness = 1;
            bar.Title = "Последовательное время";

            bar1.StrokeThickness = 1;
            bar1.Title = "Параллельное время";

            MyModel3.Series.Add(bar);
            MyModel3.Series.Add(bar1);
            MyModel3.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = " Время, мс" });
        }

        public PlotModel MyModel1 { get; private set; }
        public PlotModel MyModel2 { get; private set; }
        public PlotModel MyModel3 { get; private set; }
}
}
