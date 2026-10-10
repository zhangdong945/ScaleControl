using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScaleControl.UI.Controls
{
    public class EquipmentStatusPanel : UserControl
    {
        private Panel scalePlatformPanel;
        private FlowLayoutPanel peripheralPanel;
        private Label flowStatusLabel;
        private Label recognitionLabel;

        public EquipmentStatusPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(35, 35, 45);
            this.Padding = new Padding(10);

            // Scale platform visualization
            scalePlatformPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(45, 45, 60),
                BorderStyle = BorderStyle.FixedSingle
            };

            var platformLabel = new Label
            {
                Text = "秤台",
                Font = new Font("微软雅黑", 12),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 10,
                Top = 10
            };
            scalePlatformPanel.Controls.Add(platformLabel);

            // Peripheral status panel
            peripheralPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(5)
            };

            AddPeripheralStatus("北红绿灯", Color.Red);
            AddPeripheralStatus("南红绿灯", Color.Green);
            AddPeripheralStatus("北道闸", Color.Green);
            AddPeripheralStatus("南道闸", Color.Gray);
            AddPeripheralStatus("北地感", Color.Green);
            AddPeripheralStatus("南地感", Color.Green);
            AddPeripheralStatus("读卡器", Color.Green);

            // Flow status
            flowStatusLabel = new Label
            {
                Text = "流程状态: 等待车辆",
                Font = new Font("微软雅黑", 11),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 10,
                Top = 210
            };

            // Recognition result
            recognitionLabel = new Label
            {
                Text = "识别结果: --",
                Font = new Font("微软雅黑", 11),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 10,
                Top = 240
            };

            this.Controls.Add(recognitionLabel);
            this.Controls.Add(flowStatusLabel);
            this.Controls.Add(peripheralPanel);
            this.Controls.Add(scalePlatformPanel);
        }

        private void AddPeripheralStatus(string name, Color statusColor)
        {
            var panel = new Panel
            {
                Width = 90,
                Height = 35,
                Margin = new Padding(3),
                BackColor = Color.FromArgb(50, 50, 65)
            };

            var indicator = new Panel
            {
                Width = 12,
                Height = 12,
                BackColor = statusColor,
                Left = 5,
                Top = 11
            };

            var lbl = new Label
            {
                Text = name,
                Font = new Font("微软雅黑", 8),
                ForeColor = Color.White,
                AutoSize = true,
                Left = 22,
                Top = 9
            };

            panel.Controls.Add(lbl);
            panel.Controls.Add(indicator);
            peripheralPanel.Controls.Add(panel);
        }

        public void SetFlowStatus(string status)
        {
            if (flowStatusLabel.InvokeRequired)
            {
                flowStatusLabel.Invoke(new Action(() => SetFlowStatus(status)));
                return;
            }
            flowStatusLabel.Text = "流程状态: " + status;
        }

        public void SetRecognitionResult(string result)
        {
            if (recognitionLabel.InvokeRequired)
            {
                recognitionLabel.Invoke(new Action(() => SetRecognitionResult(result)));
                return;
            }
            recognitionLabel.Text = "识别结果: " + result;
        }
    }
}
