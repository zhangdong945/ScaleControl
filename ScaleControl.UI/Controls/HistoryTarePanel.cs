using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScaleControl.UI.Controls
{
    public class HistoryTarePanel : UserControl
    {
        private Label currentTruckLabel;
        private Label avgTareLabel;
        private DataGridView tareGrid;

        public HistoryTarePanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(35, 35, 45);
            this.Padding = new Padding(10);

            // Current truck number
            currentTruckLabel = new Label
            {
                Text = "当前车号: --",
                Font = new Font("微软雅黑", 11),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 10,
                Top = 10
            };

            // Average tare
            avgTareLabel = new Label
            {
                Text = "平均皮重: 0.00 kg",
                Font = new Font("微软雅黑", 11),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 10,
                Top = 35
            };

            // DataGridView for tare records
            tareGrid = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Height = 200,
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

            tareGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 70);
            tareGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tareGrid.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 9, FontStyle.Bold);
            tareGrid.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 55);
            tareGrid.DefaultCellStyle.ForeColor = Color.White;
            tareGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 200);
            tareGrid.GridColor = Color.FromArgb(60, 60, 80);

            tareGrid.Columns.Add("TruckNumber", "车号");
            tareGrid.Columns.Add("TareWeight", "皮重(kg)");
            tareGrid.Columns.Add("WeighDate", "称重日期");

            // Sample data
            tareGrid.Rows.Add("京A12345", "5200.00", "2026-10-09 08:30");
            tareGrid.Rows.Add("京A12345", "5180.00", "2026-10-07 14:20");
            tareGrid.Rows.Add("京A12345", "5220.00", "2026-10-05 09:15");

            this.Controls.Add(tareGrid);
            this.Controls.Add(avgTareLabel);
            this.Controls.Add(currentTruckLabel);
        }

        public void SetCurrentTruck(string truckNumber)
        {
            if (currentTruckLabel.InvokeRequired)
            {
                currentTruckLabel.Invoke(new Action(() => SetCurrentTruck(truckNumber)));
                return;
            }
            currentTruckLabel.Text = "当前车号: " + (string.IsNullOrEmpty(truckNumber) ? "--" : truckNumber);
        }

        public void SetAverageTare(double avgTare)
        {
            if (avgTareLabel.InvokeRequired)
            {
                avgTareLabel.Invoke(new Action(() => SetAverageTare(avgTare)));
                return;
            }
            avgTareLabel.Text = "平均皮重: " + avgTare.ToString("F2") + " kg";
        }

        public void SetTareRecords(System.DataTable data)
        {
            if (tareGrid.InvokeRequired)
            {
                tareGrid.Invoke(new Action(() => SetTareRecords(data)));
                return;
            }

            tareGrid.Rows.Clear();
            if (data == null) return;

            foreach (System.Data.DataRow row in data.Rows)
            {
                tareGrid.Rows.Add(
                    row["TruckNumber"]?.ToString() ?? "",
                    row["TareWeight"]?.ToString() ?? "",
                    row["WeighDate"]?.ToString() ?? ""
                );
            }
        }
    }
}
