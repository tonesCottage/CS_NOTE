using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace baobao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image image = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            image = pictureBox1.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Graphics g = Graphics.FromImage(image);
                Font font = new System.Drawing.Font("微软雅黑", 12, (System.Drawing.FontStyle.Bold));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.White, Color.FromArgb(100,100,100), 1.2f, true);
                g.DrawString(textBox1.Text, font, brush, 100, 184);
                g.DrawString(textBox2.Text, font, brush, 100, 417);
                g.DrawString(textBox3.Text, font, brush, 100, 650);
                g.Dispose();

                pictureBox1.Image = image;

                Clipboard.SetDataObject(pictureBox1.Image);
                MessageBox.Show("当前图片已经成功复制到剪贴板.请粘贴到QQ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::baobao.Properties.Resources._20130110160920029;
        }
       
    }
}
