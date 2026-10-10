using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScaleControl.UI.Controls
{
    public class VideoMonitorPanel : UserControl
    {
        private FlowLayoutPanel layoutButtonPanel;
        private Panel videoContainer;
        private PictureBox[] videoBoxes;
        private CheckBox chkShowVideo;
        private int currentLayout;

        public VideoMonitorPanel()
        {
            currentLayout = 4;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(25, 25, 35);
            this.Padding = new Padding(5);

            // Layout buttons
            layoutButtonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 35,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight
            };

            string[] layouts = { "1格", "2格", "3格", "4格" };
            for (int i = 0; i < layouts.Length; i++)
            {
                var btn = new Button
                {
                    Text = layouts[i],
                    Width = 50,
                    Height = 28,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = (i == 3) ? Color.FromArgb(0, 120, 200) : Color.FromArgb(60, 60, 80),
                    ForeColor = Color.White,
                    Font = new Font("微软雅黑", 9),
                    Tag = i + 1
                };
                btn.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 120);
                btn.Click += LayoutButton_Click;
                layoutButtonPanel.Controls.Add(btn);
            }

            chkShowVideo = new CheckBox
            {
                Text = "显示视频",
                ForeColor = Color.White,
                AutoSize = true,
                Checked = true,
                Left = 230,
                Top = 8
            };
            chkShowVideo.CheckedChanged += (s, e) => ApplyLayout(currentLayout);
            layoutButtonPanel.Controls.Add(chkShowVideo);

            // Video container
            videoContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(20, 20, 30)
            };

            videoBoxes = new PictureBox[4];
            for (int i = 0; i < 4; i++)
            {
                videoBoxes[i] = new PictureBox
                {
                    BackColor = Color.Black,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Visible = false
                };

                var overlayLabel = new Label
                {
                    Text = "摄像头" + (i + 1),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(120, 0, 0, 0),
                    AutoSize = true,
                    Left = 5,
                    Top = 5
                };
                videoBoxes[i].Controls.Add(overlayLabel);
                videoContainer.Controls.Add(videoBoxes[i]);
            }

            this.Controls.Add(videoContainer);
            this.Controls.Add(layoutButtonPanel);

            ApplyLayout(currentLayout);
        }

        private void LayoutButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            int layout = (int)btn.Tag;
            currentLayout = layout;

            foreach (Control c in layoutButtonPanel.Controls)
            {
                if (c is Button && c != chkShowVideo)
                    c.BackColor = Color.FromArgb(60, 60, 80);
            }
            btn.BackColor = Color.FromArgb(0, 120, 200);

            ApplyLayout(layout);
        }

        private void ApplyLayout(int layout)
        {
            int count = chkShowVideo.Checked ? layout : 0;

            for (int i = 0; i < 4; i++)
                videoBoxes[i].Visible = (i < count);

            if (count == 0) return;

            int containerWidth = videoContainer.ClientSize.Width;
            int containerHeight = videoContainer.ClientSize.Height;
            int gap = 2;

            switch (layout)
            {
                case 1:
                    videoBoxes[0].SetBounds(0, 0, containerWidth, containerHeight);
                    break;
                case 2:
                    int halfW2 = (containerWidth - gap) / 2;
                    videoBoxes[0].SetBounds(0, 0, halfW2, containerHeight);
                    videoBoxes[1].SetBounds(halfW2 + gap, 0, containerWidth - halfW2 - gap, containerHeight);
                    break;
                case 3:
                    int thirdW = (containerWidth - 2 * gap) / 3;
                    videoBoxes[0].SetBounds(0, 0, thirdW, containerHeight);
                    videoBoxes[1].SetBounds(thirdW + gap, 0, thirdW, containerHeight);
                    videoBoxes[2].SetBounds(2 * (thirdW + gap), 0, containerWidth - 2 * (thirdW + gap), containerHeight);
                    break;
                case 4:
                    int halfW = (containerWidth - gap) / 2;
                    int halfH = (containerHeight - gap) / 2;
                    videoBoxes[0].SetBounds(0, 0, halfW, halfH);
                    videoBoxes[1].SetBounds(halfW + gap, 0, containerWidth - halfW - gap, halfH);
                    videoBoxes[2].SetBounds(0, halfH + gap, halfW, containerHeight - halfH - gap);
                    videoBoxes[3].SetBounds(halfW + gap, halfH + gap, containerWidth - halfW - gap, containerHeight - halfH - gap);
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (videoContainer != null)
                ApplyLayout(currentLayout);
        }
    }
}
