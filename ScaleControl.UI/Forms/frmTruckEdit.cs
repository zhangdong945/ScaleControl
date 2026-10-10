using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmTruckEdit : Form
    {
        private readonly IWeighingRepository _repository;
        private List<TruckInfo> _trucks;
        private bool _isEditing;
        private bool _isAdding;

        public frmTruckEdit(IWeighingRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "车号管理";
        }

        private void frmTruckEdit_Load(object sender, EventArgs e)
        {
            LoadTrucks();
            SetControlState(false);
        }

        private void LoadTrucks()
        {
            _trucks = _repository.QueryTrucks(null);
            dgvTrucks.DataSource = null;
            dgvTrucks.DataSource = _trucks;
            if (dgvTrucks.Columns.Count > 0)
            {
                dgvTrucks.Columns["OwsCheckType"].Visible = false;
            }
        }

        private void LoadTrucks(string filter)
        {
            _trucks = _repository.QueryTrucks(filter);
            dgvTrucks.DataSource = null;
            dgvTrucks.DataSource = _trucks;
        }

        private void SetControlState(bool editing)
        {
            _isEditing = editing;
            panelDetails.Enabled = editing;
            btnNew.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvTrucks.CurrentRow != null;
            btnDelete.Enabled = !editing && dgvTrucks.CurrentRow != null;
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
            btnExport.Enabled = !editing;
            dgvTrucks.Enabled = !editing;
            txtFilter.Enabled = !editing;
        }

        private void ClearFields()
        {
            txtTruckNo.Text = string.Empty;
            numTare.Value = 0;
            dtpTareDate.Value = DateTime.Now;
            txtInputCode.Text = string.Empty;
            numEffectDay.Value = 0;
            txtRemark.Text = string.Empty;
            numMaxGross.Value = 0;
            numMaxNet.Value = 0;
        }

        private void PopulateFields(TruckInfo truck)
        {
            if (truck == null) return;
            txtTruckNo.Text = truck.TruckNo;
            numTare.Value = truck.Tare;
            dtpTareDate.Value = truck.TareDate;
            txtInputCode.Text = truck.InputCode;
            numEffectDay.Value = truck.EffectDay;
            txtRemark.Text = truck.Remark;
            numMaxGross.Value = truck.MaxGross ?? 0;
            numMaxNet.Value = truck.MaxNet ?? 0;
        }

        private TruckInfo GetTruckFromFields()
        {
            return new TruckInfo
            {
                TruckNo = txtTruckNo.Text.Trim(),
                Tare = (long)numTare.Value,
                TareDate = dtpTareDate.Value,
                InputCode = txtInputCode.Text.Trim(),
                EffectDay = (long)numEffectDay.Value,
                Remark = txtRemark.Text.Trim(),
                MaxGross = (int)numMaxGross.Value,
                MaxNet = (int)numMaxNet.Value
            };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            ClearFields();
            SetControlState(true);
            txtTruckNo.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTrucks.CurrentRow?.DataBoundItem is TruckInfo truck)
            {
                _isAdding = false;
                PopulateFields(truck);
                SetControlState(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTrucks.CurrentRow?.DataBoundItem is TruckInfo truck)
            {
                var result = MessageBox.Show($"确定删除车号 {truck.TruckNo} 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _repository.DeleteTruck(truck.TruckNo);
                        LoadTrucks();
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTruckNo.Text))
            {
                MessageBox.Show("请输入车号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTruckNo.Focus();
                return;
            }

            try
            {
                var truck = GetTruckFromFields();
                _repository.SaveTruck(truck);
                LoadTrucks();
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
                dialog.FileName = "车号数据.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new System.IO.StreamWriter(dialog.FileName, false, System.Text.Encoding.UTF8))
                        {
                            writer.WriteLine("车号,皮重,皮重时间,输入码,有效天数,备注,最大毛重,最大净重");
                            foreach (var t in _trucks)
                            {
                                writer.WriteLine($"{t.TruckNo},{t.Tare},{t.TareDate:yyyy-MM-dd},{t.InputCode},{t.EffectDay},{t.Remark},{t.MaxGross},{t.MaxNet}");
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
            {
                LoadTrucks();
            }
            else
            {
                LoadTrucks(filter);
            }
        }

        private void dgvTrucks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTrucks.Rows[e.RowIndex].DataBoundItem is TruckInfo truck)
            {
                PopulateFields(truck);
            }
        }
    }
}
