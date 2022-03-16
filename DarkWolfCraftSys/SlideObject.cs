using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DarkWolfCraftSys
{
    public class SlideObject
    {

        /*
        * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        public void Slide(Grid element, int from, int to, TimeSpan timeSpan, DependencyProperty property)
        {
            Slide(element, from, to, timeSpan, property, null, new Thickness(), new RotateTransform(0));
        }

        public void Slide(Grid element, int from, int to, TimeSpan timeSpan, DependencyProperty property, Image image, Thickness imageMargin, RotateTransform rotate)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = new Duration(timeSpan)
            };

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetName(doubleAnimation, element.Name);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(property));
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin(element);
            if (image == null)
                return;
            image.Margin = imageMargin;
            image.RenderTransform = rotate;
        }

        public void UnSlide(Grid element, int from, int to, TimeSpan timeSpan, DependencyProperty property)
        {
            UnSlide(element, from, to, timeSpan, property, null, new Thickness(0), new RotateTransform(0));
        }

        public void UnSlide(Grid element, int from, int to, TimeSpan timeSpan, DependencyProperty property, Image image, Thickness imageMargin, RotateTransform rotate)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = new Duration(timeSpan)
            };
            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetName(doubleAnimation, element.Name);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(property));
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin(element);
            if (image == null)
                return;
            image.Margin = imageMargin;
            image.RenderTransform = rotate;
        }
    }
}
