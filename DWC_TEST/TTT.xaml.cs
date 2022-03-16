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
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

using System.Net;
using System.Globalization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Web;

namespace DWC_TEST
{
   /// <summary>
   /// Interaktionslogik für TTT.xaml
   /// </summary>
   public partial class TTT : Window
   {
      public TTT()
      {
         InitializeComponent();
         System.Windows.Forms.Label l = new System.Windows.Forms.Label();
         l.Margin = new Padding(0);
      }

   }
}
