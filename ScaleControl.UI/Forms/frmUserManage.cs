using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmUserManage : Form
    {
        private readonly IWeighingRepository _repository;
        private List<UserInfo> _users;
        private List<RoleInfo> _roles;
        private bool _isEditing;

        public frmUserManage(IWeighingRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "用户管理";
        }

        private void frmUserManage_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadUsers();
            SetControlState(false);
        }

        private void LoadRoles()
        {
            _roles = _repository.GetRoles();
            cmbGroupName.DataSource = null;
            cmbGroupName.DataSource = _roles;
            cmbGroupName.DisplayMember = "GroupName";
            cmbGroupName.ValueMember = "GroupName";
        }

        private void LoadUsers()
        {
            _users = _repository.GetUsers();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _users;
        }

        private void SetControlState(bool editing)
        {
            _isEditing = editing;
            panelDetails.Enabled = editing;
            btnNew.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvUsers.CurrentRow != null;
            btnDelete.Enabled = !editing && dgvUsers.CurrentRow != null;
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
            dgvUsers.Enabled = !editing;
        }

        private void ClearFields()
        {
            txtUserId.Text = string.Empty;
            txtLogName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            if (cmbGroupName.Items.Count > 0)
                cmbGroupName.SelectedIndex = 0;
        }

        private void PopulateFields(UserInfo user)
        {
            if (user == null) return;
            txtUserId.Text = user.UserId;
            txtLogName.Text = user.LogName;
            txtUserName.Text = user.UserName;
            cmbGroupName.SelectedItem = user.GroupName;
            txtPassword.Text = string.Empty;
        }

        private UserInfo GetUserFromFields()
        {
            return new UserInfo
            {
                UserId = txtUserId.Text.Trim(),
                LogName = txtLogName.Text.Trim(),
                UserName = txtUserName.Text.Trim(),
                GroupName = cmbGroupName.Text,
                Password = txtPassword.Text
            };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetControlState(true);
            txtUserId.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is UserInfo user)
            {
                PopulateFields(user);
                SetControlState(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.DataBoundItem is UserInfo user)
            {
                var result = MessageBox.Show($"确定删除用户 {user.LogName} 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _repository.SaveUser(new UserInfo { UserId = user.UserId });
                        LoadUsers();
                        MessageBox.Show("操作完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("操作失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserId.Text))
            {
                MessageBox.Show("请输入用户ID", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserId.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLogName.Text))
            {
                MessageBox.Show("请输入登录名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogName.Focus();
                return;
            }

            try
            {
                var user = GetUserFromFields();
                _repository.SaveUser(user);
                LoadUsers();
                SetControlState(false);
                ClearFields();
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearFields();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Rows[e.RowIndex].DataBoundItem is UserInfo user)
            {
                PopulateFields(user);
            }
        }
    }
}
