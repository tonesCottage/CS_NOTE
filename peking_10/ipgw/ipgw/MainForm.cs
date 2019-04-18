//#define WEBPAGEMODE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Management;
using System.Runtime.InteropServices;

namespace ipgw
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.notifyIcon1.Icon = this.Icon;
        }
#if WEBPAGEMODE
        static bool Logedin = false;
#endif
        static CookieContainer CC = new CookieContainer();
        static string file = Application.StartupPath + @"\ipgw.xml";
        static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        DateTime timeForFee = new DateTime(0);

        private void Ready(bool ready)
        {
            if (ready)
            {
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = true;
                btnDisconnectAll.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = false;
                btnDisconnectAll.Enabled = false;
            }
        }

        private void StatusUpdate(string ip, string mode, string moneyLeft, 
            string name, string num, string range, string status,
            string timeused, string updatetime)
        {
            lblIP.Text = ip;
            lblMode.Text = mode;
            lblMoneyLeft.Text = moneyLeft;
            lblName.Text = name;
            lblNum.Text = num;
            lblRange.Text = range;
            lblStatus.Text = status;
            lblTimeUsed.Text = timeused;
            lblUpdateTime.Text = updatetime;
        }

        private HttpWebRequest SendRequest(string url)
        {
            HttpWebRequest request;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            catch
            {
                MessageBox.Show("无法连接校园网服务");
                request = null;
            }
            return request;
        }

        private string GetResponse(HttpWebRequest request, 
            CookieContainer cc, Encoding encoding)
        {
            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch
            {
                MessageBox.Show("服务器无响应");
                return "";
            }
            StreamReader streamreader =
                new StreamReader(response.GetResponseStream(), encoding);
            if (response.Cookies.Count > 0)
                cc.Add(response.Cookies);
            return streamreader.ReadToEnd();
        }

        private string PostData(string postdata, string posturl, 
            CookieContainer cc, Encoding encoding)
        {
            HttpWebRequest request = SendRequest(posturl);
            if (request == null)
                return "";
            byte[] postbyte = Encoding.ASCII.GetBytes(postdata);
            request.UserAgent = "Mozilla/5.0";
            request.Method = "POST";
            request.ContentLength = postdata.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cc;
            Stream stream = null;
            try
            {
                stream = request.GetRequestStream();
            }
            catch
            {
                MessageBox.Show("无法连接校园网服务");
                return "";
            }
            stream.Write(postbyte, 0, postbyte.Length);
            return GetResponse(request, cc, encoding);
        }
#if WEBPAGEMODE
        private string MakePostData(string name, string pass, string mode)
        {
            string magicword = "%7C%3BkiDrqvfi7d%24v0p5Fg72Vwbv2%3B%7C";
            string postdata = "username1=" + name;
            postdata += "&password=" + pass;
            postdata += "&pwd_t=%E5%AF%86%E7%A0%81";
            postdata += "&fwrd=" + mode;
            postdata += "&username=" + name;
            postdata += magicword + pass + magicword + 12;//12free
            return postdata;
        }
#endif

        private string MakePostDataWlan(string name, string pass, string mode)
        {
            string range;
            string operation;
            switch (mode)
            {
                case "free": range = "2"; operation = "connect"; break;
                case "fee": range = "1"; operation = "connect"; break;
                case "disconnectall": range = "4"; operation = "disconnectall"; break;
                default: range = "2"; operation = "disconnect"; break;
            }
            string postdata = "uid=" + name;
            postdata += "&password=" + pass;
            postdata += "&range=" + range;
            postdata += "&operation=" + operation;
            postdata += "&timeout=1";
            return postdata;
        }


        #region 信息加密解密码
        private string Encrypt(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream,
                    dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return "Encrypt Failed";
            }
        }

        private string Decrypt(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream,
                    dCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return "Decrypt Failed";
            }
        }

        private string GetEncryptKey()
        {
            string mbID = "";
            ManagementObjectSearcher mos = 
                new ManagementObjectSearcher("select * from Win32_baseboard");
            foreach (ManagementObject mo in mos.Get())
            {
                mbID = mo["SerialNumber"].ToString().Substring(0, 8);
                break;
            }
            return mbID;
        }

        private XmlDocument CreateXml(string file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDoc.AppendChild(xmlDecl);
            XmlElement xmlEle = xmlDoc.CreateElement("NameList");//root
            xmlDoc.AppendChild(xmlEle);
            xmlDoc.Save(file);
            return xmlDoc;//
        }

        #endregion

        #region 信息保存与读取
        /// <summary>
        /// write(add or change) name and pass to file
        /// if name doesnt exist add node to file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        private void StoreInfo(string name, string pass)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (!File.Exists(file))
                    xmlDoc = CreateXml(file);
                else
                    xmlDoc.Load(file);

                bool nameExist = false;
                XmlNodeList nodes = xmlDoc.SelectNodes("NameList/NameList");
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["NAME"].InnerXml == name)
                    {
                        node.Attributes["KEY"].InnerXml = 
                            Encrypt(pass, GetEncryptKey());
                        node.Attributes["LAST"].InnerXml = "true";
                        nameExist = true;
                    }
                    else
                    {
                        node.Attributes["LAST"].InnerXml = "false";
                    }
                }

                //prevent from creating extra nodes
                if (!nameExist)
                {
                    XmlNode root = xmlDoc.SelectSingleNode("NameList");
                    XmlElement ele = xmlDoc.CreateElement("NameList");
                    ele.SetAttribute("NAME", name);
                    ele.SetAttribute("KEY", Encrypt(pass, GetEncryptKey()));
                    ele.SetAttribute("LAST", "true");
                    root.AppendChild(ele);
                }
                xmlDoc.Save(file);
            }
            catch
            {
                return;
            }
            
        }
        /// <summary>
        /// Add names into comboBox and
        /// if AutoFillLastInfo true fill name and pass automatically
        /// </summary>
        /// <param name="AutoFillLastInfo">
        /// Fill name and pass with last used one
        /// </param>
        private void LoadInfo(bool AutoFillLastInfo)
        {
            cbName.Items.Clear();
            if (!File.Exists(file))
                return;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                XmlNodeList nodes = xmlDoc.SelectNodes("NameList/NameList");
                foreach (XmlNode node in nodes)
                {
                    cbName.Items.Add(node.Attributes["NAME"].InnerXml);
                    //auto fill name and pass with last used one
                    if (AutoFillLastInfo && node.Attributes["LAST"].InnerXml == "true")
                    {
                        cbName.Text = node.Attributes["NAME"].InnerXml;
                        tbPass.Text = Decrypt(node.Attributes["KEY"].InnerXml,
                            GetEncryptKey());
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void DeleteInfo(string name)
        {
            if (!File.Exists(file))
                return;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                XmlNodeList nodes = xmlDoc.SelectNodes("NameList/NameList");
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["NAME"].InnerXml == name)
                    {
                        node.ParentNode.RemoveChild(node);
                        xmlDoc.Save(file);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private string ReadInfo(string name)
        {
            string pass = "";
            if (!File.Exists(file))
                return pass;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file);
                XmlNodeList nodes = xmlDoc.SelectNodes("NameList/NameList");
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["NAME"].InnerXml == name)
                    {
                        pass = Decrypt(node.Attributes["KEY"].InnerXml, 
                            GetEncryptKey());
                    }
                }
                return pass;
            }
            catch
            {
                return pass;
            }
        }

        #endregion


#if WEBPAGEMODE
        private void Login(string name, string pass)
        {
            string postdata = MakePostData(name, pass, "free");
            string response = PostData(postdata, "https://its.pku.edu.cn/cas/login", 
                CC, Encoding.UTF8);
#endif
#if WEBPAGEMODE && DEBUG
            textBox1.Text = response;
#endif
#if WEBPAGEMODE
            if (response == "")
            {
                Logedin = false;
                return;
            }
            Regex regex = new Regex("Username or Password error");
            if (regex.IsMatch(response))
            {
                StatusUpdate("", "", "", name, "", "", "用户名/密码错误！", "", "");
                Logedin = false;
            }
            else
            {
                StatusUpdate("", "", "", name, "", "", "已登陆", "", "");
                Logedin = true;
            }
        }
#endif

        private void StatusUpdate_Connect(string responsedata)
        {
            Regex regex = new Regex("Connect successfully");
            Regex regex2 = new Regex("没有访问收费地址的权限");
            Regex regex3 = new Regex("当前连接数");
            if (responsedata == "")
            {
                StatusUpdate("", "", "", "", "", "", "", "", "");
                return;
            }

            if(regex2.IsMatch(responsedata))
            {
                StatusUpdate(lblIP.Text, lblMode.Text, 
                    lblMoneyLeft.Text, lblName.Text, lblNum.Text, lblRange.Text, 
                    "没有访问权限收费地址", lblTimeUsed.Text, lblUpdateTime.Text);
                return;
            }
            else if(regex3.IsMatch(responsedata))
            {
                StatusUpdate("", "", "", "", "", "", "当前连接数超过预定值", "", "");
                return;
            }
            else if(!regex.IsMatch(responsedata))
            {
                StatusUpdate("", "", "", "", "", "", "连接失败", "", "");
                return;
            }

            try
            {
                string ip = responsedata.Substring(responsedata.IndexOf("当前地址"), 30);
                Match mip = Regex.Match(ip, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");

                string mode = responsedata.Substring(responsedata.IndexOf("包月状态") + 14, 20);
                Match mmode = Regex.Match(mode, @"[0-9\u4e00-\u9fa5]+");

                string range = responsedata.Substring(responsedata.IndexOf("访问范围") + 14, 10);
                Match mrange = Regex.Match(range, @"[、\u4e00-\u9fa5]+");

                string moneyleft = responsedata.Substring(responsedata.IndexOf(" 元") - 13, 13);
                Match mmoneyleft = Regex.Match(moneyleft, @"\d{1,4}.\d{1,4}");

                string name = responsedata.Substring(responsedata.IndexOf("用&nbsp;户&nbsp;名") + 25, 8);
                Match mname = Regex.Match(name, @"[\u4e00-\u9fa5]+");

                string num = responsedata.Substring(responsedata.IndexOf("当前连接") + 14, 1);

                string time = responsedata.Substring(responsedata.IndexOf("当前时间") + 14, 20);
                Match mtime = Regex.Match(time, @"[0-9]{1,2}.+[0-9]{1,2}");

                Regex regex_timeused = new Regex("包月累计时长");
                string timeused = "";
                if (regex_timeused.IsMatch(responsedata))
                    timeused = responsedata.Substring(responsedata.IndexOf("包月累计时长") + 15, 13);
                Match mtimeused = Regex.Match(timeused, @"\d{1,4}.\d{1,4}");

                StatusUpdate(mip.Value, mmode.Value, mmoneyleft.Value + "元", mname.Value,
                    num, mrange.Value, "已连接", mtimeused.Value + "小时", mtime.Value);
            }
            catch //catch StartIndex error or StringMissMatch error
            {
                StatusUpdate("", "", "", "", "", "", "已连接", "", "信息无法正常显示");
            }
        }

        private void StatusUpdate_Disconnect(string responsedata)
        {
            string ip = responsedata.Substring(responsedata.IndexOf("址"), 30);
            Match mip = Regex.Match(ip, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");

            string time = responsedata.Substring(responsedata.IndexOf("当前时间") + 14, 20);
            Match mtime = Regex.Match(time, @"[0-9]{1,2}.+[0-9]{1,2}");

            StatusUpdate(mip.Value, "", "", cbName.Text,
                "", "", "断开当前连接成功", "", mtime.Value);
        }

        private void Loading(bool loading)
        {
            if (loading)
            {
                picWait.Visible = true;
                //this.Enabled = false;
            }
            else
            {
                //this.Enabled = true;
                picWait.Visible = false;
            }
        }

        private void OperateInfo()
        {
            if (cbSave.Checked == true)
            {
                StoreInfo(cbName.Text, tbPass.Text);
                LoadInfo(false);
                //FIXME
            }
            else
            {
                DeleteInfo(cbName.Text);
                LoadInfo(false);
            }
        }
#if WEBPAGEMODE
        private void Connect(bool free)
        {
            //Disconnect();
            OperateInfo();
            if (!Logedin)
            {
                StatusUpdate("", "", "", cbName.Text, "", "", "登陆中...", "", "");
                Login(cbName.Text, tbPass.Text);
            }
            if (!Logedin)
            {
                StatusUpdate("", "", "", cbName.Text, "", "", "无法登陆网关", "", "");
                return;
            }

            HttpWebRequest request;
            if (free)
                request = SendRequest("https://its.pku.edu.cn/netportal/ipgwopen");
            else
                request = SendRequest("https://its.pku.edu.cn/netportal/ipgwopenall");
            if (request == null)
                return;
            request.CookieContainer = CC;
            string responsedata = GetResponse(request, CC, Encoding.UTF8);
#endif
#if WEBPAGEMODE && DEBUG
            textBox1.Text = responsedata;
#endif
#if WEBPAGEMODE
            StatusUpdate_Connect(responsedata);
        }
#endif

        private void ConnectWlan(bool free)
        {
            StatusUpdate("", "", "", cbName.Text, "", "", "连接中...", "", "");

            string postdata;
            if(free)
                postdata = MakePostDataWlan(cbName.Text, tbPass.Text, "free");
            else
                postdata = MakePostDataWlan(cbName.Text, tbPass.Text, "fee");
            string response = PostData(postdata, "https://its.pku.edu.cn:5428/ipgatewayofpku", 
                CC, Encoding.GetEncoding("GB2312"));
#if WEBPAGEMODE && DEBUG
            //textBox2.Text = response;
#endif
            if (response == "")
            {
                StatusUpdate("", "", "", "", "", "", "无法连接校园网服务", "", "");
                return;
            }
            Regex regex = new Regex("口令错误");
            Regex regex2 = new Regex("Connect successfully");
            if (regex.IsMatch(response))
            {
                StatusUpdate("", "", "", cbName.Text, "", "", "用户名/密码错误", "", "");
            }
            else if (regex2.IsMatch(response))
            {
                StatusUpdate_Connect(response);
            }
            else
            {
                StatusUpdate("", "", "", "", "", "", "连接失败", "", "");
            }
            OperateInfo();
#if WEBPAGEMODE
            Logedin = false;
#endif
        }
#if WEBPAGEMODE
        private void Disconnect(bool all)
        {
            OperateInfo();
            if (!Logedin)
            {
                StatusUpdate("", "", "", cbName.Text, "", "", "登陆中...", "", "");
                Login(cbName.Text, tbPass.Text);
            }
            if (!Logedin)
            {
                StatusUpdate("", "", "", cbName.Text, "", "", "无法登陆网关", "", "");
                return;
            }

            HttpWebRequest request;
            if (all)
                request = SendRequest("https://its.pku.edu.cn/netportal/ipgwcloseall");
            else
                request = SendRequest("https://its.pku.edu.cn/disconnetipgw.do");
            request.CookieContainer = CC;
            if (request == null)
                return;
            string responsedata = GetResponse(request, CC, Encoding.GetEncoding("GB2312"));
            if (responsedata == "")
                return;
            Regex regex = new Regex("Disconnect All Succeeded");
            Regex regex2 = new Regex("Disconnect Succeeded");
#endif
#if WEBPAGEMODE && DEBUG
            textBox2.Text = responsedata;
#endif
#if WEBPAGEMODE
            if (regex.IsMatch(responsedata))
                StatusUpdate("", "", "", cbName.Text, "", "",
                    "已断开所有连接", "", DateTime.Now.ToString());
            else if (regex2.IsMatch(responsedata))
                StatusUpdate_Disconnect(responsedata);
            else
                StatusUpdate("", "", "", "", "", "", "断开连接失败", "", "");
        }
#endif

        private void DisconnectWlan(bool all)
        {
            StatusUpdate("", "", "", cbName.Text, "", "", "断开连接中...", "", "");

            string  postdata;
            if (all)
                postdata = MakePostDataWlan(cbName.Text, tbPass.Text, "disconnectall");
            else
                postdata = MakePostDataWlan("", "", "disconnect");

            string response = PostData(postdata, "https://its.pku.edu.cn:5428/ipgatewayofpku", 
                CC, Encoding.GetEncoding("GB2312"));
#if WEBPAGEMODE && DEBUG
            textBox1.Text = response;
#endif
            if (response == "")
            {
                StatusUpdate("", "", "", "", "", "", "无法连接校园网服务", "", "");
                return;
            }
            Regex regex = new Regex("口令错误");
            Regex regex2 = new Regex("Disconnect All Succeeded");
            Regex regex3 = new Regex("Disconnect Succeeded");
            if (regex.IsMatch(response))
            {
                StatusUpdate("", "", "", cbName.Text, "", "", "用户名/密码错误", "", "");
            }
            else if(regex2.IsMatch(response))
            {
                StatusUpdate("", "", "", cbName.Text, "0", "",
                    "已断开所有连接", "", DateTime.Now.ToString());
            }
            else if (regex3.IsMatch(response))
            {
                StatusUpdate_Disconnect(response);
            }
            else
            {
                StatusUpdate("", "", "", "", "", "", "断开连接失败", "", "");
            }
            OperateInfo();
#if WEBPAGEMODE
            Logedin = false;
#endif
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r= MessageBox.Show("是否退出程序(选“是”则退出，选“否”则最小化到系统托盘）","IPGW", MessageBoxButtons.YesNoCancel );
            if (r == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
                Application.Exit();
            }
            else if (r == DialogResult.No)
            {
                btnMin_Click(null, null);
            }
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        private void btnMail_Click(object sender, EventArgs e)
        {
           //InternetSetCookie(
           //          "http://" + CC.Domain.ToString(),
           //          CC.Name.ToString(),
           //          CC.Value.ToString() + ";;expires=Sun,22-Feb-2099 00:00:00 GMT");
           // }
            System.Diagnostics.Process.Start("explorer.exe", "https://mail.pku.edu.cn");
        }

        private void btnDisconnectAll_Click(object sender, EventArgs e)
        {
            Loading(true);
#if WEBPAGEMODE
            if (cbWlan.Checked == false)
                Disconnect(true);
            else
#endif
                DisconnectWlan(true);
            Loading(false);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Loading(true);
#if WEBPAGEMODE
            if (cbWlan.Checked == false)
                Disconnect(false);
            else
#endif
                DisconnectWlan(false);
                this.timeForFee = new DateTime(0);
            Loading(false);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Loading(true);
#if WEBPAGEMODE
            if (cbWlan.Checked == false)
            {
                Connect(rbFree.Checked);
            }
            else
#endif
            {
                ConnectWlan(rbFree.Checked);

                if (rbFee.Checked) timeForFee = DateTime.Now;
                else timeForFee = new DateTime(0);
            }
            Loading(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadInfo(true);
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPass.UseSystemPasswordChar = true;
            tbPass.Text = ReadInfo(cbName.Text);
        }

        private void cbName_TextChanged(object sender, EventArgs e)
        {
            if (cbName.Text != "" && cbName.Text != "用户名"
                && tbPass.Text != "" && tbPass.Text != "密  码")
                Ready(true);
            else
                Ready(false);

            CC = new CookieContainer();
            tbPass.Text = "";
#if WEBPAGEMODE
            Logedin = false;
#endif
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            if (cbName.Text != "" && cbName.Text != "用户名"
                && tbPass.Text != "" && tbPass.Text != "密  码")
                Ready(true);
            else
                Ready(false);
            CC = new CookieContainer();
#if WEBPAGEMODE
            Logedin = false;
#endif
        }

        private void cbName_Leave(object sender, EventArgs e)
        {
            if (cbName.Text == "")
            {
                cbName.Text = "用户名";
            }
        }

        private void tbPass_Leave(object sender, EventArgs e)
        {
            if (tbPass.Text == "")
            {
                tbPass.UseSystemPasswordChar = false;
                tbPass.Text = "密  码";
            }
        }

        private void cbName_Enter(object sender, EventArgs e)
        {
            cbName.SelectAll();
        }

        private void tbPass_Enter(object sender, EventArgs e)
        {
            tbPass.Text = "";
            tbPass.UseSystemPasswordChar = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString();
        }
#if WEBPAGEMODE
        private void cbWlan_MouseHover(object sender, EventArgs e)
        {
            toolTipWlan.Show("链接WirelessPKU请勾选此项", cbWlan);
        }
#endif
        /// <summary>
        /// Move of boarderless WinForm
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wparam"></param>
        /// <param name="lparam"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wparam, int lparam);
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键   
            {
                Capture = false;//释放鼠标，使能够手动操作   
                SendMessage(this.Handle, 0x00A1, 2, 0);//拖动窗体   
            }
        }
        /// <summary>
        /// ExitButton Picture Chang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            btnExit.BackgroundImage = ipgw.Properties.Resources.btnExitLight;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = ipgw.Properties.Resources.btnExitDark;
        }
        /// <summary>
        /// btnMin behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

        private void btnMin_MouseMove(object sender, MouseEventArgs e)
        {
            btnMin.BackgroundImage = ipgw.Properties.Resources.btnMinLight;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackgroundImage = ipgw.Properties.Resources.btnMinDark;
        }

        private void timerCheckTimeFee_Tick(object sender, EventArgs e)
        {
            if (this.timeForFee.Ticks == 0) return;
            int t = 15;
            int.TryParse(this.txtTimeFee.Text, out t);
            if ((DateTime.Now - this.timeForFee).Minutes > t) //超过一定时间，则自动断开收费连接
            {
                rbFee.Checked = true;
                btnDisconnect_Click(null, null);
                rbFree.Checked = true;
                btnConnect_Click(null, null);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

    }
}
