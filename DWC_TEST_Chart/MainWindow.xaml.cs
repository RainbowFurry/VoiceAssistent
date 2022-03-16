using LiveCharts.Wpf;
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

namespace DWC_TEST_Chart
{

   public partial class MainWindow : Window
   {

      public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      MainWindow mainWindow;

      public MainWindow()
      {
         InitializeComponent();
         mainWindow = this;
         this.Show();

         Vergleich v = new Vergleich();
         v.Show();

         Stacked s = new Stacked();
         s.Show();

         CircleDiagram c = new CircleDiagram();
         c.Show();

         DoughnatChart d = new DoughnatChart();
         d.Show();

         Angular a = new Angular();
         a.Show();

         //https://lvcharts.net/App/examples/v1/wpf/Basic%20Line%20Chart
         Gauge gauge = mainWindow.DWC_Chart;
         gauge.Value = 0;
         gauge.GaugeActiveFill = Brushes.AliceBlue;
         gauge.ToColor = Color.FromArgb(0, 0, 0, 0);

         timer.Tick += startTimer;
         timer.Start();
      }


      int value = 0;
      private void startTimer(object sender, EventArgs e)
      {

         //Chart
         if (value < 40)
         {
            value++;
            Gauge gauge = mainWindow.DWC_Chart;
            gauge.Value = value;
            gauge.GaugeActiveFill = Brushes.LightGreen;
            gauge.ToColor = Color.FromArgb(0, 0, 0, 0);
         }
         else if (value < 80)
         {
            value++;
            Gauge gauge = mainWindow.DWC_Chart;
            gauge.Value = value;
            gauge.GaugeActiveFill = Brushes.Orange;
            gauge.ToColor = Color.FromArgb(0, 0, 0, 0);
         }
         else if (value < 100)
         {
            value++;
            Gauge gauge = mainWindow.DWC_Chart;
            gauge.Value = value;
            gauge.GaugeActiveFill = Brushes.IndianRed;
            gauge.ToColor = Color.FromArgb(0, 0, 0, 0);
         }

      }

   }
}
