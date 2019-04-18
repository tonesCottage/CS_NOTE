using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace YahooWeather
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(369, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "查天气";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(32, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "北京";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(32, 88);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(433, 183);
            this.dataGrid1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(504, 305);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

		
		}


		public static DataSet GetYahooWeather(string strCityName)
		{
			string strXml = "http://xml.weather.yahoo.com/forecastrss?p=CHXX" + CityNameToCityNum(strCityName);

			XmlDocument Weather = new XmlDocument();
			Weather.Load(strXml);

			XmlNamespaceManager namespacemanager = new 
				XmlNamespaceManager(Weather.NameTable);
			namespacemanager.AddNamespace("yweather", 
				"http://xml.weather.yahoo.com/ns/rss/1.0");
			XmlNodeList nodes = Weather.SelectNodes("/rss/channel/item/yweather:forecast", namespacemanager);

			//XmlNodeList nodes = Weather.GetElementsByTagName("forecast", "http://xml.weather.yahoo.com/ns/rss/1.0");

			DataSet dstWeather = new DataSet();
			DataTable dtblWeather = new DataTable("Weather");
			dstWeather.Tables.Add(dtblWeather);

			dstWeather.Tables["Weather"].Columns.Add("Date", typeof(string));
			dstWeather.Tables["Weather"].Columns.Add("Week", typeof(string));
			dstWeather.Tables["Weather"].Columns.Add("Weather", typeof(string));
			dstWeather.Tables["Weather"].Columns.Add("Tlow", typeof(string));
			dstWeather.Tables["Weather"].Columns.Add("Thigh", typeof(string));

			if (nodes.Count > 0)
			{
				foreach (XmlNode node in nodes)
				{
					DataRow drowWeather = dstWeather.Tables["Weather"].NewRow();

					drowWeather["Date"] = EmonthToCmonth(node.SelectSingleNode
						("@date").Value.ToString());
					drowWeather["Week"] = EweekToCweek(node.SelectSingleNode
						("@day").Value.ToString()) + "(" + node.SelectSingleNode("@day").Value.ToString() 
						+ ")";
					drowWeather["Weather"] = node.SelectSingleNode("@text").Value;
					drowWeather["Tlow"] = FToC(int.Parse(node.SelectSingleNode
						("@low").Value)) + "℃";
					drowWeather["Thigh"] = FToC(int.Parse(node.SelectSingleNode
						("@high").Value)) + "℃";

					dstWeather.Tables["Weather"].Rows.Add(drowWeather);
				}

				return dstWeather;
			}
			else
			{
				DataRow drowNone = dstWeather.Tables["Weather"].NewRow();
				drowNone["Week"] = "None";
				drowNone["Weather"] = "None";
				drowNone["Tlow"] = "None";
				drowNone["Thigh"] = "None";

				dstWeather.Tables["Weather"].Rows.Add(drowNone);
				return dstWeather;
			}

			return dstWeather;
		}

		/**//// <summary>
		/// 从华氏转换成摄氏
		/// </summary>
		/// <param name="f">华氏度</param>
		/// <returns></returns>
		private static string FToC(int f)
		{
			return Math.Round((f - 32) / 1.8, 1).ToString();
		}

		/**//// <summary>
		/// 从星期英文缩写转汉字
		/// </summary>
		/// <param name="strEweek">星期的英文缩写</param>
		/// <returns></returns>
		private static string EweekToCweek(string strEweek)
		{
			switch (strEweek)
			{
				case "Mon":
					return "星期一";
					break;
				case "Tue":
					return "星期二";
					break;
				case "Wed":
					return "星期三";
					break;
				case "Thu":
					return "星期四";
					break;
				case "Fri":
					return "星期五";
					break;
				case "Sat":
					return "星期六";
					break;
				case "Sun":
					return "星期日";
					break;
				default:
					return "传参错误";
					break;
			}
		}

		/**//// <summary>
		/// 从月英文缩写转汉字
		/// </summary>
		/// <param name="strReplace">需要替换的年月日</param>
		/// <returns></returns>
		private static string EmonthToCmonth(string strReplace)
		{
			return Convert.ToDateTime(strReplace).ToString("yyyy年MM月dd日");
		}

		/**//// <summary>
		/// 根据城市名称返回城市编号
		/// </summary>
		/// <param name="strCityName">城市名称</param>
		/// <returns></returns>
		private static string CityNameToCityNum(string strCityNameToNum)
		{
			//中国各个省会和直辖市对应的查询代码
			Hashtable htWeather = new Hashtable();
			htWeather.Add("北京", "0008");
			htWeather.Add("天津", "0133");
			htWeather.Add("杭州", "0044");
			htWeather.Add("合肥", "0448");
			htWeather.Add("上海", "0116");
			htWeather.Add("福州", "0031");
			htWeather.Add("重庆", "0017");
			htWeather.Add("南昌", "0097");
			htWeather.Add("香港", "0049");
			htWeather.Add("济南", "0064");
			htWeather.Add("澳门", "0512");
			htWeather.Add("郑州", "0165");
			htWeather.Add("呼和浩特", "0249");
			htWeather.Add("乌鲁木齐", "0135");
			htWeather.Add("长沙", "0013");
			htWeather.Add("银川", "0259");
			htWeather.Add("广州", "0037");
			htWeather.Add("拉萨", "0080");
			htWeather.Add("海口", "0502");
			htWeather.Add("南宁", "0100");
			htWeather.Add("成都", "0016");
			htWeather.Add("石家庄", "0122");
			htWeather.Add("贵阳", "0039");
			htWeather.Add("太原", "0129");
			htWeather.Add("昆明", "0076");
			htWeather.Add("沈阳", "0119");
			htWeather.Add("西安", "0141");
			htWeather.Add("长春", "0010");
			htWeather.Add("兰州", "0079");
			htWeather.Add("西宁", "0236");
			htWeather.Add("南京", "0099");

			object cityNum = htWeather[strCityNameToNum];

			if (cityNum == null)
			{
				return "City not found";
			}
			else
			{
				return cityNum.ToString();
			}
		}



		#region 以下为测试代码

		private void Test()
		{
			string s = GetPageAsString( "http://xml.weather.yahoo.com/forecastrss?p=94704"); 
			System.Console.Write( s );

			A();
			B();
			C();
			DataSetSample1();
		}

			public static string GetPageAsString(string address)   
			{   
				string result = "";   
  
				// Create the web request   
				HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;   
  
				// Get response   
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)   
				{   
					// Get the response stream   
					StreamReader reader = new StreamReader(response.GetResponseStream());   
  
					// Read the whole contents and return as a string   
					result = reader.ReadToEnd();   
				}   
  
				return result;   
			}   



		public void A()
		{

			// Retrieve XML document   
			XmlTextReader reader = new XmlTextReader("http://xml.weather.yahoo.com/forecastrss?p=94704");   
  
			// Skip non-significant whitespace   
			reader.WhitespaceHandling = WhitespaceHandling.Significant;   
  
			// Read nodes one at a time   
			while (reader.Read())   
			{   
				// Print out info on node   
				Console.WriteLine("{0}: {1}", reader.NodeType.ToString(), reader.Name);   
			}   
		}

		public void B()
		{
			//C# XmlDocument Sample
			// XmlDocument提供更多的机动性，并且如果你需要经过DOM操作数据，它是一个好的选择。它还作为XslTransform类的数据源，是你可以执行 XSl的格式转换。

				// Create a new XmlDocument   
				XmlDocument doc = new XmlDocument();   
  
			// Load data   
			doc.Load("http://xml.weather.yahoo.com/forecastrss?p=94704");   
  
			// Set up namespace manager for XPath   
			XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);   
			ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");   
  
			// Get forecast with XPath   
			XmlNodeList nodes = doc.SelectNodes("//rss/channel/item/yweather:forecast", ns);   
  
			// You can also get elements based on their tag name and namespace,   
			// though this isn't recommended   
			//XmlNodeList nodes = doc.GetElementsByTagName("forecast",    
			//                          "http://xml.weather.yahoo.com/ns/rss/1.0");   
  
			foreach(XmlNode node in nodes)   
			{   
				Console.WriteLine("{0}: {1}, {2}F - {3}F",   
					node.Attributes["day"].InnerText,   
					node.Attributes["text"].InnerText,   
					node.Attributes["low"].InnerText,   
					node.Attributes["high"].InnerText);   
			}   
		}


		public void C()
		{
			// XpathDocument使用Xpath提供对Xml数据源的快速的只读访问。它的作用和在XmlDocument中使用Xpath类似。
			//C# XPathDocument 示例：
			// Create a new XmlDocument   
			XPathDocument doc = new XPathDocument("http://xml.weather.yahoo.com/forecastrss?p=94704");   
  
			// Create navigator   
			XPathNavigator navigator = doc.CreateNavigator();   
  
			// Set up namespace manager for XPath   
			XmlNamespaceManager ns = new XmlNamespaceManager(navigator.NameTable);   
			ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");   
  
			// Get forecast with XPath   
			
			XPathNodeIterator nodes = navigator.Select("//rss/channel/item/forecast"); //, ns);  //yweather: 
  
			while(nodes.MoveNext())   
			{   
				XPathNavigator node = nodes.Current;   
  
				Console.WriteLine("{0}: {1}, {2}F - {3}F",   
					node.GetAttribute("day", ns.DefaultNamespace),   
					node.GetAttribute("text", ns.DefaultNamespace),   
					node.GetAttribute("low", ns.DefaultNamespace),   
					node.GetAttribute("high", ns.DefaultNamespace));   
			}   
		}

		public static void DataSetSample1()   
		{   
			// Create the web request   
			HttpWebRequest request    
				= WebRequest.Create("http://xml.weather.yahoo.com/forecastrss?p=94704") as HttpWebRequest;   
  
			// Get response   
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)   
			{   
				// Load data into a dataset   
				DataSet dsWeather = new DataSet();   
				dsWeather.ReadXml(response.GetResponseStream());   
  
				// Print dataset information   
				PrintDataSet(dsWeather);   
			}   
		}   
  
		public static void PrintDataSet(DataSet ds)   
		{   
			// Print out all tables and their columns   
			foreach (DataTable table in ds.Tables)   
			{   
				Console.WriteLine("TABLE '{0}'", table.TableName);   
				Console.WriteLine("Total # of rows: {0}", table.Rows.Count);   
				Console.WriteLine("---------------------------------------------------------------");   
  
				foreach (DataColumn column in table.Columns)   
				{   
					Console.WriteLine("- {0} ({1})", column.ColumnName, column.DataType.ToString());   
				}  // foreach column   
  
				Console.WriteLine(System.Environment.NewLine);   
			}  // foreach table   
  
			// Print out table relations   
			foreach (DataRelation relation in ds.Relations)   
			{   
				Console.WriteLine("RELATION: {0}", relation.RelationName);   
				Console.WriteLine("---------------------------------------------------------------");   
				Console.WriteLine("Parent: {0}", relation.ParentTable.TableName);   
				Console.WriteLine("Child: {0}", relation.ChildTable.TableName);   
				Console.WriteLine(System.Environment.NewLine);   
			}  // foreach relation   
		}   
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.dataGrid1.DataSource = GetYahooWeather( this.textBox1.Text.Trim() ).Tables[0];
		}


	}
}
