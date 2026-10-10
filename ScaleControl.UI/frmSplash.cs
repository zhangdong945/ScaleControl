using System;
using System.Windows.Forms;

namespace ScaleControl.UI
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            var timer = new Timer { Interval = 2000 };
            timer.Tick += (s, ev) => { timer.Stop(); this.Close(); };
            timer.Start();
        }
    }
}
