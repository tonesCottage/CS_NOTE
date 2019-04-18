using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace LuminousClock
{
    enum ImageShape     //���Ƶ�ͼ�ε�����
    {
        Circle,         //Բ��
        Cube,           //������
        Triangle,       //������
    }

    public partial class ScreenSaverClock : Form
    {
        private int clockRadius;                //ʱ�ӱ��̵İ뾶
        private int hRadius, mRadius, sRadius;  //ʱ�롢���롢����ĳ���
        private int hDegree, mDegree, sDegree;  //ʱ�롢���롢����ĽǶȣ������12����λ�ã�
        private string today;                   //��ʾ���������ڼ�
        private int countMouseMove;             //����ƶ��¼������Ĵ���

        public ScreenSaverClock()           //���캯��
        {
            InitializeComponent();

            Cursor.Hide();                  //�������
            countMouseMove = 0;             //����������
            tmrRefresh.Start();             //��ʱ����ʼ����
        }

        private void ScreenSaverClock_Paint(object sender, PaintEventArgs e)
        {
            //���ȣ���ʼ��4�����뾶����ֵ
            clockRadius = (int)(this.Height * 0.37);
            hRadius = (int)(clockRadius * 0.63);
            mRadius = (int)(clockRadius * 0.74);
            sRadius = (int)(clockRadius * 1.01);

            int i, r, h;                    //����3����ʱ����������i��ѭ��������

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;    
            
            g.Clear(Color.BlueViolet);                                   //ȫ��ʹ�ú�ɫ���
            g.TranslateTransform(this.Width / 2, this.Height / 2);  //��gƽ������Ļ������

            //�������̣���3��������ɣ�
            r = (int)(clockRadius * 1.15);
            g.FillEllipse(new SolidBrush(Color.FromArgb(49, 49, 49)), -r, -r, r * 2, r * 2);
            r = (int)(clockRadius * 1.12);
            g.FillEllipse(new SolidBrush(Color.Black), -r, -r, r * 2, r * 2);
            DrawVagueShapes(g, ImageShape.Circle, 0, clockRadius, 1.1, Color.Black, Color.FromArgb(21, 21, 21), Color.FromArgb(15, 15, 15), false);
            
            //������Ŀ̶ȱ�־
            for (i = 0; i < 12; i++)
            {
                DrawVagueShapes(g, ImageShape.Circle, clockRadius, 10, 3.1, Color.Blue, Color.FromArgb(41, 92, 145), Color.FromArgb(15, 15, 15), true);
                g.RotateTransform(30);      //��g��ת30��
            }

            //��������Ŀ̶ȱ�־
            r = 8;
            h = 3;
            for (i = 0; i < 60; i++)
            {
                if (i % 5 != 0)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(94, 101, 109)), clockRadius - r, -h, r * 2, h * 2);
                }
                g.RotateTransform(6);       //��g��ת6��
            }
            
            //��ʾ��ǰ���ڼ�������
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            r = (int)(clockRadius * 0.2);
            g.DrawString(today, new Font("Times New Roman", 28), new SolidBrush(Color.Gray), new PointF(0, r), strFormat);

            g.RotateTransform(270);         //��g��ת��12����λ��

            //��ʱ��Ķ���
            g.RotateTransform(hDegree);
            r = 18;
            h = 3;
            DrawVagueShapes(g, ImageShape.Cube, hRadius, r, 2.2, Color.FromArgb(100, 255, 0), Color.FromArgb(59, 102, 25), Color.FromArgb(15, 15, 15), true);

            //��ʱ������Ӳ���
            g.FillRectangle(new SolidBrush(Color.Black), 0, -h, hRadius - r, h * 2);

            //������Ķ���
            g.RotateTransform(mDegree - hDegree);
            r = 12;
            h = 3;
            DrawVagueShapes(g, ImageShape.Triangle, mRadius, r, 2.6, Color.Yellow, Color.FromArgb(91, 93, 15), Color.FromArgb(15, 15, 15), true);

            //����������Ӳ���
            g.FillRectangle(new SolidBrush(Color.Black), 0, -h, mRadius - r, h * 2);

            //������Ķ���
            g.RotateTransform(sDegree - mDegree);
            r = 15;
            h = 3;
            DrawVagueShapes(g, ImageShape.Circle, sRadius, r, 2.1, Color.Red, Color.FromArgb(170, 10, 20), Color.FromArgb(20, 15, 15), true);

            //����������Ӳ���
            g.FillRectangle(new SolidBrush(Color.Black), 0, -h, sRadius - r, h * 2);

            //����Ļ���ĵ�СԲȦ����ʱ�ӵ�ת�ᣩ
            r = 15;
            g.FillEllipse(new SolidBrush(Color.Black), -r, -r, r * 2, r * 2);
            r = 9;
            g.FillEllipse(new SolidBrush(Color.Purple), -r, -r, r * 2, r * 2);
        }

        private void DrawVagueShapes(Graphics g, ImageShape shapeType, int R, int r, double scale, Color centerColor,Color middleColor, Color edgeColor, bool drawCenter)
        /*
         * ���������ڻ�����һ��ģ��Ч����ͼ��
         * �ٶ�g�Ѿ���λ����Ļ������
         * shapeType������Ƶ���Բ�Ρ������λ���������
         * R��������ͼ�ε���������Ļ����֮��ľ���
         * r����������ͼ�ε��������ֵġ���С��
         * scale������ģ����������������֮��ı�ֵ
         * centerColor����������ͼ�ε��������ֵ���ɫ
         * middleColor��edgeColor����������ͼ�ε�ģ�����ֵĽ�����ɫ
         * drawCenter��ʾ�Ƿ���Ҫ�����������֣�������false�ʹ���������������
         */
        {
            int r1, r2, r3;     //�⾶���о����ھ�

            r1 = (int)(r * scale);

            if (shapeType == ImageShape.Triangle)
            {
                r2 = (int)(r * 1.2);
                r3 = (int)(r * 0.85);
            }
            else
            {
                r2 = (int)(r * 1.15);
                r3 = (int)(r * 0.9);
            }

            //���Ȼ���ģ������
            Rectangle rect = new Rectangle();   //��������
            Point[] points = new Point[3];      //��������
            
            switch (shapeType)
            {
                case ImageShape.Circle:
                case ImageShape.Cube:
                    InitRectangle(ref rect, R, r1);
                    break;
                case ImageShape.Triangle:
                    InitTriangle(ref points, R, r1);
                    break;
            }

            GraphicsPath path = new GraphicsPath();

            switch (shapeType)
            {
                case ImageShape.Circle:
                    path.AddEllipse(rect);
                    break;
                case ImageShape.Cube:
                    path.AddRectangle(rect);
                    break;
                case ImageShape.Triangle:
                    path.AddPolygon(points);
                    break;
            }

            //����һ�����仭��
            PathGradientBrush pathBrush = new PathGradientBrush(path);
            pathBrush.CenterPoint = new PointF(R, 0);
            pathBrush.CenterColor = middleColor;
            pathBrush.SurroundColors = new Color[] { edgeColor };

            //ʹ�ý��仭�ʽ��л�ͼ��ʵ�֡�ģ������Ч��
            switch (shapeType)
            {
                case ImageShape.Circle:
                    g.FillEllipse(pathBrush, rect);
                    break;
                case ImageShape.Cube:
                    g.FillRectangle(pathBrush, rect);
                    break;
                case ImageShape.Triangle:
                    g.FillPolygon(pathBrush, points);
                    break;
            }

            //�������Ҫ�����������֣���ֱ���˳�������
            if (drawCenter == false)
                return;

            //Ȼ�������������
            switch (shapeType)
            {
                case ImageShape.Circle:
                    InitRectangle(ref rect, R, r2);
                    g.FillEllipse(new SolidBrush(Color.Black), rect);
                    InitRectangle(ref rect, R, r3);
                    g.FillEllipse(new SolidBrush(centerColor), rect);
                    break;
                case ImageShape.Cube:
                    InitRectangle(ref rect, R, r2);
                    g.FillRectangle(new SolidBrush(Color.Black), rect);
                    InitRectangle(ref rect, R, r3);
                    g.FillRectangle(new SolidBrush(centerColor), rect);
                    break;
                case ImageShape.Triangle:
                    InitTriangle(ref points, R, r2);
                    g.FillPolygon(new SolidBrush(Color.Black), points);
                    InitTriangle(ref points, R, r3);
                    g.FillPolygon(new SolidBrush(centerColor), points);
                    break;
            }
        }

        private void InitRectangle(ref Rectangle rect, int R, int r)
        {
            //����ʱ�롢���롢����Ķ���ʱ����Ҫ���ñ�����
            rect.X = R - r;
            rect.Y = -r;
            rect.Width = r * 2;
            rect.Height = r * 2;
        }

        private void InitTriangle(ref Point[] points, int R, int r)
        {
            //����ʱ�롢���롢����Ķ���ʱ����Ҫ���ñ�����
            points[0].X = R + r * 2;
            points[0].Y = 0;
            points[1].X = R - r;
            points[1].Y = (int)(r * 1.732);
            points[2].X = R - r;
            points[2].Y = (int)(-r * 1.732);
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            //�޸�ʱ�롢���롢����ĽǶȣ������12����λ�ã�
            sDegree = DateTime.Now.Second * 6;
            mDegree = DateTime.Now.Minute * 6;
            hDegree = DateTime.Now.Hour * 30 + DateTime.Now.Minute / 2;

            //��ȡ���������ڼ����������ַ���today��
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    today = "M O N";
                    break;
                case DayOfWeek.Tuesday:
                    today = "T U E";
                    break;
                case DayOfWeek.Wednesday:
                    today = "W E D";
                    break;
                case DayOfWeek.Thursday:
                    today = "T H U";
                    break;
                case DayOfWeek.Friday:
                    today = "F R I";
                    break;
                case DayOfWeek.Saturday:
                    today = "S A T";
                    break;
                case DayOfWeek.Sunday:
                    today = "S U N";
                    break;
            }

            //�ػ�����Form�ؼ�
            this.Refresh();
        }

        private void ScreenSaverClock_MouseClick(object sender, MouseEventArgs e)
        {
            if (ConfigParams.MouseClickExit == true)
                this.Close();
        }

        private void ScreenSaverClock_MouseMove(object sender, MouseEventArgs e)
        {
            if (ConfigParams.MouseMoveExit == true)
            {
                countMouseMove++;

                //Ϊ�˷�ֹ���������У����Խ�������ƶ����㹻��ε�ʱ�򣬲��˳���������
                if (countMouseMove > 6)
                    Close();
            }
        }

        private void ScreenSaverClock_KeyDown(object sender, KeyEventArgs e)
        {
            if (ConfigParams.AnyKeyDownExit == true)
                this.Close();

            if (ConfigParams.EscKeyDownExit == true && e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}