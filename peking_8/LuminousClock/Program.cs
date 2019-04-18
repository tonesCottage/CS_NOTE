using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LuminousClock
{
    class Program
    {
        static void Main(string[] args)     //主函数
        {
            try
            {
                if (args.Length > 0)
                {
                    //获得命令行参数
                    string arg = args[0].ToLower().Trim().Substring(0, 2);

                    switch (arg)
                    {
                        case "/c":
                            //开始进行参数设置
                            ShowOptions();
                            break;
                        case "/p":
                            //预览（实际上什么也没做）
                            break;
                        case "/s":
                            //显示屏保程序
                            ShowScreenSaver();
                            break;
                        default:
                            MessageBox.Show("命令行参数错误", "出错啦！");
                            break;
                    }
                }
                else
                {
                    //如果没有命令行参数，则开始显示屏保程序
                    ShowScreenSaver();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "出错啦！");
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
