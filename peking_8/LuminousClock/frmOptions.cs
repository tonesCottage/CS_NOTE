using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LuminousClock
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private bool isEveryCheckBoxUnchecked() //�ж��Ƿ����е�CheckBox��û��ѡ��
        {
            if (!checkBoxMouseMove.Checked && !checkBoxMouseClick.Checked && !checkBoxAnyKeyDown.Checked && !checkBoxEscKeyDown.Checked)
                return true;    //���е�CheckBox��û��ѡ��
            else
                return false;   //������һ��CheckBox��ѡ��
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            checkBoxMouseMove.Checked  = ConfigParams.MouseMoveExit;
            checkBoxMouseClick.Checked = ConfigParams.MouseClickExit;
            checkBoxAnyKeyDown.Checked = ConfigParams.AnyKeyDownExit;
            checkBoxEscKeyDown.Checked = ConfigParams.EscKeyDownExit;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ConfigParams.MouseMoveExit = checkBoxMouseMove.Checked;
            ConfigParams.MouseClickExit = checkBoxMouseClick.Checked;
            ConfigParams.AnyKeyDownExit = checkBoxAnyKeyDown.Checked;
            ConfigParams.EscKeyDownExit =  checkBoxEscKeyDown.Checked;
            this.Close();
        }

        private void checkBoxMouseMove_CheckedChanged(object sender, EventArgs e)
        {
            if (isEveryCheckBoxUnchecked() == true) //��������������Ҫһ���˳�����
                checkBoxMouseMove.Checked = true;
        }

        private void checkBoxMouseClick_CheckedChanged(object sender, EventArgs e)
        {
            if (isEveryCheckBoxUnchecked() == true) //��������������Ҫһ���˳�����
                checkBoxMouseClick.Checked = true;
        }

        private void checkBoxAnyKeyDown_CheckedChanged(object sender, EventArgs e)
        {
            if (isEveryCheckBoxUnchecked() == true) //��������������Ҫһ���˳�����
                checkBoxAnyKeyDown.Checked = true;
        }

        private void checkBoxEscKeyDown_CheckedChanged(object sender, EventArgs e)
        {
            if (isEveryCheckBoxUnchecked() == true) //��������������Ҫһ���˳�����
                checkBoxEscKeyDown.Checked = true;
        }

        private void frmOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            //�����ô��ڹرյ�ʱ�򣬽�������Ϣ���浽�ļ���
            StreamWriter sw;

            try
            {
                sw = new StreamWriter("C://LuminousClock.conf", false, Encoding.UTF8);

                sw.WriteLine(ConfigParams.MouseMoveExit.ToString());
                sw.WriteLine(ConfigParams.MouseClickExit.ToString());
                sw.WriteLine(ConfigParams.AnyKeyDownExit.ToString());
                sw.WriteLine(ConfigParams.EscKeyDownExit.ToString());
                
                sw.Close();
            }
            catch
            {
            }
        }
    }
}