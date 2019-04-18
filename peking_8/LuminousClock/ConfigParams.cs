using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LuminousClock
{
    class ConfigParams          //允许配置的一些参数
    {
        public static bool MouseMoveExit;       //移动鼠标时退出屏保
        public static bool MouseClickExit;      //点击鼠标时退出屏保
        public static bool AnyKeyDownExit;      //按下任意按键时退出屏保
        public static bool EscKeyDownExit;      //按下ESC键时退出屏保

        static ConfigParams()   //静态构造函数
        {
            StreamReader sr;
            string oneLine;

            try
            {
                //读入配置文件
                sr = new StreamReader("C://LuminousClock.conf", Encoding.UTF8);

                oneLine = sr.ReadLine();
                MouseMoveExit = bool.Parse(oneLine);
                oneLine = sr.ReadLine();
                MouseClickExit = bool.Parse(oneLine);
                oneLine = sr.ReadLine();
                AnyKeyDownExit = bool.Parse(oneLine);
                oneLine = sr.ReadLine();
                EscKeyDownExit = bool.Parse(oneLine);

                sr.Close();
            }
            catch
            {
                //如果配置文件打开失败，则采用下面的默认参数设置
                MouseMoveExit = false;
                MouseClickExit = true;
                AnyKeyDownExit = true;
                EscKeyDownExit = true;
            }

            //屏保程序必须至少有一个退出条件
            if (MouseMoveExit == false && MouseClickExit == false && AnyKeyDownExit == false && EscKeyDownExit == false)
                MouseClickExit = true;
        }
    }
}
