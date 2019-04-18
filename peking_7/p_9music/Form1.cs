using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Text.RegularExpressions;
using System.Text;
using System.IO;

namespace lrcPlayer
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.btnPlay = new System.Windows.Forms.Button();
			this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timer1 = new System.Timers.Timer();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(24, 24);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(176, 21);
			this.txtFileName.TabIndex = 0;
			this.txtFileName.Text = "";
			// 
			// btnSelectFile
			// 
			this.btnSelectFile.Location = new System.Drawing.Point(208, 24);
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.Size = new System.Drawing.Size(32, 23);
			this.btnSelectFile.TabIndex = 1;
			this.btnSelectFile.Text = "...";
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// btnPlay
			// 
			this.btnPlay.Location = new System.Drawing.Point(248, 24);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(32, 23);
			this.btnPlay.TabIndex = 2;
			this.btnPlay.Text = "!";
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// axWindowsMediaPlayer1
			// 
			this.axWindowsMediaPlayer1.Enabled = true;
			this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(24, 64);
			this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
			this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
			this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(256, 32);
			this.axWindowsMediaPlayer1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(24, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(24, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(256, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "label2";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.SynchronizingObject = this;
			this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(296, 197);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.axWindowsMediaPlayer1);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.btnSelectFile);
			this.Controls.Add(this.txtFileName);
			this.Name = "Form1";
			this.Text = "lrcPlayer";
			((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
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



		//此程序在上次的程序的基础上修改，使之能处理一句歌词对应多个时间  tds 2009-1-10
		// http://www.dstang.com

		const int MAX_LINE = 200;
		string title, author, album;
		double [] times = new double[MAX_LINE];//时间
		string [] lyrics = new string[MAX_LINE]; //歌词
		int cnt; //歌词行数

		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Button btnSelectFile;
		private System.Windows.Forms.Button btnPlay;
		private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Timers.Timer timer1;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;


		private void btnPlay_Click(object sender, System.EventArgs e)
		{
			if( txtFileName.Text == "" ) return;

			timer1.Interval = 1000;
			timer1.Enabled = true;

			axWindowsMediaPlayer1.URL = txtFileName.Text  ;//播放
		}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			double pos = this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition; //当前位置
    
			for( int i=0; i<cnt - 1; i++ )
			{
				if( times[i] > pos )
				{  //找到对应的时间，并显示歌词
					if( i > 0 ) this.label1.Text = lyrics[i - 1] ;//前一句
					this.label2.Text = lyrics[i] ;//下一句
					return;
				}
			}
		}

		private void btnSelectFile_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.Filter = "音乐|*.wav;*.mp3|所有文件|*.*";
			openFileDialog1.ShowDialog();//选文件
			txtFileName.Text = openFileDialog1.FileName;
			if( txtFileName.Text.Length == 0 ) return;
    
			//ReadLRC( txtFileName.Text.Substring(0, txtFileName.Text.Length - 4) + ".lrc" );//读歌词文件(同名文件，但后缀不同)
			ReadLRC_UseRegex( Regex.Replace( txtFileName.Text, @"^(.*)\.\w+$", "$1.lrc" ) ); 

			this.label1.Text = title;
			this.label2.Text = author + " -- 《" + album + "》";
			this.Text = "lrcPlayer--" + title + "--" + author;
    
			btnPlay_Click(null, null);//播放  
		}


		private void ReadLRC(string fileName) //读歌词文件
		{
			cnt = 0;
			for(int i=0; i<times.Length; i++ )
			{
				times[i] = -1  ;//初始化数据
			}
    
			try
			{
				string one_line;
				this.Cursor = Cursors.WaitCursor;//鼠标指针为沙漏状
				
				// 打开输入文件
				System.IO.StreamReader infile = new System.IO.StreamReader( fileName, System.Text.Encoding.Default );
    
				// 读文件
				while( true )
				{
					//DoEvents();

					one_line = infile.ReadLine(); //读入行
					if( one_line == null ) break;

					one_line = one_line.Trim();
					if( one_line=="" ) continue;
                
					if( one_line.Substring(0, 4) == "[ti:" )//标题
					{
						title = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else if( one_line.Substring(0, 4) == "[ar:" )//作者
					{
						author = one_line.Substring( 4, one_line.Length - 5)  ;
					}
					else if( one_line.Substring(0, 4) == "[al:" )//集子
					{
						album = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else
					{
        
						//由于一行中可能有多个串，所以要用个循环
						while( one_line.Substring(0,1) == "[" && one_line.Substring(3, 1) ==":" && one_line.Substring(6, 1) == "." && one_line.Substring(9, 1) == "]" )
						{
                
							string timestr = one_line.Substring(1, 8) ;//时间串
							double tm = Convert.ToDouble(timestr.Substring(0,2)) * 60 + Convert.ToDouble(timestr.Substring(3)) ;//时间（秒）
							string ly = one_line.Substring( one_line.LastIndexOf( "]") + 1) ;//最后一个时间串后跟的是歌词
                
							InsertOneItem( tm, ly   );//根据时间，将它插入到合适的位置
							one_line = one_line.Substring(10) ;//将这个串的前一个时间去掉，以便得下一个时间
						}
					}
				}

				// 关闭文件
				infile.Close();
				this.Cursor = Cursors.Default;//鼠标指针为缺省形状
		
			}
			catch(Exception ex )
			{
				this.Cursor = Cursors.Default;
				//if( Err.Number == 53 ) MessageBox.Show( "歌词文件不存在");
				return;
			}
    
		}

		void InsertOneItem( double tm, string ly)
		{ //
			//先要根据时间，找到合适的位置
			int pos=-1;
			for(int i=0; i<times.Length; i++ )
			{
				if( tm < times[i] || times[i] == -1 )
				{
					pos = i;
					break;
				}
			}
    
			//将它后面的内容向后移一格
			for(int i=times.Length - 1; i<pos; i--)
			{
				times[i + 1] = times[i];
				lyrics[i + 1] = lyrics[i];
			}
    
			//最后将这一条放到这里
			times[pos] = tm;
			lyrics[pos] = ly;
			cnt = cnt + 1 ;//计数
		}


		private void ReadLRC_UseRegex(string fileName) //读歌词文件
		{
			cnt = 0;
			for(int i=0; i<times.Length; i++ )
			{
				times[i] = -1  ;//初始化数据
			}
    
			try
			{
				string one_line;
				this.Cursor = Cursors.WaitCursor;//鼠标指针为沙漏状
				
				// 打开输入文件
				System.IO.StreamReader infile = new System.IO.StreamReader( fileName, System.Text.Encoding.Default );
    
				// 读文件
				while( true )
				{
					//DoEvents();

					one_line = infile.ReadLine(); //读入行
					if( one_line == null ) break;

					one_line = one_line.Trim();
					if( one_line=="" ) continue;
                

					if( one_line.StartsWith("[ti:") )//标题
					{
						title = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else if( one_line.StartsWith( "[ar:") )//作者
					{
						author = one_line.Substring( 4, one_line.Length - 5)  ;
					}
					else if( one_line.StartsWith( "[al:") )//集子
					{
						album = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else
					{
        
						//由于一行中可能有多个时间串
						Regex regex = new Regex( @"\[\d{2}:\d{2}\.\d{2}\]" );//用方括号括起来的格式
						MatchCollection matches = regex.Matches( one_line );
						if( matches.Count > 0 )
						{
							Match lastmatch = matches[matches.Count-1];
							string ly = one_line.Substring( lastmatch.Index + lastmatch.Length );//最后一个时间串后跟的是歌词
							foreach( Match match in matches )
							{
								string timestr = match.Value.Substring(1, 8) ;//时间串
								double tm = Convert.ToDouble(timestr.Substring(0,2)) * 60 + Convert.ToDouble(timestr.Substring(3)) ;//时间（秒）               
								InsertOneItem( tm, ly   );//根据时间，将它插入到合适的位置
							}
						}
					}
				}

				// 关闭文件
				infile.Close();
				this.Cursor = Cursors.Default;//鼠标指针为缺省形状
		
			}
			catch(Exception ex )
			{
				this.Cursor = Cursors.Default;
				//if( Err.Number == 53 ) MessageBox.Show( "歌词文件不存在");
				return;
			}
    
		}


	}
}
