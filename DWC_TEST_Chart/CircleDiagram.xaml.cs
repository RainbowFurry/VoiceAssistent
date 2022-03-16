using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;

namespace DWC_TEST_Chart
{
    public partial class CircleDiagram : Window
    {

        public static CircleDiagram c;

        public CircleDiagram()
        {

            InitializeComponent();
            c = this;
            //DataContext = this;

            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            //PieChart p = new PieChart();

            //PieSeries ps = new PieSeries();
            //ps.Title = "TEST";
            //ps.DataLabels = true;
            //ps.Values = new ChartValues<double> { 3 };//new ChartValues<double> { 3, 4, 7, 10, 20, 34 };
            //ps.LabelPoint = PointLabel;

            //PieSeries ps2 = new PieSeries();
            //ps2.Title = "TEST2";
            //ps2.DataLabels = true;
            //ps2.Values = new ChartValues<double> { 4 };//new ChartValues<double> { 3, 4, 7, 10, 20, 34 };
            //ps2.LabelPoint = PointLabel;

            //PieChartTest.Series.Add(ps);
            //PieChartTest.Series.Add(ps2);

        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

    }
}
