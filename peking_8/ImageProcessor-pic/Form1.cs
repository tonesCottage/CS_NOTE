using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageProcessor
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItemOpen = new System.Windows.Forms.MenuItem();
			this.menuItemSave = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItemInvert = new System.Windows.Forms.MenuItem();
			this.menuItemGray = new System.Windows.Forms.MenuItem();
			this.menuItemBright = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemOpen,
																					  this.menuItemSave,
																					  this.menuItemExit});
			this.menuItem1.Text = "�ļ�";
			// 
			// menuItemOpen
			// 
			this.menuItemOpen.Index = 0;
			this.menuItemOpen.Text = "��";
			this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
			// 
			// menuItemSave
			// 
			this.menuItemSave.Index = 1;
			this.menuItemSave.Text = "����";
			this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 2;
			this.menuItemExit.Text = "�˳�";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemInvert,
																					  this.menuItemGray,
																					  this.menuItemBright});
			this.menuItem2.Text = "����";
			// 
			// menuItemInvert
			// 
			this.menuItemInvert.Index = 0;
			this.menuItemInvert.Text = "��ת";
			this.menuItemInvert.Click += new System.EventHandler(this.menuItemInvert_Click);
			// 
			// menuItemGray
			// 
			this.menuItemGray.Index = 1;
			this.menuItemGray.Text = "���";
			this.menuItemGray.Click += new System.EventHandler(this.menuItemGray_Click);
			// 
			// menuItemBright
			// 
			this.menuItemBright.Index = 2;
			this.menuItemBright.Text = "����";
			this.menuItemBright.Click += new System.EventHandler(this.menuItemBright_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(600, 450);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

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

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItemSave;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemInvert;
		private System.Windows.Forms.MenuItem menuItemGray;
		private System.Windows.Forms.MenuItem menuItemBright;

		Bitmap m_Bitmap = new Bitmap(1,1);

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if( m_Bitmap == null) return;

			Graphics g = e.Graphics;
			g.DrawImage(m_Bitmap, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y,
				(int)(m_Bitmap.Width), (int)(m_Bitmap.Height)));

		}

		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = @"Bitmap�ļ�(*.bmp)|*.bmp|Jpeg�ļ�(*.jpg)|*.jpg|���к����ļ�(*.bmp;*.jpg)|*.bmp;*.jpg";
			openFileDialog.FilterIndex = 2 ;
			openFileDialog.RestoreDirectory = true ;
			if(DialogResult.OK == openFileDialog.ShowDialog())
			{
				m_Bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
				this.AutoScroll = true;
				this.AutoScrollMinSize = new Size (m_Bitmap.Width,m_Bitmap.Height);
				this.Invalidate();
			}

		}

		private void menuItemSave_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Bitmap�ļ�(*.bmp)|*.bmp|Jpeg�ļ�(*.jpg)|*.jpg|���к����ļ�(*.bmp;*.jpg)|*.bmp;*.jpg";
			saveFileDialog.FilterIndex = 1 ;
			saveFileDialog.RestoreDirectory = true ;
			if(DialogResult.OK == saveFileDialog.ShowDialog())
			{
				m_Bitmap.Save(saveFileDialog.FileName);
			}

		}

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemInvert_Click(object sender, System.EventArgs e)
		{
			if(Filters.Invert(m_Bitmap))
				this.Invalidate();
		}
		private void menuItemGray_Click(object sender, System.EventArgs e)
		{
			if(Filters.Gray(m_Bitmap))
				this.Invalidate();
		}
		private void menuItemBright_Click(object sender, System.EventArgs e)
		{
			ParameterInputForm dlg = new ParameterInputForm();
			dlg.Value = 0;
			if (DialogResult.OK == dlg.ShowDialog())
			{
				if(Filters.Brightness(m_Bitmap, dlg.Value))
					this.Invalidate();
			}
		} 


	}
}
