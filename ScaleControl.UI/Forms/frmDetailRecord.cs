using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.UI.Forms
{
    public partial class frmDetailRecord : Form
    {
        private readonly IWeighingRepository _repository;
        private readonly long _recordId;
        private WeighingRecord _record;
        private List<OperationLog> _logs;
        private bool _isEditing;

        public frmDetailRecord(IWeighingRepository repository, long recordId)
        {
            InitializeComponent();
            _repository = repository;
            _recordId = recordId;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "称重记录详情";
        }

        private void frmDetailRecord_Load(object sender, EventArgs e)
        {
            LoadRecord();
            LoadLogs();
            DisplayRecord();
            SetEditMode(false);
        }

        private void LoadRecord()
        {
            _record = _repository.GetById(_recordId);
            if (_record == null)
            {
                MessageBox.Show("未找到该记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void LoadLogs()
        {
            try
            {
                var criteria = new LogQueryCriteria
                {
                    StartTime = _record.FirstDateTime ?? DateTime.Today.AddDays(-30),
                    EndTime = _record.SecondDateTime ?? DateTime.Now
                };
                _logs = _repository.QueryLogs(criteria);
                // Filter by current record's ticket number (KeyValue match)
                if (_logs.Count > 0 && (!string.IsNullOrEmpty(_record.TicketNo1) || !string.IsNullOrEmpty(_record.TicketNo2)))
                {
                    _logs.RemoveAll(l =>
                    {
                        if (string.IsNullOrEmpty(l.KeyValue)) return true;
                        if (!string.IsNullOrEmpty(_record.TicketNo1) && l.KeyValue == _record.TicketNo1) return false;
                        if (!string.IsNullOrEmpty(_record.TicketNo2) && l.KeyValue == _record.TicketNo2) return false;
                        return true;
                    });
                }
                dgvLogs.DataSource = null;
                dgvLogs.DataSource = _logs;
            }
            catch
            {
                _logs = new List<OperationLog>();
            }
        }

        private void DisplayRecord()
        {
            if (_record == null) return;

            txtTicketNo1.Text = _record.TicketNo1;
            txtTicketNo2.Text = _record.TicketNo2;
            txtStation1.Text = _record.Station1;
            txtStation2.Text = _record.Station2;
            txtScaleNo1.Text = _record.ScaleNo1;
            txtScaleNo2.Text = _record.ScaleNo2;
            txtTruckNo.Text = _record.TruckNo;
            txtCardNo.Text = _record.CardNo;
            txtContractNo.Text = _record.ContractNo;
            txtProduct.Text = _record.Product;
            txtProductCode.Text = _record.ProductCode;
            txtSpecification.Text = _record.Specification;
            txtSender.Text = _record.Sender;
            txtReceiver.Text = _record.Receiver;
            txtTransporter.Text = _record.Transporter;
            txtFirstDateTime.Text = _record.FirstDateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "";
            txtSecondDateTime.Text = _record.SecondDateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "";
            txtGrossDateTime.Text = _record.GrossDateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "";
            txtTareDateTime.Text = _record.TareDateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "";
            txtFirstWeight.Text = _record.FirstWeight.ToString();
            txtSecondWeight.Text = _record.SecondWeight.ToString();
            txtGross.Text = _record.Gross.ToString();
            txtTare.Text = _record.Tare.ToString();
            txtNet.Text = _record.Net.ToString();
            txtProductNet.Text = _record.ProductNet.ToString("F2");
            txtExceptWater.Text = _record.ExceptWater.ToString("F2");
            txtExceptOther.Text = _record.ExceptOther.ToString("F2");
            txtUserId1.Text = _record.UserId1;
            txtUserName1.Text = _record.UserName1;
            txtUserId2.Text = _record.UserId2;
            txtUserName2.Text = _record.UserName2;
            txtBc1.Text = _record.Bc1;
            txtBc2.Text = _record.Bc2;
            txtScaleWeightFlag.Text = _record.ScaleWeightFlag;
            txtSpareFlag.Text = _record.SpareFlag;
            txtUploadFlag.Text = _record.UploadFlag;
            txtDataEditFlag.Text = _record.DataEditFlag;
            txtDataStatus.Text = _record.DataStatus;
            txtManualInputFlag.Text = _record.ManualInputFlag;
            txtScaleMode.Text = _record.ScaleMode;
            txtFinalFlag.Text = _record.FinalFlag;
            txtLeftWeight.Text = _record.LeftWeight.ToString();
            txtTareWeightAlarmFlag.Text = _record.TareWeightAlarmFlag;
            txtTareTimeAlarmFlag.Text = _record.TareTimeAlarmFlag;
            txtWeightTimeAlarmFlag.Text = _record.WeightTimeAlarmFlag;
            txtAutoSaveFlag.Text = _record.AutoSaveFlag;
            txtAuthFlag.Text = _record.AuthFlag;
            txtDriver.Text = _record.Driver;
            txtBusinessNo.Text = _record.BusinessNo;
            txtIdNumber.Text = _record.IdNumber;
            txtBusinessType.Text = _record.BusinessType;
            txtMaxGross.Text = _record.MaxGross.ToString();
            txtMaxNet.Text = _record.MaxNet.ToString();
            txtOwsCheckType.Text = _record.OwsCheckType;
            txtReprintCount.Text = _record.ReprintCount.ToString();
            txtIdentifyTruckNo1.Text = _record.IdentifyTruckNo1;
            txtIdentifyTruckNo2.Text = _record.IdentifyTruckNo2;

            // Display weight curve placeholder
            panelWeightCurve.Paint -= PanelWeightCurve_Paint;
            panelWeightCurve.Paint += PanelWeightCurve_Paint;
            panelWeightCurve.Invalidate();
        }

        private void PanelWeightCurve_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawString("重量曲线 (MVP)", this.Font, System.Drawing.Brushes.Gray,
                new System.Drawing.PointF(10, 10));
            g.DrawRectangle(System.Drawing.Pens.LightGray, 2, 2,
                panelWeightCurve.Width - 4, panelWeightCurve.Height - 4);
        }

        private void SetEditMode(bool editing)
        {
            _isEditing = editing;

            // Editable fields
            txtTruckNo.ReadOnly = !editing;
            txtContractNo.ReadOnly = !editing;
            txtProduct.ReadOnly = !editing;
            txtSender.ReadOnly = !editing;
            txtReceiver.ReadOnly = !editing;
            txtTransporter.ReadOnly = !editing;
            txtDriver.ReadOnly = !editing;
            txtBusinessNo.ReadOnly = !editing;

            btnEdit.Enabled = !editing;
            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
            btnPrint.Enabled = !editing;
            btnClose.Enabled = !editing;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
            txtTruckNo.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _record.TruckNo = txtTruckNo.Text.Trim();
                _record.ContractNo = txtContractNo.Text.Trim();
                _record.Product = txtProduct.Text.Trim();
                _record.Sender = txtSender.Text.Trim();
                _record.Receiver = txtReceiver.Text.Trim();
                _record.Transporter = txtTransporter.Text.Trim();
                _record.Driver = txtDriver.Text.Trim();
                _record.BusinessNo = txtBusinessNo.Text.Trim();

                _repository.UpdateWeighingRecord(_record);
                DisplayRecord();
                SetEditMode(false);
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayRecord();
            SetEditMode(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"打印磅单: {txtTicketNo2.Text}", "打印", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
