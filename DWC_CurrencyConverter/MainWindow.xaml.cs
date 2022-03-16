using DarkWolfCraftSys;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;

namespace DWC_CurrencyConverter
{

   public partial class MainWindow : Window
   {
        public static MainWindow mainWindow;

        private double Result;
        private double From;
        private double To;
        private string Save_Path = Assembly.GetExecutingAssembly().Location.Replace("DWC_CurrencyConverter.exe", "");//CHANGE PATH FOR THIS PROJECT
        private string[] MoneyValues = new string[50];
        private string[] MoneyPossibilities =
        {
            "US-Dollar (USD)",
            "Yen (JPY)",
            "LEW (BGN)",
            "Tschechische Krone (CZK)",
            "Dänische Krone (DDK)",
            "Pfund (GBP)",
            "Forint (HUF)",
            "Zloty (PLN)",
            "Rumänischer Leu (RON)",
            "Schwedische Krone (SEK)",
            "Schweizer Franken (CHF)",
            "Isländische Krone (ISK)",
            "Norwegische Krone (NOK)",
            "Koroatische Kuna (HRK)",
            "Russischer Rubel (RUB)",
            "Türkische Lira (TRY)",
            "Australischer Dollar (AUD)",
            "Brasilianischer Real(BRL)",
            "Kanadischer Dollar (CAD)",
            "Chinesischer Yuan (CNY)",
            "Hongkong Dollar (HKD)",
            "Indonesische Rupiah (IDR)",
            "Schekel (ILS)",
            "Indische Rupie (INR)",
            "Südkoreanischer Won (KRW)",
            "Mexikanischer Peso (MXN)",
            "Malaysischer Ringgit (MYR)",
            "Neuseeland Dolla (NZD)",
            "Philippinischer Peso (PHP)",
            "Singapur Dollar (SGD)",
            "Baht (THB)",
            "Südafrikanischer Rand (ZAR)"
      };

        /// <summary>
        /// Initialize CurrencyConverter Window
        /// </summary>
        public MainWindow()
        {

            try
            {
                InitializeComponent();
                mainWindow = this;
                WindowOverlayManager.updateAllWindowContent(this.DWC_Calculator);
                LoadCurrentCurse();
                InitDropDowns();

                MainWindow.mainWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
                MainWindow.mainWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
                MainWindow.mainWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

            }
            catch (Exception e)
            {

                String errorMessage = "[ERROR]\n" +
                       "[ERROR][Message] - " + e.Message + "\n" +
                       "[ERROR][Message] - " + e.Source + "\n" +
                       "[ERROR][Message] - " + e.HelpLink + "\n" +
                       "[ERROR][Message] - " + e.Data + "\n";

                Console.WriteLine(errorMessage);
            }

        }

        /// <summary>
        /// Fill all Dropdown Menus
        /// </summary>
        private void InitDropDowns()
        {
            for (int i = 0; i < MoneyPossibilities.Length; i++)
            {
                this.ToMoney_Selection.Items.Add(MoneyPossibilities[i]);
                this.FromMoney_Selection.Items.Add(MoneyPossibilities[i]);
                this.Storage.Items.Add(MoneyPossibilities[i]);
            }
        }

        /// <summary>
        /// Get the newest money courses from the EuropeanCentralBank
        /// </summary>
        private void LoadCurrentCurse()
        {
            string[] readText;
            WebClient client;
            client = new WebClient();

            if (!Directory.Exists(Save_Path + @"DWC_CurrencyConverter\"))
            {
                Directory.CreateDirectory(Save_Path + @"DWC_CurrencyConverter\");
            }

            try
            {
                File.Delete(Save_Path + @"DWC_CurrencyConverter\CurrentCurse.dwc");
                client.DownloadFile("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml", Save_Path + @"DWC_CurrencyConverter\CurrentCurse.dwc");

                readText = File.ReadAllLines(Save_Path + @"DWC_CurrencyConverter\CurrentCurse.dwc");

                for (int i = 0; i < MoneyPossibilities.Length; i++)
                {
                    MoneyValues[i] = readText[i + 8].Replace("<Cube rate= ", "").Replace(" currency = ", "").Replace("/>", "").Replace("<Cube", "").Replace("'", "").Replace("currency", "").Replace("rate", "").Replace("=", "").Replace(".", ",")
                     .Replace("JPY", "").Replace("BGN", "").Replace("CZK", "").Replace("DKK", "").Replace("GBP", "").Replace("HUF", "").Replace("PLN", "").Replace("PLN", "").Replace("RON", "").Replace("CAD", "")
                     .Replace("CHF", "").Replace("ISK", "").Replace("NOK", "").Replace("HRK", "").Replace("RUB", "").Replace("TRY", "").Replace("AUD", "").Replace("BRL", "").Replace("HKD", "").Replace("ILS", "")
                     .Replace("CNY", "").Replace("KRW", "").Replace("MXN", "").Replace("MYR", "").Replace("NZD", "").Replace("PHP", "").Replace("SGD", "").Replace("INR", "").Replace("THB", "").Replace("ZAR", "").Replace("USD", "")
                     .Trim();
                }

                //AlertText.Content = "";
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Switch the From/To Money curse.
        /// </summary>
        private void Switch_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.FromMoney_Selection.SelectedItem != null && this.ToMoney_Selection.SelectedItem != null)
                {
                    this.Storage.SelectedItem = this.FromMoney_Selection.SelectedItem;
                    this.FromMoney_Selection.SelectedItem = this.ToMoney_Selection.SelectedItem;
                    this.ToMoney_Selection.SelectedItem = this.Storage.SelectedItem;

                  //  this.AlertText.Content = "";
                }
                else
                {
                 //   this.AlertText.Content = "Bitte wähle aus von welcher Währung du auf eine andere Währung umrechnen möchtest und den Betrag.";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// Calculate the money you selected
        /// </summary>
        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.FromMoney_Selection.SelectedItem != null && this.ToMoney_Selection.SelectedItem != null && this.FromMoney_TextBox.Text != "")
                {
                    From = Convert.ToDouble(MoneyValues[this.FromMoney_Selection.SelectedIndex]);
                    To = Convert.ToDouble(MoneyValues[this.ToMoney_Selection.SelectedIndex]);

                    Result = Convert.ToDouble(this.FromMoney_TextBox.Text) / From * To;
                    this.ToMoney_TextBox.Text = Math.Round(Result, 2).ToString();
                 //   this.AlertText.Content = "";
                }
                else
                {
                    //this.AlertText.Content = "Bitte wähle aus von welcher Währung du auf eine andere Währung umrechnen möchtest und den Betrag.";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// Allow the User oenly to type numbers in the Textfield
        /// </summary>
        private void FromMoney_TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,-]+").IsMatch(e.Text);
        }


        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MainWindow.mainWindow.DWC_Window.WindowState == WindowState.Normal)
            {
                MainWindow.mainWindow.DWC_Window.WindowState = WindowState.Maximized;
            }
            else
            {
                MainWindow.mainWindow.DWC_Window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.WindowState = WindowState.Minimized;
        }
        #endregion

    }
}
