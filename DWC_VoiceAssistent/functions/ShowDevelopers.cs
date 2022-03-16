using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DWC_VoiceAssistent.functions
{
    class ShowDevelopers
    {

        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        private String[] programmDeveloper = { "Jason Hoffmann\nDarkSide_Wolf\nDeveloper and Desighner", "Adrian Hardenecker\nGilrustic\nDeveloper", "Julius ...\nJobby\nDesighner" };

        private String[] capitalLetters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private String[] smalLetters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private Random random = new Random();

        private void createRandomCode()
        {

            String letter = "";
            int randomValue = 0;

            Task.Run(() =>
            {

                for (int counter = 0; counter < 3; counter++)
                {

                    clearLabelContent();

                    for (int length = 0; length < 15; length++)
                    {
                        randomValue = random.Next(2);
                        if (randomValue == 1)
                        {
                            letter = capitalLetters[random.Next(23)];
                        }
                        else
                        {
                            letter = smalLetters[random.Next(23)];
                        }

                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                        //    label1.Content += letter;
                        }), DispatcherPriority.Render);
                        Thread.Sleep(500);

                    }

                }

            });

        }

        private void clearLabelContent()
        {

            Task.Run(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    //label1.Content = "";
                }), DispatcherPriority.Render);
                Thread.Sleep(500);
            });

        }

        private int developerShowCounter = 0;

        private void showDeveloper()
        {

            Task.Run(() =>
            {

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {

                    //label1.Content = programmDeveloper[developerShowCounter];

                    if (developerShowCounter <= programmDeveloper.Length + 1)
                    {
                        developerShowCounter++;
                    }

                }), DispatcherPriority.Render);
                Thread.Sleep(1000);

            });

        }

        /*BACKUP
         * 
         *   var length = 1000;

            Task.Run(() =>
            {
                for (int i = 0; i <= length; i++)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                        label1.Content = "Test" + i;
                    }), DispatcherPriority.Render);
                    Thread.Sleep(100);
                }
            });
         
         */

    }
}
