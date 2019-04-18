using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GravityBallScreenSaver
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        // Apply all the changes since apply button was last pressed
        private void ApplyChanges()
        {
            Properties.Settings.Default.BallCount = nbrBalls.Value;
            Properties.Settings.Default.Gravity = nbrGravity.Value;
            Properties.Settings.Default.MassMin = nbrMassMin.Value;
            Properties.Settings.Default.MassMax = nbrMassMax.Value;
            Properties.Settings.Default.Speed = nbrSpeedMax.Value;
            Properties.Settings.Default.ElastMin = nbrElastMin.Value;
            Properties.Settings.Default.ElastMax = nbrElastMax.Value;
            Properties.Settings.Default.Save();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }


    }
}