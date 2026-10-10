using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmCustomerEdit : Form
    {
        private readonly IWeighingRepository _repository;
        private List<CustomerInfo> _customers;
        private bool _isEditing;
        private bool _isSender = true;

        public frmCustomerEdit(IWeighingRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "收发货单位管理";
        }

        private void frmCustomerEdit_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            SetControlState(false);
        }

        private void LoadCustomers()
        {
            if (_isSender)
                _customers = _repository.GetSenders(null);
            else
                _customers = _repository.GetReceivers(null);
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = _customers;
        }

        private void SetControlState(bool editing)
        {
            _isEditing = editing;
            panelDetails.Enabled = editing;
            btnNew.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvCustomers.CurrentRow != null;
            btnDelete.Enabled = !editing && dgvCustomers.CurrentRow != null;
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
            btnExport.Enabled = !editing;
            dgvCustomers.Enabled = !editing;
            txtFilter.Enabled = !editing;
            rbSender.Enabled = !editing;
            rbReceiver.Enabled = !editing;
        }

        private void ClearFields()
        {
            txtName.Text = string.Empty;
            txtInputCode.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }

        private void PopulateFields(CustomerInfo customer)
        {
            if (customer == null) return;
            txtName.Text = customer.Name;
            txtInputCode.Text = customer.InputCode;
            txtRemark.Text = customer.Remark;
        }

        private CustomerInfo GetCustomerFromFields()
        {
            return new CustomerInfo
            {
                Name = txtName.Text.Trim(),
                InputCode = txtInputCode.Text.Trim(),
                Remark = txtRemark.Text.Trim()
            };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetControlState(true);
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is CustomerInfo customer)
            {
                PopulateFields(customer);
                SetControlState(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is CustomerInfo customer)
            {
                var result = MessageBox.Show($"确定删除单位 {customer.Name} 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (_isSender)
                            _repository.SaveSender(new CustomerInfo { Name = customer.Name });
                        else
                            _repository.SaveReceiver(new CustomerInfo { Name = customer.Name });
                        LoadCustomers();
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入单位名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                var customer = GetCustomerFromFields();
                if (_isSender)
                    _repository.SaveSender(customer);
                else
                    _repository.SaveReceiver(customer);
                LoadCustomers();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV文件|*.csv";
                dialog.FileName = "单位数据.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new System.IO.StreamWriter(dialog.FileName, false, System.Text.Encoding.UTF8))
                        {
                            writer.WriteLine("单位名称,输入码,备注");
                            foreach (var c in _customers)
                            {
                                writer.WriteLine($"{c.Name},{c.InputCode},{c.Remark}");
                            }
                        }
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Rows[e.RowIndex].DataBoundItem is CustomerInfo customer)
            {
                PopulateFields(customer);
            }
        }

        private void rbSender_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSender.Checked)
            {
                _isSender = true;
                LoadCustomers();
            }
        }

        private void rbReceiver_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReceiver.Checked)
            {
                _isSender = false;
                LoadCustomers();
            }
        }
    }
}
