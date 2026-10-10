using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScaleControl.UI.Controls
{
    public class WeightDisplayPanel : UserControl
    {
        private FlowLayoutPanel scaleButtonPanel;
        private Label weightLabel;
        private Label unitLabel;
        private Label connectionStatusLabel;
        private Panel stableIndicator;
        private Label stableLabel;

        public event EventHandler<int> ScaleSelected;

        public double CurrentWeight { get; private set; }
        public bool IsStable { get; private set; }
        public bool IsConnected { get; private set; }

        public WeightDisplayPanel()
        {
            InitializeComponent();
            CurrentWeight = 0;
            IsStable = false;
            IsConnected = false;
            UpdateDisplay();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Top;
            this.Height = 180;
            this.BackColor = Color.FromArgb(30, 30, 40);
            this.Padding = new Padding(10);

            // Scale selection buttons
            scaleButtonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight
            };

            for (int i = 1; i <= 4; i++)
            {
                var btn = new Button
                {
                    Text = "磅" + i,
                    Width = 60,
                    Height = 30,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(60, 60, 80),
                    ForeColor = Color.White,
                    Font = new Font("微软雅黑", 9),
                    Tag = i
                };
                btn.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 120);
                btn.Click += ScaleButton_Click;
                scaleButtonPanel.Controls.Add(btn);
            }

            // Weight display
            weightLabel = new Label
            {
                Text = "0.00",
                Font = new Font("Arial", 36, FontStyle.Bold),
                ForeColor = Color.Lime,
                AutoSize = true,
                Left = 20,
                Top = 55
            };

            // Unit label
            unitLabel = new Label
            {
                Text = "kg",
                Font = new Font("微软雅黑", 14),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 200,
                Top = 75
            };

            // Connection status
            connectionStatusLabel = new Label
            {
                Text = "已断开",
                Font = new Font("微软雅黑", 10),
                ForeColor = Color.Red,
                AutoSize = true,
                Left = 20,
                Top = 110
            };

            // Stable indicator
            stableIndicator = new Panel
            {
                Width = 16,
                Height = 16,
                BackColor = Color.Gray,
                Left = 20,
                Top = 140
            };

            stableLabel = new Label
            {
                Text = "不稳定",
                Font = new Font("微软雅黑", 10),
                ForeColor = Color.Gray,
                AutoSize = true,
                Left = 42,
                Top = 138
            };

            this.Controls.Add(stableLabel);
            this.Controls.Add(stableIndicator);
            this.Controls.Add(connectionStatusLabel);
            this.Controls.Add(unitLabel);
            this.Controls.Add(weightLabel);
            this.Controls.Add(scaleButtonPanel);
        }

        private void ScaleButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            int scaleIndex = (int)btn.Tag;
            foreach (Control c in scaleButtonPanel.Controls)
            {
                if (c is Button)
                    c.BackColor = Color.FromArgb(60, 60, 80);
            }
            btn.BackColor = Color.FromArgb(0, 120, 200);

            ScaleSelected?.Invoke(this, scaleIndex);
        }

        public void SetWeight(double weight)
        {
            CurrentWeight = weight;
            UpdateDisplay();
        }

        public void SetStable(bool stable)
        {
            IsStable = stable;
            UpdateDisplay();
        }

        public void SetConnected(bool connected)
        {
            IsConnected = connected;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateDisplay));
                return;
            }

            weightLabel.Text = CurrentWeight.ToString("F2");

            if (IsConnected)
            {
                connectionStatusLabel.Text = "已连接";
                connectionStatusLabel.ForeColor = Color.Lime;
            }
            else
            {
                connectionStatusLabel.Text = "已断开";
                connectionStatusLabel.ForeColor = Color.Red;
            }

            if (IsStable)
            {
                stableIndicator.BackColor = Color.DodgerBlue;
                stableLabel.Text = "稳定";
                stableLabel.ForeColor = Color.DodgerBlue;
            }
            else
            {
                stableIndicator.BackColor = Color.Gray;
                stableLabel.Text = "不稳定";
                stableLabel.ForeColor = Color.Gray;
            }
        }
    }
}
