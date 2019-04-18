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
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
            this.button1.Text = "������";
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
            this.textBox1.Text = "����";
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
		/// Ӧ�ó��������ڵ㡣
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
						("@low").Value)) + "��";
					drowWeather["Thigh"] = FToC(int.Parse(node.SelectSingleNode
						("@high").Value)) + "��";

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
		/// �ӻ���ת��������
		/// </summary>
		/// <param name="f">���϶�</param>
		/// <returns></returns>
		private static string FToC(int f)
		{
			return Math.Round((f - 32) / 1.8, 1).ToString();
		}

		/**//// <summary>
		/// ������Ӣ����дת����
		/// </summary>
		/// <param name="strEweek">���ڵ�Ӣ����д</param>
		/// <returns></returns>
		private static string EweekToCweek(string strEweek)
		{
			switch (strEweek)
			{
				case "Mon":
					return "����һ";
					break;
				case "Tue":
					return "���ڶ�";
					break;
				case "Wed":
					return "������";
					break;
				case "Thu":
					return "������";
					break;
				case "Fri":
					return "������";
					break;
				case "Sat":
					return "������";
					break;
				case "Sun":
					return "������";
					break;
				default:
					return "���δ���";
					break;
			}
		}

		/**//// <summary>
		/// ����Ӣ����дת����
		/// </summary>
		/// <param name="strReplace">��Ҫ�滻��������</param>
		/// <returns></returns>
		private static string EmonthToCmonth(string strReplace)
		{
			return Convert.ToDateTime(strReplace).ToString("yyyy��MM��dd��");
		}

		/**//// <summary>
		/// ���ݳ������Ʒ��س��б��
		/// </summary>
		/// <param name="strCityName">��������</param>
		/// <returns></returns>
		private static string CityNameToCityNum(string strCityNameToNum)
		{
			//�й�����ʡ���ֱϽ�ж�Ӧ�Ĳ�ѯ����
			Hashtable htWeather = new Hashtable();
			htWeather.Add("����", "0008");
			htWeather.Add("���", "0133");
			htWeather.Add("����", "0044");
			htWeather.Add("�Ϸ�", "0448");
			htWeather.Add("�Ϻ�", "0116");
			htWeather.Add("����", "0031");
			htWeather.Add("����", "0017");
			htWeather.Add("�ϲ�", "0097");
			htWeather.Add("���", "0049");
			htWeather.Add("����", "0064");
			htWeather.Add("����", "0512");
			htWeather.Add("֣��", "0165");
			htWeather.Add("���ͺ���", "0249");
			htWeather.Add("��³ľ��", "0135");
			htWeather.Add("��ɳ", "0013");
			htWeather.Add("����", "0259");
			htWeather.Add("����", "0037");
			htWeather.Add("����", "0080");
			htWeather.Add("����", "0502");
			htWeather.Add("����", "0100");
			htWeather.Add("�ɶ�", "0016");
			htWeather.Add("ʯ��ׯ", "0122");
			htWeather.Add("����", "0039");
			htWeather.Add("̫ԭ", "0129");
			htWeather.Add("����", "0076");
			htWeather.Add("����", "0119");
			htWeather.Add("����", "0141");
			htWeather.Add("����", "0010");
			htWeather.Add("����", "0079");
			htWeather.Add("����", "0236");
			htWeather.Add("�Ͼ�", "0099");

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



		#region ����Ϊ���Դ���

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
			// XmlDocument�ṩ����Ļ����ԣ������������Ҫ����DOM�������ݣ�����һ���õ�ѡ��������ΪXslTransform�������Դ���������ִ�� XSl�ĸ�ʽת����

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
			// XpathDocumentʹ��Xpath�ṩ��Xml����Դ�Ŀ��ٵ�ֻ�����ʡ��������ú���XmlDocument��ʹ��Xpath���ơ�
			//C# XPathDocument ʾ����
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
