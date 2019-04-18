using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Web;

namespace BaiduSuggestion
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox listBox1;
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(96, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(40, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(200, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// listBox1
			// 
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(40, 64);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(200, 98);
			this.listBox1.TabIndex = 2;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

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


		public static Random rand = new Random();

		public static string GetBaiduSuggestion( string wd )
		{
			string url = "http://suggestion.baidu.com/su?wd=" + myUrlEncode( wd );
			url += "&rnd=" + rand.Next();
 
			string suggestion = DownloadString( url );

			//"window.baidu.sug({q:'人们',p:false,s:['人们简称它为','人们网','人们教育出版社','人们通常选择对显卡的哪个部分进行超频','人们最先用什么动物进行宇宙飞行实验的','人们把那些买进股票 期待涨价后售出的行为称作','人们称哪届奥运会是跑表 皮尺时代的结束.','人们在收拾鱼身时涂下列哪种东西可防滑','人们日报','人们的梦']});"


			string sug = System.Text.RegularExpressions.Regex.Replace( suggestion, @".*,s:\[([^\]]*)\].*", "$1" );


			return sug;

		}

		public static string DownloadString( string url )
		{
			System.Net.WebClient webclient = new System.Net.WebClient();
			webclient.Credentials = new System.Net.CredentialCache();
			//webclient.Headers["Cookie"]= "BAIDUID=956846E39BCCC16731356AEE5C12DF17:FG=1; BD_UTK_DVT=1; BDSTAT=6f9b617e0eaf10780a55b319ebc4b74543a98226f8fc1e178a82b9014b90d77b; MAPCITY=010,";
			webclient.Headers["Cookie"]= "BDUSS=FkcmZZckFNN1h3V0JxdDN4aWFVWmI0bDVwakpzYn5BZn5ZQ25KQkxOVGtvQlpOQVFBQUFBJCQAAAAAAAAAAApRLgtnzNkJZHN0YW5nMjAwMAAAAAAAAAAAAAAAAAAAAAAAAAAAAADAymRxAAAAAMDKZHEAAAAAuFNCAAAAAAAxMC4yMy4yNOQT70zkE";

			byte [] data = webclient.DownloadData( url );
			return System.Text.Encoding.Default.GetString( data );
		}

		public static string encodeURIComponent(string wd)
		{
			return System.Web.HttpUtility.UrlEncode( wd, System.Text.Encoding.UTF8 ).ToUpper();
		}
		public static string myUrlEncode(string wd )
		{
			byte [] bytes = System.Text.Encoding.UTF8.GetBytes( wd );
			string res = "";
			for( int i=0; i<bytes.Length; i++ )
			{
				res += "%" + bytes[i].ToString("X2");
			}
			return res;
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			string text = this.textBox1.Text;
			string [] words = text.Split( "', \"".ToCharArray() ); 
			string word = words[ words.Length-1 ];//最后一个单词
			//也可以这样:
			//word = System.Text.RegularExpressions.Regex.Replace( text, @"(^|.*\W)(\w+)$",  "$2"); 
			string sug = GetBaiduSuggestion( word ); //得到Suggestion
			if( sug==null || sug == "" ) return;

			this.listBox1.Items.Clear();
			string [] ary = sug.Split(',');
			for( int i=0; i<ary.Length; i++ ) //填充列表
			{
				this.listBox1.Items.Add( ary[i].Replace("'","" ).Replace("\"","") );				
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( this.listBox1.SelectedIndex < 0 ) return;

			string text = this.textBox1.Text;
			string [] words = text.Split( "', \"".ToCharArray() );
			string word = words[ words.Length-1 ];
			int idx = text.LastIndexOf( word );

			string sug = this.listBox1.SelectedItem.ToString();

			this.textBox1.Text = text.Substring(0, idx) + sug;

			this.textBox1.Focus();
			this.textBox1.SelectionStart = this.textBox1.Text.Length;	
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string wd = "人们";
			this.Text = GetBaiduSuggestion(wd );

		}

	}
//	public class CookieAwareWebClient : WebClient    
//	{        
//		private CookieContainer m_container = new CookieContainer();        
//		protected override WebRequest GetWebRequest(Uri address)        
//		{            
//			WebRequest request = base.GetWebRequest(address);           
//			if (request is HttpWebRequest)            
//			{
//				(request as HttpWebRequest).CookieContainer = m_container;            
//			}            return request;        
//		}    
//	}
}
