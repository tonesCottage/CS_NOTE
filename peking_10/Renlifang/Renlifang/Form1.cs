using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Xml;
using System.Net;

namespace Renlifang
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.Panel pnlDraw;
		private System.Windows.Forms.ComboBox cmbPerson;
		private System.Windows.Forms.Button btnZoomIn;
		private System.Windows.Forms.Button btnZoomOut;
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
			this.pnlDraw = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnZoomOut = new System.Windows.Forms.Button();
			this.btnZoomIn = new System.Windows.Forms.Button();
			this.cmbPerson = new System.Windows.Forms.ComboBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlDraw
			// 
			this.pnlDraw.BackColor = System.Drawing.Color.White;
			this.pnlDraw.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDraw.Location = new System.Drawing.Point(0, 0);
			this.pnlDraw.Name = "pnlDraw";
			this.pnlDraw.Size = new System.Drawing.Size(640, 421);
			this.pnlDraw.TabIndex = 0;
			this.pnlDraw.Click += new System.EventHandler(this.pnlDraw_Click);
			this.pnlDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseUp);
			this.pnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraw_Paint);
			this.pnlDraw.DoubleClick += new System.EventHandler(this.pnlDraw_DoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnZoomOut);
			this.panel2.Controls.Add(this.btnZoomIn);
			this.panel2.Controls.Add(this.cmbPerson);
			this.panel2.Controls.Add(this.btnQuery);
			this.panel2.Controls.Add(this.txtName);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(640, 72);
			this.panel2.TabIndex = 1;
			// 
			// btnZoomOut
			// 
			this.btnZoomOut.Location = new System.Drawing.Point(520, 24);
			this.btnZoomOut.Name = "btnZoomOut";
			this.btnZoomOut.Size = new System.Drawing.Size(16, 16);
			this.btnZoomOut.TabIndex = 4;
			this.btnZoomOut.Text = "-";
			this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
			// 
			// btnZoomIn
			// 
			this.btnZoomIn.Location = new System.Drawing.Point(496, 24);
			this.btnZoomIn.Name = "btnZoomIn";
			this.btnZoomIn.Size = new System.Drawing.Size(16, 16);
			this.btnZoomIn.TabIndex = 3;
			this.btnZoomIn.Text = "+";
			this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
			// 
			// cmbPerson
			// 
			this.cmbPerson.Location = new System.Drawing.Point(336, 24);
			this.cmbPerson.Name = "cmbPerson";
			this.cmbPerson.Size = new System.Drawing.Size(112, 20);
			this.cmbPerson.TabIndex = 2;
			this.cmbPerson.Text = "(相关人)";
			this.cmbPerson.SelectedIndexChanged += new System.EventHandler(this.cmbPerson_SelectedIndexChanged);
			// 
			// btnQuery
			// 
			this.btnQuery.Location = new System.Drawing.Point(160, 24);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(120, 24);
			this.btnQuery.TabIndex = 1;
			this.btnQuery.Text = "显示关系图";
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(32, 24);
			this.txtName.Name = "txtName";
			this.txtName.TabIndex = 0;
			this.txtName.Text = "唐大仕";
			this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(640, 421);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pnlDraw);
			this.Name = "Form1";
			this.Text = "人立方";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel2.ResumeLayout(false);
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

		//几个变量
		private XmlDocument xmldoc = null;

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string name = txtName.Text.Trim();
			this.Cursor = Cursors.WaitCursor;
			QueryRelationFromWeb( name );
			this.Cursor = Cursors.Default;
			this.pnlDraw.Invalidate();
		}

		private void QueryRelationFromWeb( string name )
		{
			//string url = "http://renlifang.msra.cn/visualsearch.aspx?query="; //老的地址不能用了
			string url = "http://renlifang.msra.cn/handles/result.ashx?func=view.map&query=";

			url += System.Web.HttpUtility.UrlEncode( name, System.Text.Encoding.UTF8 );

			byte[] data = new WebClient().DownloadData( url ); //从网上得到相关信息
			string strXml = System.Text.Encoding.UTF8.GetString( data );
			if( strXml == "" ) return;

			try
			{
				if( (int)strXml[0]== 65279 ) strXml = strXml.Substring(1); //前导字符要去掉

				if( strXml.StartsWith( "<?" ) )
				{
					strXml = strXml.Substring( strXml.IndexOf("?>") +2 ); //去掉<?xml ?>指令
				}

				xmldoc = new XmlDocument();  //载入到Xml文档中
				xmldoc.LoadXml( strXml );
			}
			catch(Exception ex )
			{
				MessageBox.Show( ex.Message );
			}

		}

		private void DrawRelation()
		{
			if( xmldoc == null ) return;
			XmlNodeList nodes = xmldoc.SelectNodes( "/libraResponse/nodes/node");
			XmlNodeList edges = xmldoc.SelectNodes( "/libraResponse/edges/edge");


			//this.pnlDraw.Invalidate();

			//画连线
			for( int i=0; i<edges.Count; i++ )
			{
				XmlNode edge = edges[i];
				string desc = edge.SelectSingleNode("desc").InnerText;
				int width = int.Parse( edge.SelectSingleNode("width").InnerText );
				double x1 = double.Parse( edge.SelectSingleNode("x1").InnerText );
				double y1 = double.Parse( edge.SelectSingleNode("y1").InnerText );
				double x2 = double.Parse( edge.SelectSingleNode("x2").InnerText );
				double y2 = double.Parse( edge.SelectSingleNode("y2").InnerText );

				DrawEdge( desc, width, x1, y1, x2, y2 );
			}

			//画节点，并将节点的信息放到下拉框中
			this.cmbPerson.Items.Clear();
			for( int i=0; i<nodes.Count; i++ )
			{
				XmlNode node = nodes[i];
				string title = node.SelectSingleNode("title").InnerText;
				double scale = double.Parse( node.SelectSingleNode("scale").InnerText );
				double x = double.Parse( node.SelectSingleNode("x").InnerText );
				double y = double.Parse( node.SelectSingleNode("y").InnerText );

				DrawNode( title, scale, x, y, (title==this.txtName.Text ? Brushes.Red : Brushes.Blue) );

				this.cmbPerson.Items.Add( title );
			}


		}


		private double kDraw = 1.0;

		private void DrawNode( string title, double scale, double x, double y, Brush brush )
		{
			int x0 = this.pnlDraw.Width / 2;
			int y0 = this.pnlDraw.Height / 2;

			double r0 = 20; //画的圆的大小
			int r = (int)( r0 * scale * kDraw );

			Graphics graph = Graphics.FromHwnd( this.pnlDraw.Handle );
			graph.FillEllipse( brush,  
				(int)( x * kDraw + x0 - r ), (int)( y * kDraw + y0 -r ), r*2, r*2 );

			if( title != null && title != "" )
			{
				SizeF size = graph.MeasureString( title, this.Font );
				graph.DrawString( title, this.Font, Brushes.White, 
					(float) ( x * kDraw + x0 - size.Width/2 ), (float)( y * kDraw + y0 - size.Height/2+2 ) );
			}

		}

		private void DrawEdge( string desc, int width, double x1, double y1, double x2, double y2 )
		{
			int x0 = this.pnlDraw.Width / 2;
			int y0 = this.pnlDraw.Height / 2;
			Graphics graph = Graphics.FromHwnd( this.pnlDraw.Handle );
			graph.DrawLine( new Pen( Color.Red, width ),
				(int)( x1 * kDraw + x0 ), (int)( y1 * kDraw + y0 ),
				(int)( x2 * kDraw + x0 ), (int)( y2 * kDraw + y0 ) );

			if( desc != null && desc != "" )
			{
				graph.DrawString( desc, this.Font, Brushes.Black, 
					(float) ( (x1+x2)/2 * kDraw + x0 ), (float)( (y1+y2)/2 * kDraw + y0 ) );
			}

		}


		private void pnlDraw_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			DrawRelation();
		}


		private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if( e.KeyChar == '\r' )
			{
				this.btnQuery_Click(null, null);
			}
		}
		private void cmbPerson_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtName.Text = this.cmbPerson.SelectedItem.ToString();
			this.btnQuery_Click(null, null);

		}

		private void btnZoomOut_Click(object sender, System.EventArgs e)
		{
			ChangeZoomK( -0.1 );
		}

		private void btnZoomIn_Click(object sender, System.EventArgs e)
		{
			ChangeZoomK( 0.1 );
		}

		private void ChangeZoomK( double delt )
		{
			kDraw *= (1+delt);
			this.pnlDraw.Invalidate();
		}

		private void pnlDraw_Click(object sender, System.EventArgs e)
		{
			
		
		}

		private void pnlDraw_DoubleClick(object sender, System.EventArgs e)
		{
		
		}

		private int FindWhoIsClicked( int clickX, int clickY)
		{
			if( xmldoc == null ) return -1;
			XmlNodeList nodes = xmldoc.SelectNodes( "/libraResponse/nodes/node");
			XmlNodeList edges = xmldoc.SelectNodes( "/libraResponse/edges/edge");

			for( int i=0; i<nodes.Count; i++ )
			{
				XmlNode node = nodes[i];
				string title = node.SelectSingleNode("title").InnerText;
				double scale = double.Parse( node.SelectSingleNode("scale").InnerText );
				double x = double.Parse( node.SelectSingleNode("x").InnerText );
				double y = double.Parse( node.SelectSingleNode("y").InnerText );

				//DrawNode( title, scale, x, y );
				int x0 = this.pnlDraw.Width / 2;
				int y0 = this.pnlDraw.Height / 2;

				double r0 = 20; //画的圆的大小
				int r = (int)( r0 * scale * kDraw );

				double xOffset = clickX-this.pnlDraw.Left-(x0+x * kDraw);
				double yOffset = clickY-this.pnlDraw.Top-(y0+y * kDraw);

				if( xOffset*xOffset + yOffset*yOffset < r*r )
				{
					DrawNode( title, scale, x, y, Brushes.LightBlue );
					return i;
				}
			}
			return -1;

		}

		private void pnlDraw_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int n = FindWhoIsClicked( e.X, e.Y);
			if(n>=0)
			{
				cmbPerson.SelectedIndex = n;
			}
		
		}



	}
}
