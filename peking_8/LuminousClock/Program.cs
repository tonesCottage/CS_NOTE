using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LuminousClock
{
    class Program
    {
        static void Main(string[] args)     //������
        {
            try
            {
                if (args.Length > 0)
                {
                    //��������в���
                    string arg = args[0].ToLower().Trim().Substring(0, 2);

                    switch (arg)
                    {
                        case "/c":
                            //��ʼ���в�������
                            ShowOptions();
                            break;
                        case "/p":
                            //Ԥ����ʵ����ʲôҲû����
                            break;
                        case "/s":
                            //��ʾ��������
                            ShowScreenSaver();
                            break;
                        default:
                            MessageBox.Show("�����в�������", "��������");
                            break;
                    }
                }
                else
                {
                    //���û�������в�������ʼ��ʾ��������
                    ShowScreenSaver();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "��������");
            }
        }

        static void ShowOptions()
        {
            frmOptions options = new frmOptions();
            Application.Run(options);
        }

        static void ShowScreenSaver()
        {
            ScreenSaverClock clk = new ScreenSaverClock();
            Application.Run(clk);
        }
    }
}
