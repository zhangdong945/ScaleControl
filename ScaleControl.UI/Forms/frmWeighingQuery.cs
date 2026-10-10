using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmWeighingQuery : Form
    {
        private readonly IWeighingRepository _repository;
        private List<WeighingRecord> _results;

        public frmWeighingQuery(IWeighingRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "称重记录查询";
        }

        private void frmWeighingQuery_Load(object sender, EventArgs e)
        {
            InitializeDataSourceCombo();
            InitializeFieldNames();
            InitializeOperators();
            InitializeDefaultDates();
            SetupFilterRows();
        }

        private void InitializeDataSourceCombo()
        {
            cboDataType.Items.Clear();
            cboDataType.Items.Add(new { Text = "交易数据", Value = "1" });
            cboDataType.Items.Add(new { Text = "临时数据", Value = "0" });
            cboDataType.Items.Add(new { Text = "已删除", Value = "9" });
            cboDataType.Items.Add(new { Text = "错误数据", Value = "3" });
            cboDataType.DisplayMember = "Text";
            cboDataType.ValueMember = "Value";
            cboDataType.SelectedIndex = 0;
        }

        private void InitializeFieldNames()
        {
            string[] fields = new[]
            {
                "TicketNo1", "TicketNo2", "TruckNo", "CardNo",
                "ContractNo", "Product", "Sender", "Receiver",
                "Transporter", "BusinessNo", "Driver"
            };

            foreach (var filterPanel in new[] { filterPanel1, filterPanel2, filterPanel3, filterPanel4 })
            {
                var cboField = filterPanel.Controls[0] as ComboBox;
                cboField.Items.Clear();
                cboField.Items.AddRange(fields);
                cboField.SelectedIndex = 0;
            }
        }

        private void InitializeOperators()
        {
            string[] operators = new[] { "等于", "包含", "大于", "小于", "不等于" };

            foreach (var filterPanel in new[] { filterPanel1, filterPanel2, filterPanel3, filterPanel4 })
            {
                var cboOperator = filterPanel.Controls[1] as ComboBox;
                cboOperator.Items.Clear();
                cboOperator.Items.AddRange(operators);
                cboOperator.SelectedIndex = 0;
            }
        }

        private void InitializeDefaultDates()
        {
            dtpStart.Value = DateTime.Today.AddDays(-7);
            dtpEnd.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
        }

        private void SetupFilterRows()
        {
            // Each filter panel already has ComboBox (field), ComboBox (operator), TextBox (value)
            // Panels are pre-arranged in the designer
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                var criteria = BuildCriteria();
                _results = _repository.QueryRecords(criteria);
                dgvResults.DataSource = null;
                dgvResults.DataSource = _results;
                lblRecordCount.Text = $"共 {_results.Count} 条记录";
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private WeighingQueryCriteria BuildCriteria()
        {
            var criteria = new WeighingQueryCriteria
            {
                DataType = GetDataTypeValue(),
                StartTime = dtpStart.Value,
                EndTime = dtpEnd.Value,
                FieldConditions = new List<FieldCondition>()
            };

            foreach (var filterPanel in new[] { filterPanel1, filterPanel2, filterPanel3, filterPanel4 })
            {
                var cboField = filterPanel.Controls[0] as ComboBox;
                var cboOperator = filterPanel.Controls[1] as ComboBox;
                var txtValue = filterPanel.Controls[2] as TextBox;

                if (!string.IsNullOrWhiteSpace(txtValue.Text))
                {
                    criteria.FieldConditions.Add(new FieldCondition
                    {
                        FieldName = cboField.SelectedItem?.ToString(),
                        Operator = ConvertOperator(cboOperator.SelectedItem?.ToString()),
                        Value = txtValue.Text.Trim()
                    });
                }
            }

            return criteria;
        }

        private string GetDataTypeValue()
        {
            if (cboDataType.SelectedItem == null) return "1";
            dynamic item = cboDataType.SelectedItem;
            return item.Value;
        }

        private string ConvertOperator(string displayOperator)
        {
            switch (displayOperator)
            {
                case "等于": return "=";
                case "包含": return "LIKE";
                case "大于": return ">";
                case "小于": return "<";
                case "不等于": return "<>";
                default: return "=";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboDataType.SelectedIndex = 0;
            InitializeDefaultDates();
            InitializeFieldNames();
            InitializeOperators();

            foreach (var filterPanel in new[] { filterPanel1, filterPanel2, filterPanel3, filterPanel4 })
            {
                var txtValue = filterPanel.Controls[2] as TextBox;
                txtValue.Text = string.Empty;
            }

            dgvResults.DataSource = null;
            lblRecordCount.Text = "共 0 条记录";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_results == null || _results.Count == 0)
            {
                MessageBox.Show("没有可导出的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV文件|*.csv";
                dialog.FileName = $"称重记录_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var writer = new System.IO.StreamWriter(dialog.FileName, false, System.Text.Encoding.UTF8))
                        {
                            writer.WriteLine("磅单号,车号,货物,发货单位,收货单位,毛重,皮重,净重,称重时间,数据状态");
                            foreach (var r in _results)
                            {
                                writer.WriteLine(
                                    $"{EscapeCsv(r.TicketNo2)}," +
                                    $"{EscapeCsv(r.TruckNo)}," +
                                    $"{EscapeCsv(r.Product)}," +
                                    $"{EscapeCsv(r.Sender)}," +
                                    $"{EscapeCsv(r.Receiver)}," +
                                    $"{r.Gross}," +
                                    $"{r.Tare}," +
                                    $"{r.Net}," +
                                    $"{EscapeCsv(r.SecondDateTime?.ToString("yyyy-MM-dd HH:mm:ss"))}," +
                                    $"{EscapeCsv(r.DataStatus)}");
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

        private static string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow?.DataBoundItem is WeighingRecord record)
            {
                MessageBox.Show($"补打磅单: {record.TicketNo2}", "补打磅单", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请先选择一条记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow?.DataBoundItem is WeighingRecord record)
            {
                using (var detailForm = new frmDetailRecord(_repository, record.Id))
                {
                    detailForm.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("请先选择一条记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
