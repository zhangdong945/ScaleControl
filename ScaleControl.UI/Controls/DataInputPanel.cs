using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScaleControl.UI.Controls
{
    public class DataInputPanel : UserControl
    {
        private TableLayoutPanel layout;
        private TextBox txtTruckNumber;
        private TextBox txtCargo;
        private TextBox txtSender;
        private TextBox txtReceiver;
        private TextBox txtSpec;
        private TextBox txtDriver;
        private TextBox txtBusinessNo;
        private TextBox txtGrossWeight;
        private TextBox txtTareWeight;
        private TextBox txtNetWeight;
        private ComboBox cmbCargoType;
        private ErrorProvider errorProvider;

        public DataInputPanel()
        {
            errorProvider = new ErrorProvider();
            InitializeComponent();
        }

        public event EventHandler TruckNumberChanged;

        public int? GrossWeight => string.IsNullOrEmpty(txtGrossWeight.Text) ? (int?)null : (int?)double.Parse(txtGrossWeight.Text);
        public int? TareWeight => string.IsNullOrEmpty(txtTareWeight.Text) ? (int?)null : (int?)double.Parse(txtTareWeight.Text);
        public int? NetWeightValue => string.IsNullOrEmpty(txtNetWeight.Text) ? (int?)null : (int?)double.Parse(txtNetWeight.Text);

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(35, 35, 45);
            this.Padding = new Padding(10);

            layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                BackColor = Color.Transparent
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            for (int i = 0; i < 5; i++)
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));

            // Row 0: 车号, 货物
            txtTruckNumber = AddFieldRow(layout, 0, 0, "车号", true);
            txtTruckNumber.Leave += (s, e) => TruckNumberChanged?.Invoke(this, EventArgs.Empty);
            txtCargo = AddFieldRow(layout, 0, 2, "货物", false);

            // Row 1: 发货单位, 收货单位
            txtSender = AddFieldRow(layout, 1, 0, "发货单位", false);
            txtReceiver = AddFieldRow(layout, 1, 2, "收货单位", false);

            // Row 2: 规格, 司机
            txtSpec = AddFieldRow(layout, 2, 0, "规格", false);
            txtDriver = AddFieldRow(layout, 2, 2, "司机", false);

            // Row 3: 业务单号, 货物类型(ComboBox)
            txtBusinessNo = AddFieldRow(layout, 3, 0, "业务单号", false);
            AddLabel(layout, 3, 2, "货物类型");
            cmbCargoType = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("微软雅黑", 10)
            };
            cmbCargoType.Items.AddRange(new object[] { "煤炭", "矿石", "粮食", "钢材", "其他" });
            layout.Controls.Add(cmbCargoType, 3, 3);

            // Row 4: 毛重, 皮重, 净重 (ReadOnly)
            AddLabel(layout, 4, 0, "毛重(kg)");
            txtGrossWeight = new TextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.FromArgb(50, 50, 60),
                ForeColor = Color.Lime,
                Font = new Font("微软雅黑", 10)
            };
            layout.Controls.Add(txtGrossWeight, 1, 4);

            AddLabel(layout, 4, 2, "皮重(kg)");
            txtTareWeight = new TextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.FromArgb(50, 50, 60),
                ForeColor = Color.Lime,
                Font = new Font("微软雅黑", 10)
            };
            layout.Controls.Add(txtTareWeight, 3, 4);

            // Net weight row below
            var netPanel = new Panel { Dock = DockStyle.Bottom, Height = 40, BackColor = Color.Transparent };
            var netLabel = new Label
            {
                Text = "净重(kg):",
                Font = new Font("微软雅黑", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 10,
                Top = 8
            };
            txtNetWeight = new TextBox
            {
                ReadOnly = true,
                BackColor = Color.FromArgb(40, 40, 55),
                ForeColor = Color.Lime,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Width = 150,
                Left = 100,
                Top = 3
            };
            netPanel.Controls.Add(txtNetWeight);
            netPanel.Controls.Add(netLabel);

            this.Controls.Add(netPanel);
            this.Controls.Add(layout);
        }

        private void AddLabel(TableLayoutPanel panel, int row, int col, string text)
        {
            var lbl = new Label
            {
                Text = text,
                ForeColor = Color.White,
                Font = new Font("微软雅黑", 10),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight
            };
            panel.Controls.Add(lbl, col, row);
        }

        private TextBox AddFieldRow(TableLayoutPanel panel, int row, int col, string labelText, bool required)
        {
            AddLabel(panel, row, col, (required ? "* " : "") + labelText);

            var txt = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("微软雅黑", 10),
                BackColor = Color.FromArgb(50, 50, 65),
                ForeColor = Color.White
            };

            if (required)
            {
                txt.Validating += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                        errorProvider.SetError(txt, labelText + "不能为空");
                    else
                        errorProvider.SetError(txt, "");
                };
            }

            panel.Controls.Add(txt, col + 1, row);
            return txt;
        }

        public void SetWeightValues(double gross, double tare, double net)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetWeightValues(gross, tare, net)));
                return;
            }
            txtGrossWeight.Text = gross.ToString("F2");
            txtTareWeight.Text = tare.ToString("F2");
            txtNetWeight.Text = net.ToString("F2");
        }

        public bool ValidateRequiredFields()
        {
            if (string.IsNullOrWhiteSpace(txtTruckNumber.Text))
            {
                errorProvider.SetError(txtTruckNumber, "车号不能为空");
                return false;
            }
            return true;
        }

        public Dictionary<string, string> GetFieldValues()
        {
            return new Dictionary<string, string>
            {
                { "车号", txtTruckNumber.Text },
                { "货物", txtCargo.Text },
                { "发货单位", txtSender.Text },
                { "收货单位", txtReceiver.Text },
                { "规格", txtSpec.Text },
                { "司机", txtDriver.Text },
                { "业务单号", txtBusinessNo.Text },
                { "货物类型", cmbCargoType.SelectedItem?.ToString() ?? "" }
            };
        }
    }
}
