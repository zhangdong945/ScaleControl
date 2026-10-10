using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScaleControl.UI.Controls
{
    public class QuickDataBrowsePanel : UserControl
    {
        private TabControl tabControl;
        private DataGridView recordsGrid;
        private FlowLayoutPanel buttonPanel;
        private Panel chartPanel;

        public QuickDataBrowsePanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(35, 35, 45);
            this.Padding = new Padding(5);

            // TabControl
            tabControl = new TabControl
            {
                Dock = DockStyle.Top,
                Height = 28,
                Font = new Font("微软雅黑", 10)
            };
            tabControl.TabPages.Add("交易记录");
            tabControl.TabPages.Add("临时记录");
            tabControl.TabPages.Add("称重曲线");
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            // Button panel
            buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(3)
            };

            AddButton(buttonPanel, "刷新", BtnRefresh_Click);
            AddButton(buttonPanel, "详细", BtnDetail_Click);
            AddButton(buttonPanel, "放大", BtnZoomIn_Click);
            AddButton(buttonPanel, "缩小", BtnZoomOut_Click);
            AddButton(buttonPanel, "自定义字段", BtnCustomField_Click);
            AddButton(buttonPanel, "加载车号", BtnLoadTruck_Click);

            // Records grid
            recordsGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.FromArgb(40, 40, 55),
                ForeColor = Color.White,
                Font = new Font("微软雅黑", 9),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false
            };

            recordsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 70);
            recordsGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            recordsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 9, FontStyle.Bold);
            recordsGrid.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 55);
            recordsGrid.DefaultCellStyle.ForeColor = Color.White;
            recordsGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 200);
            recordsGrid.GridColor = Color.FromArgb(60, 60, 80);

            recordsGrid.Columns.Add("Id", "编号");
            recordsGrid.Columns.Add("TruckNumber", "车号");
            recordsGrid.Columns.Add("GrossWeight", "毛重(kg)");
            recordsGrid.Columns.Add("TareWeight", "皮重(kg)");
            recordsGrid.Columns.Add("NetWeight", "净重(kg)");
            recordsGrid.Columns.Add("WeighDate", "称重日期");

            // Sample data
            recordsGrid.Rows.Add("1001", "京A12345", "25000.00", "5200.00", "19800.00", "2026-10-10 08:30");
            recordsGrid.Rows.Add("1002", "京B67890", "30000.00", "4800.00", "25200.00", "2026-10-10 09:15");
            recordsGrid.Rows.Add("1003", "京C11111", "28000.00", "5500.00", "22500.00", "2026-10-10 10:00");

            // Chart panel (for weight curve tab)
            chartPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 40),
                Visible = false
            };

            var chartLabel = new Label
            {
                Text = "称重曲线 (MVP占位)",
                Font = new Font("微软雅黑", 14),
                ForeColor = Color.Gray,
                AutoSize = true,
                Left = 20,
                Top = 20
            };
            chartPanel.Controls.Add(chartLabel);

            this.Controls.Add(recordsGrid);
            this.Controls.Add(chartPanel);
            this.Controls.Add(buttonPanel);
            this.Controls.Add(tabControl);
        }

        private void AddButton(FlowLayoutPanel panel, string text, EventHandler clickHandler)
        {
            var btn = new Button
            {
                Text = text,
                Width = 80,
                Height = 28,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 60, 80),
                ForeColor = Color.White,
                Font = new Font("微软雅黑", 9),
                Margin = new Padding(3)
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 120);
            btn.Click += clickHandler;
            panel.Controls.Add(btn);
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isChartTab = tabControl.SelectedIndex == 2;
            recordsGrid.Visible = !isChartTab;
            chartPanel.Visible = isChartTab;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: Reload data from database
        }

        private void BtnDetail_Click(object sender, EventArgs e)
        {
            if (recordsGrid.SelectedRows.Count > 0)
            {
                var row = recordsGrid.SelectedRows[0];
                MessageBox.Show(
                    "车号: " + row.Cells["TruckNumber"].Value + Environment.NewLine +
                    "净重: " + row.Cells["NetWeight"].Value + " kg",
                    "详细信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            // TODO: Zoom in chart
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            // TODO: Zoom out chart
        }

        private void BtnCustomField_Click(object sender, EventArgs e)
        {
            // TODO: Show custom field dialog
        }

        private void BtnLoadTruck_Click(object sender, EventArgs e)
        {
            // TODO: Load truck number from history
        }

        public void SetRecords(System.DataTable data)
        {
            if (recordsGrid.InvokeRequired)
            {
                recordsGrid.Invoke(new Action(() => SetRecords(data)));
                return;
            }

            recordsGrid.Rows.Clear();
            if (data == null) return;

            foreach (System.Data.DataRow row in data.Rows)
            {
                recordsGrid.Rows.Add(
                    row["Id"]?.ToString() ?? "",
                    row["TruckNumber"]?.ToString() ?? "",
                    row["GrossWeight"]?.ToString() ?? "",
                    row["TareWeight"]?.ToString() ?? "",
                    row["NetWeight"]?.ToString() ?? "",
                    row["WeighDate"]?.ToString() ?? ""
                );
            }
        }
    }
}
