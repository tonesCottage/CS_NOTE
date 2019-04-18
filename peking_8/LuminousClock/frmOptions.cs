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

        private bool isEveryCheckBoxUnchecked() //判断是否所有的CheckBox都没被选中
        {
            if (!checkBoxMouseMove.Checked && !checkBoxMouseClick.Checked && !checkBoxAnyKeyDown.Checked && !checkBoxEscKeyDown.Checked)
                return true;    //所有的CheckBox都没被选中
            else
                return false;   //至少有一个CheckBox被选中
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
            if (isEveryCheckBoxUnchecked() == true) //屏保程序至少需要一个退出条件
                checkBoxMouseMove.Checked = true;
        }

        private void checkBoxMouseClick_CheckedChanged(object sender, EventArgs e)
        {
            if (isEveryCheckBoxUnchecked() == true) //屏保程序至少需要一个退出条件
                checkBoxMouseClick.Checked = true;
        }

        private void checkBoxAnyKeyDown_CheckedChanged(object sender, EventArgs e)
        {
            if (isEveryCheckBoxUnchecked() == true) //屏保程序至少需要一个退出条件
                checkBoxAnyKeyDown.Checked = true;
        }

        private void checkBoxEscKeyDown_CheckedChanged(object sender, EventArgs e)
        {
            if (isEveryCheckBoxUnchecked() == true) //屏保程序至少需要一个退出条件
                checkBoxEscKeyDown.Checked = true;
        }

        private void frmOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            //当配置窗口关闭的时候，将配置信息保存到文件中
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