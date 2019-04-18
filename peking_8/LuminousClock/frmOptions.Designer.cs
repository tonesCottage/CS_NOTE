namespace LuminousClock
{
    partial class frmOptions
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkBoxEscKeyDown = new System.Windows.Forms.CheckBox();
            this.checkBoxAnyKeyDown = new System.Windows.Forms.CheckBox();
            this.checkBoxMouseClick = new System.Windows.Forms.CheckBox();
            this.checkBoxMouseMove = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.checkBoxEscKeyDown);
            this.groupBox.Controls.Add(this.checkBoxAnyKeyDown);
            this.groupBox.Controls.Add(this.checkBoxMouseClick);
            this.groupBox.Controls.Add(this.checkBoxMouseMove);
            this.groupBox.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(41, 33);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(215, 210);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "程序退出条件";
            // 
            // checkBoxEscKeyDown
            // 
            this.checkBoxEscKeyDown.AutoSize = true;
            this.checkBoxEscKeyDown.Location = new System.Drawing.Point(37, 157);
            this.checkBoxEscKeyDown.Name = "checkBoxEscKeyDown";
            this.checkBoxEscKeyDown.Size = new System.Drawing.Size(104, 18);
            this.checkBoxEscKeyDown.TabIndex = 3;
            this.checkBoxEscKeyDown.Text = "ESC键被按下";
            this.checkBoxEscKeyDown.UseVisualStyleBackColor = true;
            this.checkBoxEscKeyDown.CheckedChanged += new System.EventHandler(this.checkBoxEscKeyDown_CheckedChanged);
            // 
            // checkBoxAnyKeyDown
            // 
            this.checkBoxAnyKeyDown.AutoSize = true;
            this.checkBoxAnyKeyDown.Location = new System.Drawing.Point(37, 118);
            this.checkBoxAnyKeyDown.Name = "checkBoxAnyKeyDown";
            this.checkBoxAnyKeyDown.Size = new System.Drawing.Size(125, 18);
            this.checkBoxAnyKeyDown.TabIndex = 2;
            this.checkBoxAnyKeyDown.Text = "任何按键被按下";
            this.checkBoxAnyKeyDown.UseVisualStyleBackColor = true;
            this.checkBoxAnyKeyDown.CheckedChanged += new System.EventHandler(this.checkBoxAnyKeyDown_CheckedChanged);
            // 
            // checkBoxMouseClick
            // 
            this.checkBoxMouseClick.AutoSize = true;
            this.checkBoxMouseClick.Location = new System.Drawing.Point(37, 79);
            this.checkBoxMouseClick.Name = "checkBoxMouseClick";
            this.checkBoxMouseClick.Size = new System.Drawing.Size(83, 18);
            this.checkBoxMouseClick.TabIndex = 1;
            this.checkBoxMouseClick.Text = "鼠标点击";
            this.checkBoxMouseClick.UseVisualStyleBackColor = true;
            this.checkBoxMouseClick.CheckedChanged += new System.EventHandler(this.checkBoxMouseClick_CheckedChanged);
            // 
            // checkBoxMouseMove
            // 
            this.checkBoxMouseMove.AutoSize = true;
            this.checkBoxMouseMove.Location = new System.Drawing.Point(37, 40);
            this.checkBoxMouseMove.Name = "checkBoxMouseMove";
            this.checkBoxMouseMove.Size = new System.Drawing.Size(83, 18);
            this.checkBoxMouseMove.TabIndex = 0;
            this.checkBoxMouseMove.Text = "鼠标移动";
            this.checkBoxMouseMove.UseVisualStyleBackColor = true;
            this.checkBoxMouseMove.CheckedChanged += new System.EventHandler(this.checkBoxMouseMove_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(78, 265);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(135, 42);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "确定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "夜光时钟屏保程序";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOptions_FormClosed);
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox checkBoxEscKeyDown;
        private System.Windows.Forms.CheckBox checkBoxAnyKeyDown;
        private System.Windows.Forms.CheckBox checkBoxMouseClick;
        private System.Windows.Forms.CheckBox checkBoxMouseMove;
        private System.Windows.Forms.Button btnApply;
    }
}