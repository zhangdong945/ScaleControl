using System;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI
{
    public partial class frmLogin : Form
    {
        private readonly IWeighingRepository _repository;
        public UserInfo CurrentUser { get; private set; }

        public frmLogin(IWeighingRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var user = _repository.ValidateUser(txtUsername.Text.Trim(), txtPassword.Text);
            if (user != null)
            {
                CurrentUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
