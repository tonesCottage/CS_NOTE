namespace GravityBallScreenSaver
{
    partial class frmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nbrElastMax = new System.Windows.Forms.NumericUpDown();
            this.nbrElastMin = new System.Windows.Forms.NumericUpDown();
            this.nbrSpeedMax = new System.Windows.Forms.NumericUpDown();
            this.nbrMassMax = new System.Windows.Forms.NumericUpDown();
            this.nbrMassMin = new System.Windows.Forms.NumericUpDown();
            this.nbrGravity = new System.Windows.Forms.NumericUpDown();
            this.nbrBalls = new System.Windows.Forms.NumericUpDown();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nbrElastMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrElastMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSpeedMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrMassMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrMassMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrGravity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrBalls)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Balls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gravity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mass (Minimum)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mass (Maximum)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Velocity (Maximum)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Elasticity (Minimum)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Elasticity (Maximum)";
            // 
            // nbrElastMax
            // 
            this.nbrElastMax.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GravityBallScreenSaver.Properties.Settings.Default, "ElastMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nbrElastMax.DecimalPlaces = 2;
            this.nbrElastMax.Location = new System.Drawing.Point(124, 167);
            this.nbrElastMax.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nbrElastMax.Name = "nbrElastMax";
            this.nbrElastMax.Size = new System.Drawing.Size(120, 20);
            this.nbrElastMax.TabIndex = 19;
            this.nbrElastMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nbrElastMax.Value = global::GravityBallScreenSaver.Properties.Settings.Default.ElastMax;
            // 
            // nbrElastMin
            // 
            this.nbrElastMin.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GravityBallScreenSaver.Properties.Settings.Default, "ElastMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nbrElastMin.DecimalPlaces = 2;
            this.nbrElastMin.Location = new System.Drawing.Point(124, 141);
            this.nbrElastMin.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nbrElastMin.Name = "nbrElastMin";
            this.nbrElastMin.Size = new System.Drawing.Size(120, 20);
            this.nbrElastMin.TabIndex = 17;
            this.nbrElastMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nbrElastMin.Value = global::GravityBallScreenSaver.Properties.Settings.Default.ElastMin;
            // 
            // nbrSpeedMax
            // 
            this.nbrSpeedMax.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GravityBallScreenSaver.Properties.Settings.Default, "Speed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nbrSpeedMax.Location = new System.Drawing.Point(124, 115);
            this.nbrSpeedMax.Name = "nbrSpeedMax";
            this.nbrSpeedMax.Size = new System.Drawing.Size(120, 20);
            this.nbrSpeedMax.TabIndex = 15;
            this.nbrSpeedMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nbrSpeedMax.Value = global::GravityBallScreenSaver.Properties.Settings.Default.Speed;
            // 
            // nbrMassMax
            // 
            this.nbrMassMax.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GravityBallScreenSaver.Properties.Settings.Default, "MassMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nbrMassMax.Location = new System.Drawing.Point(124, 89);
            this.nbrMassMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nbrMassMax.Name = "nbrMassMax";
            this.nbrMassMax.Size = new System.Drawing.Size(120, 20);
            this.nbrMassMax.TabIndex = 12;
            this.nbrMassMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nbrMassMax.ThousandsSeparator = true;
            this.nbrMassMax.Value = global::GravityBallScreenSaver.Properties.Settings.Default.MassMax;
            // 
            // nbrMassMin
            // 
            this.nbrMassMin.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GravityBallScreenSaver.Properties.Settings.Default, "MassMin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nbrMassMin.Location = new System.Drawing.Point(124, 63);
            this.nbrMassMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nbrMassMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbrMassMin.Name = "nbrMassMin";
            this.nbrMassMin.Size = new System.Drawing.Size(120, 20);
            this.nbrMassMin.TabIndex = 11;
            this.nbrMassMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nbrMassMin.ThousandsSeparator = true;
            this.nbrMassMin.Value = global::GravityBallScreenSaver.Properties.Settings.Default.MassMin;
            // 
            // nbrGravity
            // 
            this.nbrGravity.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GravityBallScreenSaver.Properties.Settings.Default, "Gravity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nbrGravity.DecimalPlaces = 7;
            this.nbrGravity.Location = new System.Drawing.Point(124, 37);
            this.nbrGravity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nbrGravity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.nbrGravity.Name = "nbrGravity";
            this.nbrGravity.Size = new System.Drawing.Size(120, 20);
            this.nbrGravity.TabIndex = 10;
            this.nbrGravity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nbrGravity.ThousandsSeparator = true;
            this.nbrGravity.Value = global::GravityBallScreenSaver.Properties.Settings.Default.Gravity;
            // 
            // nbrBalls
            // 
            this.nbrBalls.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::GravityBallScreenSaver.Properties.Settings.Default, "BallCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nbrBalls.Location = new System.Drawing.Point(124, 12);
            this.nbrBalls.Name = "nbrBalls";
            this.nbrBalls.Size = new System.Drawing.Size(120, 20);
            this.nbrBalls.TabIndex = 9;
            this.nbrBalls.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nbrBalls.Value = global::GravityBallScreenSaver.Properties.Settings.Default.BallCount;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(169, 193);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 20;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 225);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.nbrElastMax);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nbrElastMin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nbrSpeedMax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nbrMassMax);
            this.Controls.Add(this.nbrMassMin);
            this.Controls.Add(this.nbrGravity);
            this.Controls.Add(this.nbrBalls);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.Text = "Gravity Ball";
            ((System.ComponentModel.ISupportInitialize)(this.nbrElastMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrElastMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrSpeedMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrMassMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrMassMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrGravity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrBalls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nbrBalls;
        private System.Windows.Forms.NumericUpDown nbrGravity;
        private System.Windows.Forms.NumericUpDown nbrMassMin;
        private System.Windows.Forms.NumericUpDown nbrMassMax;
        private System.Windows.Forms.NumericUpDown nbrSpeedMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nbrElastMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nbrElastMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnApply;
    }
}