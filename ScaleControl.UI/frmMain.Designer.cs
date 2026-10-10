namespace ScaleControl.UI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.btnSwitchUser = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.menuBar = new ScaleControl.UI.Controls.MenuBarControl();
            this.rightTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.centerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.bottomTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.topBar.SuspendLayout();
            this.mainTableLayout.SuspendLayout();
            this.rightTableLayout.SuspendLayout();
            this.centerTableLayout.SuspendLayout();
            this.bottomTableLayout.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            //
            // topBar
            //
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.topBar.Controls.Add(this.btnPrint);
            this.topBar.Controls.Add(this.btnSave);
            this.topBar.Controls.Add(this.btnRead);
            this.topBar.Controls.Add(this.btnContinue);
            this.topBar.Controls.Add(this.btnExit);
            this.topBar.Controls.Add(this.btnSwitchUser);
            this.topBar.Controls.Add(this.lblShift);
            this.topBar.Controls.Add(this.lblUser);
            this.topBar.Controls.Add(this.lblTitle);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1280, 50);
            this.topBar.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "称重管理系统 V1.0";
            //
            // lblUser
            //
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.LightGray;
            this.lblUser.Location = new System.Drawing.Point(220, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(79, 20);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "用户: 未登录";
            //
            // lblShift
            //
            this.lblShift.AutoSize = true;
            this.lblShift.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblShift.ForeColor = System.Drawing.Color.LightGray;
            this.lblShift.Location = new System.Drawing.Point(380, 16);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(54, 20);
            this.lblShift.TabIndex = 2;
            this.lblShift.Text = "班次: --";
            //
            // btnSwitchUser
            //
            this.btnSwitchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchUser.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSwitchUser.ForeColor = System.Drawing.Color.White;
            this.btnSwitchUser.Location = new System.Drawing.Point(500, 10);
            this.btnSwitchUser.Name = "btnSwitchUser";
            this.btnSwitchUser.Size = new System.Drawing.Size(60, 30);
            this.btnSwitchUser.TabIndex = 3;
            this.btnSwitchUser.Text = "切换";
            this.btnSwitchUser.UseVisualStyleBackColor = true;
            //
            // btnExit
            //
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(570, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            //
            // btnContinue
            //
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(680, 8);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(60, 32);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "继续";
            this.btnContinue.UseVisualStyleBackColor = false;
            //
            // btnRead
            //
            this.btnRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnRead.ForeColor = System.Drawing.Color.White;
            this.btnRead.Location = new System.Drawing.Point(750, 8);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(60, 32);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "读数";
            this.btnRead.UseVisualStyleBackColor = false;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(820, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            //
            // btnPrint
            //
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(890, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 32);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            //
            // mainTableLayout
            //
            this.mainTableLayout.ColumnCount = 3;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.mainTableLayout.Controls.Add(this.menuBar, 0, 0);
            this.mainTableLayout.Controls.Add(this.rightTableLayout, 2, 0);
            this.mainTableLayout.Controls.Add(this.centerTableLayout, 1, 0);
            this.mainTableLayout.Controls.Add(this.bottomTableLayout, 1, 1);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 50);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 2;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainTableLayout.Size = new System.Drawing.Size(1280, 630);
            this.mainTableLayout.TabIndex = 1;
            //
            // menuBar
            //
            this.menuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.menuBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Margin = new System.Windows.Forms.Padding(0);
            this.menuBar.Name = "menuBar";
            this.mainTableLayout.SetRowSpan(this.menuBar, 2);
            this.menuBar.Size = new System.Drawing.Size(200, 630);
            this.menuBar.TabIndex = 0;
            //
            // rightTableLayout
            //
            this.rightTableLayout.ColumnCount = 1;
            this.rightTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTableLayout.Location = new System.Drawing.Point(1060, 0);
            this.rightTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.rightTableLayout.Name = "rightTableLayout";
            this.rightTableLayout.RowCount = 1;
            this.rightTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTableLayout.Size = new System.Drawing.Size(220, 409);
            this.rightTableLayout.TabIndex = 1;
            //
            // centerTableLayout
            //
            this.centerTableLayout.ColumnCount = 2;
            this.centerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.centerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centerTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerTableLayout.Location = new System.Drawing.Point(200, 0);
            this.centerTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.centerTableLayout.Name = "centerTableLayout";
            this.centerTableLayout.RowCount = 2;
            this.centerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.centerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centerTableLayout.Size = new System.Drawing.Size(860, 409);
            this.centerTableLayout.TabIndex = 2;
            //
            // bottomTableLayout
            //
            this.bottomTableLayout.ColumnCount = 2;
            this.bottomTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottomTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottomTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomTableLayout.Location = new System.Drawing.Point(200, 412);
            this.bottomTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.bottomTableLayout.Name = "bottomTableLayout";
            this.bottomTableLayout.RowCount = 1;
            this.bottomTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomTableLayout.Size = new System.Drawing.Size(860, 218);
            this.bottomTableLayout.TabIndex = 3;
            //
            // statusBar
            //
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 680);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1280, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            //
            // statusLabel
            //
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(96, 17);
            this.statusLabel.Text = "系统就绪 | 秤已断开";
            //
            // frmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1280, 702);
            this.Controls.Add(this.mainTableLayout);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.statusBar);
            this.MinimumSize = new System.Drawing.Size(1024, 700);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "称重管理系统";
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.mainTableLayout.ResumeLayout(false);
            this.rightTableLayout.ResumeLayout(false);
            this.centerTableLayout.ResumeLayout(false);
            this.bottomTableLayout.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Button btnSwitchUser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private ScaleControl.UI.Controls.MenuBarControl menuBar;
        private System.Windows.Forms.TableLayoutPanel rightTableLayout;
        private System.Windows.Forms.TableLayoutPanel centerTableLayout;
        private System.Windows.Forms.TableLayoutPanel bottomTableLayout;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}
