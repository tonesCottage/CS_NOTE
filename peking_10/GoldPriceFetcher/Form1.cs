using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoldPriceFetcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Icon = this.Icon;
            timer1.Interval = 15000;
            timer1.Enabled = true;
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            notifyIcon1.Text = FetchData();
        }

        private static string DataUrl = "http://quote.zhijinwang.com/xml/ag.txt?";

        public static string FetchData()
        {
            string url = DataUrl + ToJsTime(DateTime.Now);

            try
            {

                System.Net.WebClient client = new System.Net.WebClient();
                //client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                client.Headers.Add("Referer", "http://quote.zhijinwang.com/ag.swf");

                byte[] data = client.DownloadData(url);
                string msg = System.Text.Encoding.Default.GetString(data);

                //  time=17:33:39&gold=|4.45|4.43|4.47|4.57|4.44|22.63|81.59|107.7
                string tag = "gold=|";
                if (msg.IndexOf(tag) >= 0)
                {
                    msg = msg.Substring(msg.IndexOf(tag) + tag.Length);
                    string[] words = msg.Split('|');
                    return words[0];
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return "";
        }

        private static DateTime Time1970 = new DateTime(1970, 1, 1);
        private static long ToJsTime(DateTime time)
        {
            TimeSpan ts = time - Time1970;
            return (long)ts.TotalMilliseconds;
        }


    }
}
