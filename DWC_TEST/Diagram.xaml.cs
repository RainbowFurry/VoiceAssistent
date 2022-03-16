using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Drawing;


namespace DWC_TEST
{
   public partial class Diagram : Window
   {

      public static Diagram diagram;

      public Diagram()
      {
         InitializeComponent();
         diagram = this;
         Loaded += Form1_Load;
      }


      private void Form1_Load(object sender, EventArgs e)
      {
         Random rnd = new Random();
         Chart mych = new Chart();
         mych.Height = 100;
         mych.Width = 100;
         mych.BackColor = System.Drawing.SystemColors.Highlight;
         mych.Series.Add("duck");

         mych.Series["duck"].SetDefault(true);
         mych.Series["duck"].Enabled = true;
         mych.Visible = true;

         for (int q = 0; q < 10; q++)
         {
            int first = rnd.Next(0, 10);
            int second = rnd.Next(0, 10);
            mych.Series["duck"].Points.AddXY(first, second);
            Debug.WriteLine(first + "  " + second);
         }
         mych.Show();

         try
         {
            this.AddChild(mych);
         }catch(Exception ex){
            Console.WriteLine(ex.Message);
         }



      }



   }
}
