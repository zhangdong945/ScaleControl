using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmRoleManage : Form
    {
        private readonly IWeighingRepository _repository;
        private List<RoleInfo> _roles;
        private bool _isEditing;

        public frmRoleManage(IWeighingRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "角色管理";
        }

        private void frmRoleManage_Load(object sender, EventArgs e)
        {
            LoadRoles();
            SetControlState(false);
        }

        private void LoadRoles()
        {
            _roles = _repository.GetRoles();
            dgvRoles.DataSource = null;
            dgvRoles.DataSource = _roles;
        }

        private void SetControlState(bool editing)
        {
            _isEditing = editing;
            panelDetails.Enabled = editing;
            btnNew.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvRoles.CurrentRow != null;
            btnDelete.Enabled = !editing && dgvRoles.CurrentRow != null;
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
            dgvRoles.Enabled = !editing;
        }

        private void ClearFields()
        {
            numGroupId.Value = 0;
            txtGroupName.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }

        private void PopulateFields(RoleInfo role)
        {
            if (role == null) return;
            numGroupId.Value = role.GroupId;
            txtGroupName.Text = role.GroupName;
            txtRemark.Text = role.Remark;
        }

        private RoleInfo GetRoleFromFields()
        {
            return new RoleInfo
            {
                GroupId = (int)numGroupId.Value,
                GroupName = txtGroupName.Text.Trim(),
                Remark = txtRemark.Text.Trim()
            };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetControlState(true);
            numGroupId.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow?.DataBoundItem is RoleInfo role)
            {
                PopulateFields(role);
                SetControlState(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoles.CurrentRow?.DataBoundItem is RoleInfo role)
            {
                var result = MessageBox.Show($"确定删除角色 {role.GroupName} 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _repository.SaveRole(new RoleInfo { GroupId = role.GroupId });
                        LoadRoles();
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
            if (string.IsNullOrWhiteSpace(txtGroupName.Text))
            {
                MessageBox.Show("请输入角色名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGroupName.Focus();
                return;
            }

            try
            {
                var role = GetRoleFromFields();
                _repository.SaveRole(role);
                LoadRoles();
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

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRoles.Rows[e.RowIndex].DataBoundItem is RoleInfo role)
            {
                PopulateFields(role);
            }
        }
    }
}
