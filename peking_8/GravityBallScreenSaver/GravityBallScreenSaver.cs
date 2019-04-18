using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GravityBallScreenSaver
{
    public struct Ball
    {
        public long mass;
        public float Px0;
        public float Py0;

        public float Vx;
        public float Vy;

        public float elasticity;

        public float[] Px;
        public float[] Py;

        public Color color;

        public Ball(long mass, float Px, float Py, float Vx, float Vy, float elasticity)
        {
            this.mass = mass;
            this.Px0 = Px;
            this.Py0 = Py;
            this.Vx = Vx;
            this.Vy = Vy;
            this.elasticity = elasticity;
            this.Px = new float[256];
            this.Py = new float[256];
            this.color = Color.Red;
        }
    }

    public partial class frmGravityBall : Form
    {        
        public frmGravityBall(int screen)
        {
            InitializeComponent();

            MakeBalls();

            // Use double buffering to improve drawing performance
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            // Capture the mouse
            this.Capture = true;

            // Set the application to full screen mode and hide the mouse
            Cursor.Hide();
            Bounds = Screen.AllScreens[screen].Bounds;
            //WindowState = FormWindowState.Maximized;
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = false;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private float Fg = (float)Properties.Settings.Default.Gravity;
        private int BallCount = (int)Properties.Settings.Default.BallCount;
        private Ball[] balls;
        private int Ploc = 0;
        private int diameter = 8;
        Random rnd = new Random();

        public void MakeBalls()
        {
            balls = new Ball[BallCount];

            for (int i = 0; i < BallCount; i++)
            {
                //balls[i] = new Ball(GetRandom(1000,100000), GetRandom(0, this.Width), GetRandom(0, this.Height), GetRandom(-5, 5), GetRandom(-5, 5), GetRandom(0.1f, 0.9f));
                balls[i] = new Ball(GetRandom((int)Properties.Settings.Default.MassMin, (int)Properties.Settings.Default.MassMax), 
                    GetRandom(0, this.Width), 
                    GetRandom(0, this.Height), 
                    GetRandom(-1f * (float)Properties.Settings.Default.Speed, (float)Properties.Settings.Default.Speed),
                    GetRandom(-1f * (float)Properties.Settings.Default.Speed, (float)Properties.Settings.Default.Speed),
                    GetRandom((float)Properties.Settings.Default.ElastMin, (float)Properties.Settings.Default.ElastMax));
                balls[i].color = Color.FromArgb((int)(Math.Log10(balls[i].mass * (float)Properties.Settings.Default.MassMax / 255f)), (int)((balls[i].Vx + (float)Properties.Settings.Default.Speed) * 128f/(float)Properties.Settings.Default.Speed), (int)((balls[i].Vy + (float)Properties.Settings.Default.Speed) * 128f/(float)Properties.Settings.Default.Speed));
            }
        }

        private float GetRandom(float min, float max)
        {
//            Random rnd = new Random();
            return (float)rnd.NextDouble() * (max - min) + min;
        }

        private int GetRandom(int min, int max)
        {
//            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            if (++Ploc > 255)
                Ploc = 0;

            for (int i = 0; i < BallCount; i++)
            {
                Ball bCurrent = balls[i];
                bCurrent.Px[Ploc] = bCurrent.Px0;
                bCurrent.Py[Ploc] = bCurrent.Py0;

                for (int j = 0; j < BallCount; j++)
                {
                    if (i != j)
                    {
                        Ball bCheck = balls[j];
                        if (Math.Abs(bCurrent.Px0 - bCheck.Px0) < diameter &&
                            Math.Abs(bCurrent.Py0 - bCheck.Py0) < diameter)
                        {
                            //bounce the balls
                        }
                        else
                        {
                            //Gravity the balls
                            float R = (float)Math.Sqrt(Math.Pow(bCurrent.Px0 - bCheck.Px0, 2) + Math.Pow(bCurrent.Py0 - bCheck.Py0, 2));
                            //float G = -1 * Fg * bCurrent.mass * bCheck.mass / (float)Math.Pow(R, 2);
                            float G = -1 * Fg * bCheck.mass / (float)Math.Pow(R, 2);

                            bCurrent.Vx += G * (bCurrent.Px0 - bCheck.Px0) / R;
                            bCurrent.Vy += G * (bCurrent.Py0 - bCheck.Py0) / R;                           
                        }
                    }
                }
                if (bCurrent.Px0 < 0 || bCurrent.Px0 + diameter > this.Width)
                {
                    //Bounce against side of screen
                    bCurrent.Vx *= -1F * bCurrent.elasticity;
                }

                if (bCurrent.Py0 < 0 || bCurrent.Py0 + diameter > this.Height)
                {
                    //Bounce against top/bottom of screen
                    bCurrent.Vy *= -1F * bCurrent.elasticity;
                }

                if (bCurrent.Px0 < 0)
                    bCurrent.Px0 = 0;
                if (bCurrent.Px0 + diameter > this.Width)
                    bCurrent.Px0 = this.Width - diameter;
                if (bCurrent.Py0 < 0)
                    bCurrent.Py0 = 0;
                if (bCurrent.Py0 + diameter > this.Height)
                    bCurrent.Py0 = this.Height - diameter;

                balls[i] = bCurrent;
            }

            for (int i = 0; i < BallCount; i++)
            {
                balls[i].Px0 += balls[i].Vx;
                balls[i].Py0 += balls[i].Vy;
            }

            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            g.Clear(Color.Black);

            for (int i = 0; i < BallCount; i++)
            {
                int iColor;
                Pen pLine;
                for (int j = 1; j < 255; j++)
                {
                    iColor = 255 - (Ploc - j);
                    if (iColor > 255)
                        iColor -= 255;
                    pLine = new Pen(Color.FromArgb(iColor, iColor, iColor));
                    try
                    {
                        g.DrawLine(pLine, balls[i].Px[j], balls[i].Py[j], balls[i].Px[j - 1], balls[i].Py[j - 1]);
                    }
                    catch { }
                }
                iColor = 255-Ploc;
                pLine = new Pen(Color.FromArgb(iColor, iColor, iColor));
                try
                {
                    g.DrawLine(pLine, balls[i].Px[0], balls[i].Py[0], balls[i].Px[255], balls[i].Py[255]);
                }
                catch { }
            }

            for (int i = 0; i < BallCount; i++)
            {
                try
                {
                    SolidBrush brBall = new SolidBrush(balls[i].color);
                    g.FillEllipse(brBall, balls[i].Px0 - diameter / 2, balls[i].Py0 - diameter / 2, diameter, diameter);
                }
                catch { }
            }

#if CLIPBOARD
            //Clipboard.SetImage();
#endif
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void frmGravityBall_KeyDown(object sender, KeyEventArgs e)
        {
#if !CLIPBOARD
            this.Close();
#endif
        }
    }
}