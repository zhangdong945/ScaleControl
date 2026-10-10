using System;
using System.Reflection;
using System.Windows.Forms;

namespace ScaleControl.UI.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "关于";
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            var asm = Assembly.GetExecutingAssembly();
            lblProductName.Text = "称重管理系统";
            lblVersion.Text = "版本: " + asm.GetName().Version.ToString();
            lblCopyright.Text = "Copyright © 2026 ScaleControl";
            lblDescription.Text = "基于 .NET Framework 4.8 的称重管理MVP系统";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
