using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace GravityBallScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    // Get the 2 character command line argument
                    string arg = args[0].ToLower(CultureInfo.InvariantCulture).Trim().Substring(0, 2);
                    switch (arg)
                    {
                        case "/c":
                            // Show the options dialog
                            ShowOptions();
                            break;
                        case "/p":
                            // Don't do anything for preview
                            break;
                        case "/s":
                            // Show screensaver form
                            ShowScreenSaver();
                            break;
                        default:
                            MessageBox.Show("Invalid command line argument :" + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    // If no arguments were passed in, show the screensaver
                    ShowScreenSaver();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"D:\Temp\Screensaver.log", true, System.Text.Encoding.ASCII, 256);

                    sw.WriteLine();
                    sw.WriteLine("An error has occurred");
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(ex.ToString());
                    sw.Flush();
                    sw.Close();
                    sw = null;
                }
                catch
                {
                }
            }
        }


        static void ShowOptions()
        {
            frmOptions options = new frmOptions();
            Application.Run(options);
        }

        static void ShowScreenSaver()
        {

            // Create the MyApplicationContext, that derives from ApplicationContext,
            // that manages when the application should exit.

            ScreenSaverContext context = new ScreenSaverContext();

            // Run the application with the specific context. It will exit when
            // all forms are closed.
            Application.Run(context);
        }
    }
}