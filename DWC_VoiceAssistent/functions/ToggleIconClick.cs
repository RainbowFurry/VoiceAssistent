using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DWC_VoiceAssistent.functions
{
    class ToggleIconClick
    {

        public bool isOpen;

        public ToggleIconClick(object sender, Thickness opened, Thickness closed, RotateTransform rotationopen, RotateTransform rotationclosed, Grid grid)
        {

            Console.WriteLine(sender.GetType());
            if (sender.GetType().ToString().Contains("Image"))
            {
                Image image = (Image)sender;

                if (image.RenderTransform != rotationclosed)
                {
                    
                    while (grid.Width > 30)
                    {
                        grid.Width--;
                    }

                    image.RenderTransform = rotationopen;
                    image.Margin = opened;
                    isOpen = true;

                }
                else if(image.RenderTransform == rotationclosed)
                {
                   
                    while (grid.Width < 372)
                    {
                        grid.Width++;
                    }

                    image.RenderTransform = rotationclosed;
                    image.Margin = closed;
                    isOpen = false;

                }

            }
        }

    }
}
