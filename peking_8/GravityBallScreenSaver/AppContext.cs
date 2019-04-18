using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace GravityBallScreenSaver
{
    // A simple form that represents a window in our application
    // The class that handles the creation of the application windows
    class ScreenSaverContext : ApplicationContext
    {
        private frmGravityBall[] fs;
        private bool closing = false;
        int formCount = 0;

        public ScreenSaverContext()
        {
            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            // Create both application forms and handle the Closed event
            // to know when both forms are closed.
            fs = new frmGravityBall[Screen.AllScreens.Length];
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                formCount++;
                fs[i] = new frmGravityBall(i);
                fs[i].Closed += new EventHandler(OnFormClosed);
                fs[i].Closing += new CancelEventHandler(OnFormClosing);
                fs[i].Show();
                fs[i].Refresh();
            }

            //this.MainForm = fs[0];

            //fs[1].Show();
            //fs[1].Refresh();

            //fs[0].Show();
            //fs[0].Refresh();

            //foreach (Form f in fs)
            //{
            //    f.Show();
            //    f.Refresh();
            //}
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
        }

        private void OnFormClosing(object sender, CancelEventArgs e)
        {
            //when one form closes, close all
            if (!closing)
            {
                closing = true;
                foreach (frmGravityBall f in fs)
                {
                    try
                    {
                        f.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            // When a form is closed, decrement the count of open forms.

            // When the count gets to 0, exit the app by calling
            // ExitThread().
            formCount--;
            if (formCount == 0)
            {
                ExitThread();
            }
        }
    }
}