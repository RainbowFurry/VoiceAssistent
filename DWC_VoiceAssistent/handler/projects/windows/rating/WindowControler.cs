using DarkWolfCraftSys;
using DWC_VoiceAssistent.projects.windows;
using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DWC_VoiceAssistent.handler.projects.windows.rating
{
    class WindowControler
    {

        private DWC_VoiceAssistent.projects.windows.Rating ratingWindow = DWC_VoiceAssistent.projects.windows.Rating.ratingWindow;

        public WindowControler()
        {
            loadDB();
            loadColor();
            WindowOverlayManager.updateAllWindowContent(ratingWindow.RatingWindow);
            fillImageSource();

            //Register Rating Click
            for (int i = 0; i < ratingWindow.Rating_Grid.Children.Count; i++)
            {
                System.Windows.Controls.Image image = ratingWindow.Rating_Grid.Children[i] as System.Windows.Controls.Image;
                image.MouseLeftButtonDown += Rating_Clicked;
            }

            ratingWindow.Close_Button.MouseLeftButtonDown += close_Clicked;
            ratingWindow.Send_Button.MouseLeftButtonDown += send_Clicked;

        }

        private void loadDB()
        {
            ratingWindow.Rating_Info_Text.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueRating("Rating_Info_Text");
            ratingWindow.Rating_Heading.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueRating("Rating_Heading");
            ratingWindow.YourRating_Text.Text = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueRating("YourRating_Text");
            ratingWindow.Send_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueRating("Send_Text");
            ratingWindow.NotSend_Text.Content = DWC_VoiceAssistent.projects.db.ProjectDBManager.loadDBValueRating("NotSend_Text");
        }

        private void loadColor()
        {
            ratingWindow.Rating_Heading_Line.BorderBrush = ProjectVariables.MainColor;
            ratingWindow.Send_Text.Foreground = ProjectVariables.MainColor;

            ratingWindow.RatingWindow.Background = ProjectVariables.Theme_DarkestDark;
            ratingWindow.Rating_Info_Rectangle.Fill = ProjectVariables.Theme_LighterDark;
            ratingWindow.Rating_Rectangle.Fill = ProjectVariables.Theme_LighterDark;
            ratingWindow.UserRating_Rectangle.Fill = ProjectVariables.Theme_LighterDark;
            ratingWindow.Send_Rectangle.Fill = ProjectVariables.Theme_LighterDark;
            ratingWindow.NotSend_Rectangle.Fill = ProjectVariables.Theme_LighterDark;

        }

        #region Rating Controler
        private BitmapImage rating_active_R;
        private BitmapImage rating_active_L;
        private BitmapImage rating_inactive_R;
        private BitmapImage rating_inactive_L;

        private int rating;
        private int halfrating;
        private System.Windows.Controls.Image clickedRating;

        private void Rating_Clicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            System.Windows.Controls.Image image = sender as System.Windows.Controls.Image;
            clickedRating = image;
            rating = Convert.ToInt32(image.Name.Replace("Rating_", "").Replace("_L", "").Replace("_R", ""));

            if (image.Name.Contains("_L"))
            {
                halfrating = 0;
            }
            else if (image.Name.Contains("_R"))
            {
                halfrating = 1;
            }

            updateRating();
        }

        private void updateRating()
        {
            clearRating();

            for (int i = 0; i < ratingWindow.Rating_Grid.Children.Count; i++)
            {
                System.Windows.Controls.Image image = ratingWindow.Rating_Grid.Children[i] as System.Windows.Controls.Image;
                int internRating = Convert.ToInt32(image.Name.Replace("Rating_", "").Replace("_L", "").Replace("_R", ""));

                if (internRating <= rating)
                {

                    if (image.Name.Contains("_R"))
                    {
                        if (!image.Name.Contains(rating.ToString()))
                        {
                            image.Source = rating_active_R;
                        }
                        else
                        {
                            if (clickedRating.Name.Contains("_R"))
                            {
                                image.Source = rating_active_R;
                            }
                        }
                    }
                    else if (image.Name.Contains("_L"))
                    {
                            image.Source = rating_active_L;
                    }

                }

            }
        }

        private void clearRating()
        {
            for (int i = 0; i < ratingWindow.Rating_Grid.Children.Count; i++)
            {
                System.Windows.Controls.Image image = ratingWindow.Rating_Grid.Children[i] as System.Windows.Controls.Image;

                if (image.Name.Contains("_L"))
                {
                    image.Source = rating_inactive_L;
                }
                else if (image.Name.Contains("_R"))
                {
                    image.Source = rating_inactive_R;
                }

            }
        }

        private void fillImageSource()
        {

            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri(MainWindow.Save_Path + @"src\icons\RatingStar_R.png");
            bi1.EndInit();
            rating_active_R = bi1;

            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri(MainWindow.Save_Path + @"src\icons\RatingStar_L.png");
            bi2.EndInit();
            rating_active_L = bi2;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(MainWindow.Save_Path + @"src\icons\RatingStarSelect_R.png");
            bi3.EndInit();
            rating_inactive_R = bi3;

            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri(MainWindow.Save_Path + @"src\icons\RatingStarSelect_L.png");
            bi4.EndInit();
            rating_inactive_L = bi4;
        }
        #endregion

        private void close_Clicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ratingWindow.Close();
        }

        private void send_Clicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //get rating stars
            //get info text
            //send to mail... - unterscheiden von sternen oder in titel schreiben etc...???
            ratingWindow.Close();
        }

    }
}
