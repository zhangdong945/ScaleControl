using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmProductEdit : Form
    {
        private readonly IWeighingRepository _repository;
        private List<ProductInfo> _products;
        private bool _isEditing;

        public frmProductEdit(IWeighingRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "货物管理";
        }

        private void frmProductEdit_Load(object sender, EventArgs e)
        {
            LoadProducts();
            SetControlState(false);
        }

        private void LoadProducts()
        {
            _products = _repository.GetProducts(null);
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _products;
        }

        private void LoadProducts(string filter)
        {
            _products = _repository.GetProducts(filter);
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _products;
        }

        private void SetControlState(bool editing)
        {
            _isEditing = editing;
            panelDetails.Enabled = editing;
            btnNew.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvProducts.CurrentRow != null;
            btnDelete.Enabled = !editing && dgvProducts.CurrentRow != null;
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
            btnExport.Enabled = !editing;
            dgvProducts.Enabled = !editing;
            txtFilter.Enabled = !editing;
        }

        private void ClearFields()
        {
            txtProductName.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtInputCode.Text = string.Empty;
            txtRemark.Text = string.Empty;
            chkEnableMaxNetLimit.Checked = false;
            numMaxNetLimit.Value = 0;
        }

        private void PopulateFields(ProductInfo product)
        {
            if (product == null) return;
            txtProductName.Text = product.ProductName;
            txtCode.Text = product.Code;
            txtInputCode.Text = product.InputCode;
            txtRemark.Text = product.Remark;
            chkEnableMaxNetLimit.Checked = product.EnableMaxNetLimit;
            numMaxNetLimit.Value = product.MaxNetLimit;
        }

        private ProductInfo GetProductFromFields()
        {
            return new ProductInfo
            {
                ProductName = txtProductName.Text.Trim(),
                Code = txtCode.Text.Trim(),
                InputCode = txtInputCode.Text.Trim(),
                Remark = txtRemark.Text.Trim(),
                EnableMaxNetLimit = chkEnableMaxNetLimit.Checked,
                MaxNetLimit = (long)numMaxNetLimit.Value
            };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetControlState(true);
            txtProductName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is ProductInfo product)
            {
                PopulateFields(product);
                SetControlState(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is ProductInfo product)
            {
                var result = MessageBox.Show($"确定删除货物 {product.ProductName} 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _repository.SaveProduct(new ProductInfo
                        {
                            ProductName = product.ProductName,
                            Code = product.Code
                        });
                        LoadProducts();
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
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("请输入货物名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            try
            {
                var product = GetProductFromFields();
                _repository.SaveProduct(product);
                LoadProducts();
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
                dialog.FileName = "货物数据.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new System.IO.StreamWriter(dialog.FileName, false, System.Text.Encoding.UTF8))
                        {
                            writer.WriteLine("货物名称,编码,输入码,备注,启用最大净重限制,最大净重限制");
                            foreach (var p in _products)
                            {
                                writer.WriteLine($"{p.ProductName},{p.Code},{p.InputCode},{p.Remark},{p.EnableMaxNetLimit},{p.MaxNetLimit}");
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
            string filter = txtFilter.Text.Trim();
            if (string.IsNullOrEmpty(filter))
                LoadProducts();
            else
                LoadProducts(filter);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Rows[e.RowIndex].DataBoundItem is ProductInfo product)
            {
                PopulateFields(product);
            }
        }
    }
}
