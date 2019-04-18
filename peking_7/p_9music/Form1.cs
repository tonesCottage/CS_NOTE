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
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

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
			this.label1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(24, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
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
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}



		//�˳������ϴεĳ���Ļ������޸ģ�ʹ֮�ܴ���һ���ʶ�Ӧ���ʱ��  tds 2009-1-10
		// http://www.dstang.com

		const int MAX_LINE = 200;
		string title, author, album;
		double [] times = new double[MAX_LINE];//ʱ��
		string [] lyrics = new string[MAX_LINE]; //���
		int cnt; //�������

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

			axWindowsMediaPlayer1.URL = txtFileName.Text  ;//����
		}

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			double pos = this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition; //��ǰλ��
    
			for( int i=0; i<cnt - 1; i++ )
			{
				if( times[i] > pos )
				{  //�ҵ���Ӧ��ʱ�䣬����ʾ���
					if( i > 0 ) this.label1.Text = lyrics[i - 1] ;//ǰһ��
					this.label2.Text = lyrics[i] ;//��һ��
					return;
				}
			}
		}

		private void btnSelectFile_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.Filter = "����|*.wav;*.mp3|�����ļ�|*.*";
			openFileDialog1.ShowDialog();//ѡ�ļ�
			txtFileName.Text = openFileDialog1.FileName;
			if( txtFileName.Text.Length == 0 ) return;
    
			//ReadLRC( txtFileName.Text.Substring(0, txtFileName.Text.Length - 4) + ".lrc" );//������ļ�(ͬ���ļ�������׺��ͬ)
			ReadLRC_UseRegex( Regex.Replace( txtFileName.Text, @"^(.*)\.\w+$", "$1.lrc" ) ); 

			this.label1.Text = title;
			this.label2.Text = author + " -- ��" + album + "��";
			this.Text = "lrcPlayer--" + title + "--" + author;
    
			btnPlay_Click(null, null);//����  
		}


		private void ReadLRC(string fileName) //������ļ�
		{
			cnt = 0;
			for(int i=0; i<times.Length; i++ )
			{
				times[i] = -1  ;//��ʼ������
			}
    
			try
			{
				string one_line;
				this.Cursor = Cursors.WaitCursor;//���ָ��Ϊɳ©״
				
				// �������ļ�
				System.IO.StreamReader infile = new System.IO.StreamReader( fileName, System.Text.Encoding.Default );
    
				// ���ļ�
				while( true )
				{
					//DoEvents();

					one_line = infile.ReadLine(); //������
					if( one_line == null ) break;

					one_line = one_line.Trim();
					if( one_line=="" ) continue;
                
					if( one_line.Substring(0, 4) == "[ti:" )//����
					{
						title = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else if( one_line.Substring(0, 4) == "[ar:" )//����
					{
						author = one_line.Substring( 4, one_line.Length - 5)  ;
					}
					else if( one_line.Substring(0, 4) == "[al:" )//����
					{
						album = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else
					{
        
						//����һ���п����ж����������Ҫ�ø�ѭ��
						while( one_line.Substring(0,1) == "[" && one_line.Substring(3, 1) ==":" && one_line.Substring(6, 1) == "." && one_line.Substring(9, 1) == "]" )
						{
                
							string timestr = one_line.Substring(1, 8) ;//ʱ�䴮
							double tm = Convert.ToDouble(timestr.Substring(0,2)) * 60 + Convert.ToDouble(timestr.Substring(3)) ;//ʱ�䣨�룩
							string ly = one_line.Substring( one_line.LastIndexOf( "]") + 1) ;//���һ��ʱ�䴮������Ǹ��
                
							InsertOneItem( tm, ly   );//����ʱ�䣬�������뵽���ʵ�λ��
							one_line = one_line.Substring(10) ;//���������ǰһ��ʱ��ȥ�����Ա����һ��ʱ��
						}
					}
				}

				// �ر��ļ�
				infile.Close();
				this.Cursor = Cursors.Default;//���ָ��Ϊȱʡ��״
		
			}
			catch(Exception ex )
			{
				this.Cursor = Cursors.Default;
				//if( Err.Number == 53 ) MessageBox.Show( "����ļ�������");
				return;
			}
    
		}

		void InsertOneItem( double tm, string ly)
		{ //
			//��Ҫ����ʱ�䣬�ҵ����ʵ�λ��
			int pos=-1;
			for(int i=0; i<times.Length; i++ )
			{
				if( tm < times[i] || times[i] == -1 )
				{
					pos = i;
					break;
				}
			}
    
			//������������������һ��
			for(int i=times.Length - 1; i<pos; i--)
			{
				times[i + 1] = times[i];
				lyrics[i + 1] = lyrics[i];
			}
    
			//�����һ���ŵ�����
			times[pos] = tm;
			lyrics[pos] = ly;
			cnt = cnt + 1 ;//����
		}


		private void ReadLRC_UseRegex(string fileName) //������ļ�
		{
			cnt = 0;
			for(int i=0; i<times.Length; i++ )
			{
				times[i] = -1  ;//��ʼ������
			}
    
			try
			{
				string one_line;
				this.Cursor = Cursors.WaitCursor;//���ָ��Ϊɳ©״
				
				// �������ļ�
				System.IO.StreamReader infile = new System.IO.StreamReader( fileName, System.Text.Encoding.Default );
    
				// ���ļ�
				while( true )
				{
					//DoEvents();

					one_line = infile.ReadLine(); //������
					if( one_line == null ) break;

					one_line = one_line.Trim();
					if( one_line=="" ) continue;
                

					if( one_line.StartsWith("[ti:") )//����
					{
						title = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else if( one_line.StartsWith( "[ar:") )//����
					{
						author = one_line.Substring( 4, one_line.Length - 5)  ;
					}
					else if( one_line.StartsWith( "[al:") )//����
					{
						album = one_line.Substring( 4, one_line.Length - 5) ;
					}
					else
					{
        
						//����һ���п����ж��ʱ�䴮
						Regex regex = new Regex( @"\[\d{2}:\d{2}\.\d{2}\]" );//�÷������������ĸ�ʽ
						MatchCollection matches = regex.Matches( one_line );
						if( matches.Count > 0 )
						{
							Match lastmatch = matches[matches.Count-1];
							string ly = one_line.Substring( lastmatch.Index + lastmatch.Length );//���һ��ʱ�䴮������Ǹ��
							foreach( Match match in matches )
							{
								string timestr = match.Value.Substring(1, 8) ;//ʱ�䴮
								double tm = Convert.ToDouble(timestr.Substring(0,2)) * 60 + Convert.ToDouble(timestr.Substring(3)) ;//ʱ�䣨�룩               
								InsertOneItem( tm, ly   );//����ʱ�䣬�������뵽���ʵ�λ��
							}
						}
					}
				}

				// �ر��ļ�
				infile.Close();
				this.Cursor = Cursors.Default;//���ָ��Ϊȱʡ��״
		
			}
			catch(Exception ex )
			{
				this.Cursor = Cursors.Default;
				//if( Err.Number == 53 ) MessageBox.Show( "����ļ�������");
				return;
			}
    
		}


	}
}
