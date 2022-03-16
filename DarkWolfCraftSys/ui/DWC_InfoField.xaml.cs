using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace DarkWolfCraftSys.ui
{

    public partial class DWC_InfoField : UserControl
    {
        /*
        * Creator: Jason H.
        * Date: -
        * Comment: -
        */

        #region Colors
        private SolidColorBrush red = new SolidColorBrush(Color.FromArgb(255, 249, 198, 198));//#f9c6c6
        private SolidColorBrush blue = new SolidColorBrush(Color.FromArgb(255, 198, 235, 249));//#c6ebf9
        private SolidColorBrush green = new SolidColorBrush(Color.FromArgb(255, 228, 241, 223));//#e4f1df
        private SolidColorBrush yellow = new SolidColorBrush(Color.FromArgb(255, 249, 237, 198));//#f9edc6
        #endregion

        public DWC_InfoField()
        {
            InitializeComponent();

            getSelectedState();
            this.Background.Height = this.Content.Height + 50;
        }

        private void getSelectedState()
        {
            Console.WriteLine("JALOLEY");
            if (this.state == State.Cancel)
            {
                this.Background.Fill = red;
            }
            else if (this.state == State.Success)
            {
                this.Background.Fill = green;
            }
            else if (this.state == State.Info)
            {
                this.Background.Fill = blue;
            }
            else if (this.state == State.Warning)
            {
                this.Background.Fill = yellow;
            }
            else if (this.state == State.Custom)
            {
                //
            }

        }

        private State state;
        public State _state
        {
            get { return state; }
            set
            {
                state = value;
            }
        }

    }

    public enum State
    {
        Success,
        Cancel,
        Info,
        Warning,
        Custom

    }

}
