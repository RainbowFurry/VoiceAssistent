using System;
using System.Data;
using System.Windows.Controls;

namespace DWC_Calculator.handler
{
    class WindowControler
    {

        //ToDo: Man kann auch mit tastatur eingeben..

        /// <summary>
        /// Initialyze Calculator MainWindow Handler
        /// </summary>
        public WindowControler()
        {

            loadDB();

            MainWindow.mainWindow.Calculator_Button_0.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_1.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_2.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_3.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_4.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_5.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_6.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_7.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_8.MouseLeftButtonDown += numberButtonClick;
            MainWindow.mainWindow.Calculator_Button_9.MouseLeftButtonDown += numberButtonClick;

            MainWindow.mainWindow.Calculator_Button_Result.MouseLeftButtonDown += resultButtonClick;

            MainWindow.mainWindow.Window_Close.MouseLeftButtonDown += CloseWindow;
            MainWindow.mainWindow.Window_State.MouseLeftButtonDown += ChangeWindowState;
            MainWindow.mainWindow.Window_Minimize.MouseLeftButtonDown += MinimizeWindow;

        }

        #region DB
        private void loadDB()
        {

        }
        #endregion

        /// <summary>
        /// Get clicked number Field. It has to be a Number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numberButtonClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Grid grid = (Grid)sender;
            String buttonContent = grid.Name.Replace("Calculator_Button_", "");
            MainWindow.mainWindow.DWC_Calculator_ResultWay.Text += buttonContent + " ";

        }

        /// <summary>
        /// Get the result of the User entered Calculator Values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resultButtonClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            DataTable dt = new DataTable();

            try
            {
                //var result = dt.Compute(MainWindow.mainWindow.DWC_Calculator_ResultWay.Text.ToString()
                //    .Replace("²", Math.Pow(Eingabe ,2).ToString())
                //    .Replace("√", Math.Sqrt(2).ToString())
                //    .Replace("π", Math.PI.ToString()), "");

                //MainWindow.mainWindow.DWC_Calculator_ResultWay.Text += " = " + result + "\n";
                //MainWindow.mainWindow.DWC_Calculator_Result.Content = result;

            }
            catch (Exception ex)
            {
                MainWindow.mainWindow.DWC_Calculator_ResultWay.Text += " = " + "ERROR" + "\n";
                MainWindow.mainWindow.DWC_Calculator_Result.Content = "ERROR";
            }

        }

        /// <summary>
        /// Get clicked Symbole
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void symboleButtonClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Grid grid = (Grid)sender;
            Label label = (Label)grid.Children[0];

            MainWindow.mainWindow.DWC_Calculator_ResultWay.Text += label.Content + " ";

        }

        /// <summary>
        /// Delete all entered Calculator Values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAll(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Calculator_ResultWay.Text = "";
            MainWindow.mainWindow.DWC_Calculator_Result.Content = "";
        }

        /// <summary>
        /// Delete the lastest entered Calculator Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteOne(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            String re = MainWindow.mainWindow.DWC_Calculator_ResultWay.Text;
            MainWindow.mainWindow.DWC_Calculator_ResultWay.Text = re.Substring(0, re.Length - 1);
        }


        #region Window Options
        private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.Close();
        }

        private void ChangeWindowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MainWindow.mainWindow.DWC_Window.WindowState == System.Windows.WindowState.Normal)
            {
                MainWindow.mainWindow.DWC_Window.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                MainWindow.mainWindow.DWC_Window.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.DWC_Window.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

    }
}
