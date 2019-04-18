using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LuminousClock
{
    class ConfigParams          //�������õ�һЩ����
    {
        public static bool MouseMoveExit;       //�ƶ����ʱ�˳�����
        public static bool MouseClickExit;      //������ʱ�˳�����
        public static bool AnyKeyDownExit;      //�������ⰴ��ʱ�˳�����
        public static bool EscKeyDownExit;      //����ESC��ʱ�˳�����

        static ConfigParams()   //��̬���캯��
        {
            StreamReader sr;
            string oneLine;

            try
            {
                //���������ļ�
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
                //��������ļ���ʧ�ܣ�����������Ĭ�ϲ�������
                MouseMoveExit = false;
                MouseClickExit = true;
                AnyKeyDownExit = true;
                EscKeyDownExit = true;
            }

            //�����������������һ���˳�����
            if (MouseMoveExit == false && MouseClickExit == false && AnyKeyDownExit == false && EscKeyDownExit == false)
                MouseClickExit = true;
        }
    }
}
