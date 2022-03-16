using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DarkWolfCraftSys
{
    public class DragAndDrop
    {
        /*
         * Creator: Adrian H.
        * Date: -
        * Comment: -
        */

        //ERROR WENN MAN VON EINEM STACKPANNEL IN EIN ANDERES DRAG AND DROPPT

        private static bool isDown;
        private static bool isDragging;
        private static Point startPosition;
        private static UIElement realDragSource;
        private static UIElement dummyDragSource = new UIElement();
        //SP = STACKPANNEL

        #region StackPanel
        public static void sp_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            StackPanel DWC_StackPannel = (StackPanel)sender;

            if (e.Source == DWC_StackPannel)
            {
            }
            else
            {
                isDown = true;
                startPosition = e.GetPosition(DWC_StackPannel);
            }
        }

        public static void sp_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDown = false;
            isDragging = false;
            realDragSource.ReleaseMouseCapture();
        }

        public static void sp_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            StackPanel DWC_StackPannel = (StackPanel)sender;

            if (isDown)
            {
                if ((isDragging == false) && ((Math.Abs(e.GetPosition(DWC_StackPannel).X - startPosition.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(DWC_StackPannel).Y - startPosition.Y) > SystemParameters.MinimumVerticalDragDistance)))
                {
                    isDragging = true;
                    realDragSource = e.Source.GetType() == typeof(Image) ? ((Image)e.Source).Parent as UIElement : ((Rectangle)e.Source).Parent as UIElement;
                    realDragSource.CaptureMouse();
                    DragDrop.DoDragDrop(dummyDragSource, new DataObject("UIElement", e.Source, true), DragDropEffects.Move);
                }
            }
        }

        public static void sp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UIElement"))
            {
                e.Effects = DragDropEffects.Move;
            }
        }

        public static void sp_Drop(object sender, DragEventArgs e)
        {

            StackPanel DWC_StackPannel = (StackPanel)sender;

            if (e.Data.GetDataPresent("UIElement"))
            {
                UIElement parent = e.Source.GetType() == typeof(Image) ? ((Image)e.Source).Parent as UIElement : ((Rectangle)e.Source).Parent as UIElement;
                int droptargetIndex = -1, i = 0;
                foreach (UIElement element in DWC_StackPannel.Children)
                {
                    if (element.Equals(parent))
                    {
                        droptargetIndex = i;
                        break;
                    }
                    i++;
                }
                if (droptargetIndex != -1)
                {
                    DWC_StackPannel.Children.Remove(realDragSource);
                    DWC_StackPannel.Children.Insert(droptargetIndex, realDragSource);
                }

                isDown = false;
                isDragging = false;
                realDragSource.ReleaseMouseCapture();
            }

        }
        #endregion

        #region Grid
        //Whenn neded
        #endregion

    }
}
