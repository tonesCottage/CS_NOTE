using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_NOTE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打乱顺序
            Shuffle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //生成按钮格子
            GenerateAllBottons();
        }
        const int N = 4;
        Button[,] buttons = new Button[N, N];
        public void GenerateAllBottons()
        {
            int x0 = 100, y0 = 10, w = 100, h = 100;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Button button = new Button();
                    button.Text = (i * N + j + 1).ToString();
                    button.Top = y0 + i * w;
                    button.Left = x0 + j * w;
                    button.Width = w;
                    button.Height = h;
                    button.Visible = true;
                    button.Tag = i * N + j;
                    button.Click += button_Click;

                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            buttons[N - 1, N - 1].Visible = false;
        }
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int a = random.Next(N);
                int b = random.Next(N);
                int c = random.Next(N);
                int d = random.Next(N);
                Swap(buttons[a, b], buttons[c, d]);
            }

        }
        //交换按钮
        void Swap(Button a, Button b)
        {
            string str = a.Text;
            a.Text = b.Text;
            b.Text = str;
            bool bo = a.Visible;
            a.Visible = b.Visible;
            b.Visible = bo;
        }
        void button_Click(object sender, EventArgs e)
        {
            Button btn_click = sender as Button;
            Button btn_blank = FindBlankButton();
            //是否相邻
            if (IsNeibor(btn_click,btn_blank))
            {
                Swap(btn_click, btn_blank);
                btn_blank.Focus();
            }
            //是否结束
            if (ResultIsOk())
            {
                MessageBox.Show("OK");
            }
            
        }
        Button FindBlankButton()
        {
            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                {
                    if (!buttons[r, c].Visible)
                    {
                        return buttons[r, c];
                    }
                }
            return null;
        }
        bool IsNeibor(Button btn_click, Button btn_blank)
        {
            int a = (int)btn_click.Tag; //Tag中记录是行列位置
            int b = (int)btn_blank.Tag;
            int r1 = a / N, c1 = a % N;
            int r2 = b / N, c2 = b % N;

            if (r1 == r2 && (c1 == c2 - 1 || c1 == c2 + 1) //左右相邻
                || c1 == c2 && (r1 == r2 - 1 || r1 == r2 + 1))
                return true;
            return false;
        }
        bool ResultIsOk()
        {
            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                {
                    if (buttons[r, c].Text != (r * N + c + 1).ToString())
                    {
                        return false;
                    }
                }
            return true;
        }
    }
}
