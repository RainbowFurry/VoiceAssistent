using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DWC_TEST_Chart
{
   public partial class Angular : Window
   {

      public static Angular a;
      private double _value;

      public Angular()
      {
         InitializeComponent();
         a = this;

         Value = 160;

         DataContext = this;

      }

      public double Value
      {
         get { return _value; }
         set
         {
            _value = value;
            OnPropertyChanged("Value");
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      protected virtual void OnPropertyChanged(string propertyName = null)
      {
         if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }

      private void ChangeValueOnClick(object sender, RoutedEventArgs e)
      {
         Value = new Random().Next(50, 250);
      }

   }
}
