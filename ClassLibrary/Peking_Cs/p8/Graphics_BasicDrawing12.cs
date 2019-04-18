using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Peking_Cs.p8
{
    class Graphics_BasicDrawing12
    {
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen;
            Point point = new Point(10, 10);
            Size sizeLine = new Size(0, 150);
            Size sizeOff = new Size(30, 0);
            pen = Pens.LimeGreen;
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
            pen = SystemPens.MenuText;
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
            pen = new Pen(Color.Red);
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
            pen = new Pen(Color.Red, 8);
            g.DrawLine(pen, point += sizeOff, point + sizeLine);

            pen.DashStyle = DashStyle.Dash;
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
            pen.DashStyle = DashStyle.Dot;
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
            pen.DashStyle = DashStyle.Solid;
            pen.StartCap = LineCap.Round;
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
            pen.EndCap = LineCap.Triangle;
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
            pen.DashPattern = new float[] { 0.5f, 1f, 1, 5f, 2f, 2.5f };
            g.DrawLine(pen, point += sizeOff, point + sizeLine);
        }
        private void Form2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            FontFamily[] families = FontFamily.GetFamilies(e.Graphics);
            Font font;
            string familyString;
            float spacing = 0;
            foreach (FontFamily family in families)
            {
                try
                {
                    font = new Font(family, 16, FontStyle.Bold);
                    familyString = "This is the " + family.Name + "family.";
                    e.Graphics.DrawString(
                        familyString,
                        font,
                        Brushes.Black,
                        new PointF(0, spacing));
                    spacing += font.Height + 5;
                }
                catch
                { }
            }
        }
        private void Form1_Paint3(object sender, System.Windows.Forms.PaintEventArgs e)

        {

            Graphics g = e.Graphics;



            Point point = new Point(10, 10);

            Rectangle rect = new Rectangle(10, 10, 20, 150);

            Point off = new Point(30, 0);





            Brush brush;



            brush = Brushes.Azure;

            rect.Offset(off); g.FillRectangle(brush, rect);

            brush = SystemBrushes.Desktop;

            rect.Offset(off); g.FillRectangle(brush, rect);

            brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));

            rect.Offset(off); g.FillRectangle(brush, rect);



            Image bm = Bitmap.FromFile(@"heart.ico");

            brush = new TextureBrush(bm);

            rect.Offset(off); g.FillRectangle(brush, rect);



            brush = new HatchBrush(

                HatchStyle.Vertical,

                Color.ForestGreen,

                Color.Honeydew);

            rect.Offset(off); g.FillRectangle(brush, rect);



            brush = new LinearGradientBrush(

                new PointF(50, 50), new PointF(200, 200),

                Color.Red, Color.Yellow);

            rect.Offset(off); g.FillRectangle(brush, rect);

        }
        private void Form4_Paint(object sender, System.Windows.Forms.PaintEventArgs e)

        {

            Graphics g = e.Graphics;



            PointF[] cur1 = new PointF[150];

            for (int i = 0; i < cur1.Length; i++)

            {

                double x = (double)i / 5;

                double y = Math.Sin(x) * 3 + Math.Cos(3 * x);

                cur1[i] = new PointF((float)i, (float)(y * 10 + 100));

            }

            g.DrawLines(Pens.Blue, cur1);



            PointF[] cur2 = new PointF[100];

            for (int i = 0; i < cur2.Length; i++)

            {

                double theta = Math.PI / 50 * i;

                double r = Math.Cos(theta * 16);

                cur2[i] = new PointF(

                    (float)(r * Math.Cos(theta) * 50 + 230),

                    (float)(r * Math.Sin(theta) * 50 + 100));

            }

            g.DrawLines(Pens.Blue, cur2);

        }
        private void Form5_Paint(object sender, System.Windows.Forms.PaintEventArgs e)

        {

            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.White, 0, 0, 456, 12);



            float x = g.VisibleClipBounds.Width;

            float y = g.VisibleClipBounds.Height;

            PointF[] pts =

            {

        new PointF(0,0), new PointF(x/2,0),

        new PointF(x/2,y/2), new PointF(0,y/2)

    };

            Pen pen = new Pen(Color.Blue, 1.0F);

            g.ScaleTransform(0.8F, 0.8F);

            g.TranslateTransform(x / 2, y / 2 + 20);

            for (int i = 0; i < 36; i++)

            {

                g.DrawBeziers(pen, pts);

                g.DrawRectangle(pen, -x / 12, -y / 12, x / 6, y / 6);

                g.DrawEllipse(pen, -x / 4, -y / 3, x / 2, y * 2 / 3);

                g.RotateTransform(10);

            }

        }
        private void Form6_Paint(object sender, System.Windows.Forms.PaintEventArgs e)

        {



            GraphicsPath gp = new GraphicsPath(FillMode.Winding);

            gp.AddString(

                "字体轮廓",

                new FontFamily("方正舒体"),

                (int)FontStyle.Regular,

                80,

                new PointF(10, 20),

                new StringFormat());



            Brush brush = new LinearGradientBrush(

                    new PointF(0, 0), new PointF(23, 23),

                    Color.Red, Color.Yellow);



            e.Graphics.DrawPath(Pens.Black, gp);

            e.Graphics.FillPath(brush, gp);



        }
    }
}
