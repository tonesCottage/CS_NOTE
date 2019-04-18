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
    enum ImageShape     //绘制的图形的类型
    {
        Circle,         //圆形
        Cube,           //正方形
        Triangle,       //三角形
    }

    public partial class ScreenSaverClock : Form
    {
        private int clockRadius;                //时钟表盘的半径
        private int hRadius, mRadius, sRadius;  //时针、分针、秒针的长度
        private int hDegree, mDegree, sDegree;  //时针、分针、秒针的角度（相对于12点钟位置）
        private string today;                   //表示今天是星期几
        private int countMouseMove;             //鼠标移动事件发生的次数

        public ScreenSaverClock()           //构造函数
        {
            InitializeComponent();

            Cursor.Hide();                  //隐藏鼠标
            countMouseMove = 0;             //计数器归零
            tmrRefresh.Start();             //定时器开始工作
        }

        private void ScreenSaverClock_Paint(object sender, PaintEventArgs e)
        {
            //首先，初始化4个“半径”的值
            clockRadius = (int)(this.Height * 0.37);
            hRadius = (int)(clockRadius * 0.63);
            mRadius = (int)(clockRadius * 0.74);
            sRadius = (int)(clockRadius * 1.01);

            int i, r, h;                    //定义3个临时变量（其中i是循环变量）

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;    
            
            g.Clear(Color.BlueViolet);                                   //全屏使用黑色填充
            g.TranslateTransform(this.Width / 2, this.Height / 2);  //将g平移至屏幕的中心

            //画主表盘（分3步绘制完成）
            r = (int)(clockRadius * 1.15);
            g.FillEllipse(new SolidBrush(Color.FromArgb(49, 49, 49)), -r, -r, r * 2, r * 2);
            r = (int)(clockRadius * 1.12);
            g.FillEllipse(new SolidBrush(Color.Black), -r, -r, r * 2, r * 2);
            DrawVagueShapes(g, ImageShape.Circle, 0, clockRadius, 1.1, Color.Black, Color.FromArgb(21, 21, 21), Color.FromArgb(15, 15, 15), false);
            
            //画整点的刻度标志
            for (i = 0; i < 12; i++)
            {
                DrawVagueShapes(g, ImageShape.Circle, clockRadius, 10, 3.1, Color.Blue, Color.FromArgb(41, 92, 145), Color.FromArgb(15, 15, 15), true);
                g.RotateTransform(30);      //将g旋转30度
            }

            //画非整点的刻度标志
            r = 8;
            h = 3;
            for (i = 0; i < 60; i++)
            {
                if (i % 5 != 0)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(94, 101, 109)), clockRadius - r, -h, r * 2, h * 2);
                }
                g.RotateTransform(6);       //将g旋转6度
            }
            
            //显示当前日期及星期数
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            r = (int)(clockRadius * 0.2);
            g.DrawString(today, new Font("Times New Roman", 28), new SolidBrush(Color.Gray), new PointF(0, r), strFormat);

            g.RotateTransform(270);         //将g旋转至12点钟位置

            //画时针的顶端
            g.RotateTransform(hDegree);
            r = 18;
            h = 3;
            DrawVagueShapes(g, ImageShape.Cube, hRadius, r, 2.2, Color.FromArgb(100, 255, 0), Color.FromArgb(59, 102, 25), Color.FromArgb(15, 15, 15), true);

            //画时针的连接部分
            g.FillRectangle(new SolidBrush(Color.Black), 0, -h, hRadius - r, h * 2);

            //画分针的顶端
            g.RotateTransform(mDegree - hDegree);
            r = 12;
            h = 3;
            DrawVagueShapes(g, ImageShape.Triangle, mRadius, r, 2.6, Color.Yellow, Color.FromArgb(91, 93, 15), Color.FromArgb(15, 15, 15), true);

            //画分针的连接部分
            g.FillRectangle(new SolidBrush(Color.Black), 0, -h, mRadius - r, h * 2);

            //画秒针的顶端
            g.RotateTransform(sDegree - mDegree);
            r = 15;
            h = 3;
            DrawVagueShapes(g, ImageShape.Circle, sRadius, r, 2.1, Color.Red, Color.FromArgb(170, 10, 20), Color.FromArgb(20, 15, 15), true);

            //画秒针的连接部分
            g.FillRectangle(new SolidBrush(Color.Black), 0, -h, sRadius - r, h * 2);

            //画屏幕中心的小圆圈（即时钟的转轴）
            r = 15;
            g.FillEllipse(new SolidBrush(Color.Black), -r, -r, r * 2, r * 2);
            r = 9;
            g.FillEllipse(new SolidBrush(Color.Purple), -r, -r, r * 2, r * 2);
        }

        private void DrawVagueShapes(Graphics g, ImageShape shapeType, int R, int r, double scale, Color centerColor,Color middleColor, Color edgeColor, bool drawCenter)
        /*
         * 本函数用于绘制有一定模糊效果的图形
         * 假定g已经定位于屏幕的中心
         * shapeType代表绘制的是圆形、正方形还是三角形
         * R代表所绘图形的中心与屏幕中心之间的距离
         * r描述了所绘图形的清晰部分的“大小”
         * scale代表了模糊部分与清晰部分之间的比值
         * centerColor代表了所绘图形的清晰部分的颜色
         * middleColor和edgeColor代表了所绘图形的模糊部分的渐变颜色
         * drawCenter表示是否需要绘制清晰部分；若等于false就代表不绘制清晰部分
         */
        {
            int r1, r2, r3;     //外径、中径、内径

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

            //首先绘制模糊部分
            Rectangle rect = new Rectangle();   //辅助矩形
            Point[] points = new Point[3];      //辅助点组
            
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

            //引入一个渐变画笔
            PathGradientBrush pathBrush = new PathGradientBrush(path);
            pathBrush.CenterPoint = new PointF(R, 0);
            pathBrush.CenterColor = middleColor;
            pathBrush.SurroundColors = new Color[] { edgeColor };

            //使用渐变画笔进行画图，实现“模糊”的效果
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

            //如果不需要绘制清晰部分，则直接退出本函数
            if (drawCenter == false)
                return;

            //然后绘制清晰部分
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
            //绘制时针、分针、秒针的顶端时，需要调用本函数
            rect.X = R - r;
            rect.Y = -r;
            rect.Width = r * 2;
            rect.Height = r * 2;
        }

        private void InitTriangle(ref Point[] points, int R, int r)
        {
            //绘制时针、分针、秒针的顶端时，需要调用本函数
            points[0].X = R + r * 2;
            points[0].Y = 0;
            points[1].X = R - r;
            points[1].Y = (int)(r * 1.732);
            points[2].X = R - r;
            points[2].Y = (int)(-r * 1.732);
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            //修改时针、分针、秒针的角度（相对于12点钟位置）
            sDegree = DateTime.Now.Second * 6;
            mDegree = DateTime.Now.Minute * 6;
            hDegree = DateTime.Now.Hour * 30 + DateTime.Now.Minute / 2;

            //获取今天是星期几，并存入字符串today中
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

            //重绘整个Form控件
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

                //为了防止鼠标过于敏感，所以仅当鼠标移动了足够多次的时候，才退出屏保程序
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