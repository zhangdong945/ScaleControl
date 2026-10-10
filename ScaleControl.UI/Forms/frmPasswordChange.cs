using System;
using System.Windows.Forms;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmPasswordChange : Form
    {
        private readonly IWeighingRepository _repository;
        private readonly string _userId;

        public frmPasswordChange(IWeighingRepository repository, string userId)
        {
            InitializeComponent();
            _repository = repository;
            _userId = userId;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "修改密码";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                MessageBox.Show("请输入原密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("请输入新密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("两次输入的新密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Length < 4)
            {
                MessageBox.Show("新密码长度至少4位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            try
            {
                _repository.UpdatePassword(_userId, txtNewPassword.Text);
                MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("密码修改失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
