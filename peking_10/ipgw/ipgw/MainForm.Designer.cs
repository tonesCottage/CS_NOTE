//#define WEBPAGEMODE

namespace ipgw
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbPass = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnectAll = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMoneyLeft = new System.Windows.Forms.Label();
            this.lblTimeUsed = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSave = new System.Windows.Forms.CheckBox();
            this.rbFee = new System.Windows.Forms.RadioButton();
            this.rbFree = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTipWlan = new System.Windows.Forms.ToolTip(this.components);
            this.txtTimeFee = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.btnMin = new System.Windows.Forms.Button();
            this.timerCheckTimeFee = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPass
            // 
            this.tbPass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPass.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbPass.Location = new System.Drawing.Point(26, 62);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(106, 21);
            this.tbPass.TabIndex = 1;
            this.tbPass.Text = "密  码";
            this.tbPass.WordWrap = false;
            this.tbPass.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            this.tbPass.Enter += new System.EventHandler(this.tbPass_Enter);
            this.tbPass.Leave += new System.EventHandler(this.tbPass_Leave);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConnect.Enabled = false;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConnect.Location = new System.Drawing.Point(26, 136);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(70, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnectAll
            // 
            this.btnDisconnectAll.BackColor = System.Drawing.SystemColors.Control;
            this.btnDisconnectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDisconnectAll.Enabled = false;
            this.btnDisconnectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDisconnectAll.Location = new System.Drawing.Point(106, 165);
            this.btnDisconnectAll.Name = "btnDisconnectAll";
            this.btnDisconnectAll.Size = new System.Drawing.Size(70, 23);
            this.btnDisconnectAll.TabIndex = 9;
            this.btnDisconnectAll.Text = "断开所有";
            this.btnDisconnectAll.UseVisualStyleBackColor = false;
            this.btnDisconnectAll.Click += new System.EventHandler(this.btnDisconnectAll_Click);
            // 
            // btnMail
            // 
            this.btnMail.BackColor = System.Drawing.SystemColors.Control;
            this.btnMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMail.Location = new System.Drawing.Point(26, 165);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(70, 23);
            this.btnMail.TabIndex = 8;
            this.btnMail.Text = "邮件";
            this.btnMail.UseVisualStyleBackColor = false;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // cbName
            // 
            this.cbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbName.Location = new System.Drawing.Point(26, 33);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(150, 20);
            this.cbName.Sorted = true;
            this.cbName.TabIndex = 0;
            this.cbName.Text = "用户名";
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            this.cbName.Enter += new System.EventHandler(this.cbName_Enter);
            this.cbName.Leave += new System.EventHandler(this.cbName_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCurrentTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblMoneyLeft);
            this.panel1.Controls.Add(this.lblTimeUsed);
            this.panel1.Controls.Add(this.lblMode);
            this.panel1.Controls.Add(this.lblNum);
            this.panel1.Controls.Add(this.lblRange);
            this.panel1.Controls.Add(this.lblIP);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblUpdateTime);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(193, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 162);
            this.panel1.TabIndex = 32;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentTime.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCurrentTime.ImageKey = "(无)";
            this.lblCurrentTime.Location = new System.Drawing.Point(64, 3);
            this.lblCurrentTime.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblCurrentTime.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(120, 12);
            this.lblCurrentTime.TabIndex = 44;
            this.lblCurrentTime.Text = "  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageKey = "(无)";
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "当前时间：";
            // 
            // lblMoneyLeft
            // 
            this.lblMoneyLeft.AutoSize = true;
            this.lblMoneyLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblMoneyLeft.ForeColor = System.Drawing.Color.White;
            this.lblMoneyLeft.ImageKey = "(无)";
            this.lblMoneyLeft.Location = new System.Drawing.Point(64, 145);
            this.lblMoneyLeft.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblMoneyLeft.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblMoneyLeft.Name = "lblMoneyLeft";
            this.lblMoneyLeft.Size = new System.Drawing.Size(120, 12);
            this.lblMoneyLeft.TabIndex = 42;
            this.lblMoneyLeft.Text = "  ";
            // 
            // lblTimeUsed
            // 
            this.lblTimeUsed.AutoSize = true;
            this.lblTimeUsed.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeUsed.ForeColor = System.Drawing.Color.White;
            this.lblTimeUsed.ImageKey = "(无)";
            this.lblTimeUsed.Location = new System.Drawing.Point(64, 130);
            this.lblTimeUsed.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblTimeUsed.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblTimeUsed.Name = "lblTimeUsed";
            this.lblTimeUsed.Size = new System.Drawing.Size(120, 12);
            this.lblTimeUsed.TabIndex = 41;
            this.lblTimeUsed.Text = "  ";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.Color.Transparent;
            this.lblMode.ForeColor = System.Drawing.Color.White;
            this.lblMode.ImageKey = "(无)";
            this.lblMode.Location = new System.Drawing.Point(64, 115);
            this.lblMode.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblMode.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(120, 12);
            this.lblMode.TabIndex = 40;
            this.lblMode.Text = "  ";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.BackColor = System.Drawing.Color.Transparent;
            this.lblNum.ForeColor = System.Drawing.Color.White;
            this.lblNum.ImageKey = "(无)";
            this.lblNum.Location = new System.Drawing.Point(64, 100);
            this.lblNum.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblNum.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(120, 12);
            this.lblNum.TabIndex = 39;
            this.lblNum.Text = "  ";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.BackColor = System.Drawing.Color.Transparent;
            this.lblRange.ForeColor = System.Drawing.Color.White;
            this.lblRange.ImageKey = "(无)";
            this.lblRange.Location = new System.Drawing.Point(64, 85);
            this.lblRange.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblRange.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(120, 12);
            this.lblRange.TabIndex = 38;
            this.lblRange.Text = "  ";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.ForeColor = System.Drawing.Color.White;
            this.lblIP.ImageKey = "(无)";
            this.lblIP.Location = new System.Drawing.Point(64, 70);
            this.lblIP.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblIP.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(120, 12);
            this.lblIP.TabIndex = 37;
            this.lblIP.Text = "  ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.ImageKey = "(无)";
            this.lblName.Location = new System.Drawing.Point(64, 55);
            this.lblName.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblName.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 12);
            this.lblName.TabIndex = 36;
            this.lblName.Text = "  ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.ImageKey = "(无)";
            this.lblStatus.Location = new System.Drawing.Point(64, 40);
            this.lblStatus.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblStatus.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 12);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "  ";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateTime.ForeColor = System.Drawing.Color.White;
            this.lblUpdateTime.ImageKey = "(无)";
            this.lblUpdateTime.Location = new System.Drawing.Point(64, 25);
            this.lblUpdateTime.MaximumSize = new System.Drawing.Size(120, 12);
            this.lblUpdateTime.MinimumSize = new System.Drawing.Size(120, 12);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(120, 12);
            this.lblUpdateTime.TabIndex = 34;
            this.lblUpdateTime.Text = "  ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.ImageKey = "(无)";
            this.label11.Location = new System.Drawing.Point(3, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "账户余额：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.ImageKey = "(无)";
            this.label10.Location = new System.Drawing.Point(3, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "已用时长：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageKey = "(无)";
            this.label9.Location = new System.Drawing.Point(3, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "包月类型：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImageKey = "(无)";
            this.label8.Location = new System.Drawing.Point(3, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "连接数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageKey = "(无)";
            this.label7.Location = new System.Drawing.Point(3, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "访问范围：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageKey = "(无)";
            this.label6.Location = new System.Drawing.Point(3, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "当前IP：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImageKey = "(无)";
            this.label5.Location = new System.Drawing.Point(3, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageKey = "(无)";
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "连接状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageKey = "(无)";
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "状态更新：";
            // 
            // cbSave
            // 
            this.cbSave.AutoSize = true;
            this.cbSave.BackColor = System.Drawing.Color.Transparent;
            this.cbSave.Checked = true;
            this.cbSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSave.Font = new System.Drawing.Font("宋体", 8.75F);
            this.cbSave.ForeColor = System.Drawing.Color.White;
            this.cbSave.ImageKey = "(无)";
            this.cbSave.Location = new System.Drawing.Point(137, 92);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(48, 16);
            this.cbSave.TabIndex = 5;
            this.cbSave.Text = "记住";
            this.cbSave.UseVisualStyleBackColor = false;
            // 
            // rbFee
            // 
            this.rbFee.AutoSize = true;
            this.rbFee.BackColor = System.Drawing.Color.Transparent;
            this.rbFee.Font = new System.Drawing.Font("宋体", 8.75F);
            this.rbFee.ForeColor = System.Drawing.Color.White;
            this.rbFee.ImageKey = "(无)";
            this.rbFee.Location = new System.Drawing.Point(77, 92);
            this.rbFee.Name = "rbFee";
            this.rbFee.Size = new System.Drawing.Size(47, 16);
            this.rbFee.TabIndex = 3;
            this.rbFee.TabStop = true;
            this.rbFee.Text = "收费";
            this.rbFee.UseVisualStyleBackColor = false;
            // 
            // rbFree
            // 
            this.rbFree.AutoSize = true;
            this.rbFree.BackColor = System.Drawing.Color.Transparent;
            this.rbFree.Checked = true;
            this.rbFree.Font = new System.Drawing.Font("宋体", 8.75F);
            this.rbFree.ForeColor = System.Drawing.Color.White;
            this.rbFree.ImageKey = "(无)";
            this.rbFree.Location = new System.Drawing.Point(25, 91);
            this.rbFree.Name = "rbFree";
            this.rbFree.Size = new System.Drawing.Size(47, 16);
            this.rbFree.TabIndex = 2;
            this.rbFree.TabStop = true;
            this.rbFree.Text = "免费";
            this.rbFree.UseVisualStyleBackColor = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolTipWlan
            // 
            this.toolTipWlan.AutomaticDelay = 100;
            this.toolTipWlan.AutoPopDelay = 3000;
            this.toolTipWlan.InitialDelay = 100;
            this.toolTipWlan.ReshowDelay = 20;
            // 
            // txtTimeFee
            // 
            this.txtTimeFee.Location = new System.Drawing.Point(137, 62);
            this.txtTimeFee.Name = "txtTimeFee";
            this.txtTimeFee.Size = new System.Drawing.Size(41, 21);
            this.txtTimeFee.TabIndex = 53;
            this.txtTimeFee.Text = "15";
            this.txtTimeFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipWlan.SetToolTip(this.txtTimeFee, "几分钟后收费切换到免费");
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnDisconnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDisconnect.Location = new System.Drawing.Point(106, 136);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(70, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "IPGW - Ning";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::ipgw.Properties.Resources.btnExitDark;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(339, -1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 20);
            this.btnExit.TabIndex = 34;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseMove);
            // 
            // picWait
            // 
            this.picWait.BackColor = System.Drawing.Color.Transparent;
            this.picWait.BackgroundImage = global::ipgw.Properties.Resources.waiting;
            this.picWait.Cursor = System.Windows.Forms.Cursors.Default;
            this.picWait.Location = new System.Drawing.Point(173, 85);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(32, 32);
            this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWait.TabIndex = 31;
            this.picWait.TabStop = false;
            this.picWait.Visible = false;
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::ipgw.Properties.Resources.btnMinDark;
            this.btnMin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.Transparent;
            this.btnMin.Location = new System.Drawing.Point(312, -2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(26, 20);
            this.btnMin.TabIndex = 52;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            this.btnMin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMin_MouseMove);
            // 
            // timerCheckTimeFee
            // 
            this.timerCheckTimeFee.Enabled = true;
            this.timerCheckTimeFee.Interval = 60000;
            this.timerCheckTimeFee.Tick += new System.EventHandler(this.timerCheckTimeFee_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(393, 211);
            this.Controls.Add(this.txtTimeFee);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.picWait);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.btnDisconnectAll);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.rbFee);
            this.Controls.Add(this.rbFree);
            this.Controls.Add(this.tbPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ipgw - Ning";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.RadioButton rbFree;
        private System.Windows.Forms.RadioButton rbFee;
        private System.Windows.Forms.CheckBox cbSave;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnectAll;
        private System.Windows.Forms.Button btnMail;
#if DEBUG
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
#endif
        private System.Windows.Forms.PictureBox picWait;
        private System.Windows.Forms.ComboBox cbName;
#if WEBPAGEMODE
        private System.Windows.Forms.CheckBox cbWlan;
#endif
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMoneyLeft;
        private System.Windows.Forms.Label lblTimeUsed;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolTip toolTipWlan;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Timer timerCheckTimeFee;
        private System.Windows.Forms.TextBox txtTimeFee;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

