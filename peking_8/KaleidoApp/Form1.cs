using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KaleidoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Kaleidoscope kaleido = new Kaleidoscope();

        private void Form1_Load(object sender, System.EventArgs e)
        {

            MakeMirrors();

            this.BackColor = Color.White;
            this.Show();
            DrawMirrors();
        }

        private void MakeMirrors()
        {
            Mirror[] mirrors = new Mirror[3];
            int w = this.Width;
            int h = this.Height;
            int x0 = w / 2;
            int y0 = h / 2;
            int r = w / 6;
            double px1 = x0 + r * Math.Cos(0);
            double py1 = y0 + r * Math.Sin(0);
            double px2 = x0 + r * Math.Cos(Math.PI * 2 / 3);
            double py2 = y0 + r * Math.Sin(Math.PI * 2 / 3);
            double px3 = x0 + r * Math.Cos(Math.PI * 4 / 3);
            double py3 = y0 + r * Math.Sin(Math.PI * 4 / 3);
            mirrors[0] = Mirror.fromTwoPoint(px1, py1, px2, py2);
            mirrors[1] = Mirror.fromTwoPoint(px3, py3, px2, py2);
            mirrors[2] = Mirror.fromTwoPoint(px3, py3, px1, py1);
            for (int i = 0; i < mirrors.Length; i++) kaleido.addMirror(mirrors[i]);
        }

        private void DrawMirrors()
        {
            using (Graphics g = this.CreateGraphics())
            {
                kaleido.drawMirrors(g, Color.Black, 0, 0);
            }
        }

        private Random random = new Random();
        private Color getRandomColor()
        {
            return Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
        }

        bool bDragging = false;
        int downX = 0;
        int downY = 0;
        PicObject currentPic = new PicObject(Color.Red);

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bDragging = true;
            downX = e.X;
            downY = e.Y;
            currentPic = new PicObject(getRandomColor());
            currentPic.filled = random.Next(5) <= 2;
            currentPic.addPoint(downX, downY);
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bDragging = false;
            kaleido.addPicObject(currentPic);
            currentPic = null;

            using (Graphics g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);
                kaleido.getPicInMirrors(3);
                kaleido.drawPicInMirrors(g, 0, 0);
                kaleido.drawMirrors(g, Color.Black, 0, 0);
            }

        }

        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!bDragging) return;
            currentPic.addPoint(e.X, e.Y);

            using (Graphics g = this.CreateGraphics())
            {
                currentPic.draw(g, 0, 0);
            }
        }
    }

}
