using DWC_VoiceAssistent.functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DWC_VoiceAssistent.handler.voice.menu
{

    class WindowControle
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        public WindowControle()
        {

            MainWindow.mainWindow.DWC_MainWindow_VoiceAssistent_Toggle.MouseLeftButtonDown += DWC_MainWindow_VoiceAssistent_Toggle_Click;
            MainWindow.mainWindow.DWC_MainWindow_VoiceAssistent_Settings.MouseLeftButtonDown += DWC_MainWindow_VoiceAssistent_Settings_Click;
            MainWindow.mainWindow.DWC_VoiceAssistent_TalkIcon.MouseLeftButtonDown += DWC_MainWindow_VoiceAssistent_VoiceButton_Click;
        }

        private void DWC_MainWindow_VoiceAssistent_Close_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void DWC_MainWindow_VoiceAssistent_Toggle_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            //ToggleIconClick toggleIconClick = new ToggleIconClick(sender, new System.Windows.Thickness(0, 25, 0, 0), new System.Windows.Thickness(341, 30, 0, 0), new RotateTransform(90), new RotateTransform(275), MainWindow.mainWindow.DWC_VoiceAssistent_Menu);

            //if (toggleIconClick.isOpen)
            //{
            //    MainWindow.mainWindow.DWC_VoiceAssistent_TalkIcon.Visibility = System.Windows.Visibility.Hidden;
            //}
            //else
            //{
            //    MainWindow.mainWindow.DWC_VoiceAssistent_TalkIcon.Visibility = System.Windows.Visibility.Visible;
            //}

        }

        private void DWC_MainWindow_VoiceAssistent_Settings_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        /// <summary>
        /// Set the Voice Assistent listening State and Animation on Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DWC_MainWindow_VoiceAssistent_VoiceButton_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (MainWindow.listen == true)
            {
                MainWindow.listen = false;
                VoiceRecognitionListeningAnimation.stopListeningAnimation();
            }
            else
            {
                MainWindow.listen = true;
                VoiceControler.speechRecognizer.RecognizeOnceAsync().ConfigureAwait(false);
                VoiceRecognitionListeningAnimation.startListeningAnimation();
            }

        }

    }
}
