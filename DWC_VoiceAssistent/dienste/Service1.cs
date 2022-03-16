using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace DWC_VoiceAssistent.dienste
{
    partial class Service1 : ServiceBase
    {
        // installutil.exe "c:\program files\abc 123\myservice.exe"
        static Timer myTimer;
        static int alarmCounter = 1;
        static bool exitFlag = false;

        public Service1()
        {
            InitializeComponent();
            myTimer = new Timer();
        }

        protected override void OnStart(string[] args)
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 5000;
            myTimer.Start();

            // Runs the timer, and raises the event.
            while (exitFlag == false)
            {
                // Processes all the events in the queue.
                Application.DoEvents();
            }
        }

        private static void TimerEventProcessor(Object myObject,
                                        EventArgs myEventArgs)
        {
            myTimer.Stop();

            // Displays a message box asking whether to continue running the timer.
            if (MessageBox.Show("Continue running?", "Count is: " + alarmCounter,
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Restarts the timer and increments the counter.
                alarmCounter += 1;
                myTimer.Enabled = true;
            }
            else
            {
                // Stops the timer.
                exitFlag = true;
            }
        }

        protected override void OnStop()
        {
            
        }
    }
}
