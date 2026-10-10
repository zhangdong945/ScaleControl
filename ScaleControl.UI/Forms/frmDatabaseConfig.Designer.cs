namespace ScaleControl.UI.Forms
{
    partial class frmDatabaseConfig
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
            this.rbAccess = new System.Windows.Forms.RadioButton();
            this.rbSqlServer = new System.Windows.Forms.RadioButton();
            this.panelAccess = new System.Windows.Forms.Panel();
            this.lblAccessPath = new System.Windows.Forms.Label();
            this.txtAccessPath = new System.Windows.Forms.TextBox();
            this.lblAccessPassword = new System.Windows.Forms.Label();
            this.txtAccessPassword = new System.Windows.Forms.TextBox();
            this.panelSqlServer = new System.Windows.Forms.Panel();
            this.lblSqlPassword = new System.Windows.Forms.Label();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.lblSqlUser = new System.Windows.Forms.Label();
            this.txtSqlUser = new System.Windows.Forms.TextBox();
            this.lblSqlDatabase = new System.Windows.Forms.Label();
            this.txtSqlDatabase = new System.Windows.Forms.TextBox();
            this.lblSqlHost = new System.Windows.Forms.Label();
            this.txtSqlHost = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelAccess.SuspendLayout();
            this.panelSqlServer.SuspendLayout();
            this.SuspendLayout();
            //
            // rbAccess
            //
            this.rbAccess.AutoSize = true;
            this.rbAccess.Checked = true;
            this.rbAccess.Location = new System.Drawing.Point(20, 15);
            this.rbAccess.Name = "rbAccess";
            this.rbAccess.Size = new System.Drawing.Size(83, 16);
            this.rbAccess.TabIndex = 0;
            this.rbAccess.TabStop = true;
            this.rbAccess.Text = "Access数据库";
            this.rbAccess.UseVisualStyleBackColor = true;
            this.rbAccess.CheckedChanged += new System.EventHandler(this.rbAccess_CheckedChanged);
            //
            // rbSqlServer
            //
            this.rbSqlServer.AutoSize = true;
            this.rbSqlServer.Location = new System.Drawing.Point(150, 15);
            this.rbSqlServer.Name = "rbSqlServer";
            this.rbSqlServer.Size = new System.Drawing.Size(95, 16);
            this.rbSqlServer.TabIndex = 1;
            this.rbSqlServer.Text = "SQL Server";
            this.rbSqlServer.UseVisualStyleBackColor = true;
            this.rbSqlServer.CheckedChanged += new System.EventHandler(this.rbSqlServer_CheckedChanged);
            //
            // panelAccess
            //
            this.panelAccess.Controls.Add(this.txtAccessPassword);
            this.panelAccess.Controls.Add(this.lblAccessPassword);
            this.panelAccess.Controls.Add(this.txtAccessPath);
            this.panelAccess.Controls.Add(this.lblAccessPath);
            this.panelAccess.Location = new System.Drawing.Point(12, 45);
            this.panelAccess.Name = "panelAccess";
            this.panelAccess.Size = new System.Drawing.Size(460, 70);
            this.panelAccess.TabIndex = 2;
            //
            // lblAccessPath
            //
            this.lblAccessPath.AutoSize = true;
            this.lblAccessPath.Location = new System.Drawing.Point(10, 10);
            this.lblAccessPath.Name = "lblAccessPath";
            this.lblAccessPath.Size = new System.Drawing.Size(77, 12);
            this.lblAccessPath.TabIndex = 0;
            this.lblAccessPath.Text = "数据库路径：";
            //
            // txtAccessPath
            //
            this.txtAccessPath.Location = new System.Drawing.Point(90, 7);
            this.txtAccessPath.Name = "txtAccessPath";
            this.txtAccessPath.Size = new System.Drawing.Size(350, 21);
            this.txtAccessPath.TabIndex = 1;
            //
            // lblAccessPassword
            //
            this.lblAccessPassword.AutoSize = true;
            this.lblAccessPassword.Location = new System.Drawing.Point(10, 40);
            this.lblAccessPassword.Name = "lblAccessPassword";
            this.lblAccessPassword.Size = new System.Drawing.Size(65, 12);
            this.lblAccessPassword.TabIndex = 2;
            this.lblAccessPassword.Text = "访问密码：";
            //
            // txtAccessPassword
            //
            this.txtAccessPassword.Location = new System.Drawing.Point(90, 37);
            this.txtAccessPassword.Name = "txtAccessPassword";
            this.txtAccessPassword.PasswordChar = '*';
            this.txtAccessPassword.Size = new System.Drawing.Size(200, 21);
            this.txtAccessPassword.TabIndex = 3;
            //
            // panelSqlServer
            //
            this.panelSqlServer.Controls.Add(this.txtSqlPassword);
            this.panelSqlServer.Controls.Add(this.lblSqlPassword);
            this.panelSqlServer.Controls.Add(this.txtSqlUser);
            this.panelSqlServer.Controls.Add(this.lblSqlUser);
            this.panelSqlServer.Controls.Add(this.txtSqlDatabase);
            this.panelSqlServer.Controls.Add(this.lblSqlDatabase);
            this.panelSqlServer.Controls.Add(this.txtSqlHost);
            this.panelSqlServer.Controls.Add(this.lblSqlHost);
            this.panelSqlServer.Enabled = false;
            this.panelSqlServer.Location = new System.Drawing.Point(12, 120);
            this.panelSqlServer.Name = "panelSqlServer";
            this.panelSqlServer.Size = new System.Drawing.Size(460, 110);
            this.panelSqlServer.TabIndex = 3;
            //
            // lblSqlPassword
            //
            this.lblSqlPassword.AutoSize = true;
            this.lblSqlPassword.Location = new System.Drawing.Point(250, 75);
            this.lblSqlPassword.Name = "lblSqlPassword";
            this.lblSqlPassword.Size = new System.Drawing.Size(41, 12);
            this.lblSqlPassword.TabIndex = 6;
            this.lblSqlPassword.Text = "密码：";
            //
            // txtSqlPassword
            //
            this.txtSqlPassword.Location = new System.Drawing.Point(300, 72);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.PasswordChar = '*';
            this.txtSqlPassword.Size = new System.Drawing.Size(140, 21);
            this.txtSqlPassword.TabIndex = 7;
            //
            // lblSqlUser
            //
            this.lblSqlUser.AutoSize = true;
            this.lblSqlUser.Location = new System.Drawing.Point(10, 75);
            this.lblSqlUser.Name = "lblSqlUser";
            this.lblSqlUser.Size = new System.Drawing.Size(41, 12);
            this.lblSqlUser.TabIndex = 4;
            this.lblSqlUser.Text = "用户：";
            //
            // txtSqlUser
            //
            this.txtSqlUser.Location = new System.Drawing.Point(60, 72);
            this.txtSqlUser.Name = "txtSqlUser";
            this.txtSqlUser.Size = new System.Drawing.Size(150, 21);
            this.txtSqlUser.TabIndex = 5;
            //
            // lblSqlDatabase
            //
            this.lblSqlDatabase.AutoSize = true;
            this.lblSqlDatabase.Location = new System.Drawing.Point(250, 10);
            this.lblSqlDatabase.Name = "lblSqlDatabase";
            this.lblSqlDatabase.Size = new System.Drawing.Size(53, 12);
            this.lblSqlDatabase.TabIndex = 2;
            this.lblSqlDatabase.Text = "数据库：";
            //
            // txtSqlDatabase
            //
            this.txtSqlDatabase.Location = new System.Drawing.Point(310, 7);
            this.txtSqlDatabase.Name = "txtSqlDatabase";
            this.txtSqlDatabase.Size = new System.Drawing.Size(130, 21);
            this.txtSqlDatabase.TabIndex = 3;
            //
            // lblSqlHost
            //
            this.lblSqlHost.AutoSize = true;
            this.lblSqlHost.Location = new System.Drawing.Point(10, 10);
            this.lblSqlHost.Name = "lblSqlHost";
            this.lblSqlHost.Size = new System.Drawing.Size(47, 12);
            this.lblSqlHost.TabIndex = 0;
            this.lblSqlHost.Text = "主机：";
            //
            // txtSqlHost
            //
            this.txtSqlHost.Location = new System.Drawing.Point(60, 7);
            this.txtSqlHost.Name = "txtSqlHost";
            this.txtSqlHost.Size = new System.Drawing.Size(150, 21);
            this.txtSqlHost.TabIndex = 1;
            //
            // btnTest
            //
            this.btnTest.Location = new System.Drawing.Point(100, 250);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(80, 30);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(200, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(300, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // frmDatabaseConfig
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.panelSqlServer);
            this.Controls.Add(this.panelAccess);
            this.Controls.Add(this.rbSqlServer);
            this.Controls.Add(this.rbAccess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseConfig";
            this.Load += new System.EventHandler(this.frmDatabaseConfig_Load);
            this.panelAccess.ResumeLayout(false);
            this.panelAccess.PerformLayout();
            this.panelSqlServer.ResumeLayout(false);
            this.panelSqlServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RadioButton rbAccess;
        private System.Windows.Forms.RadioButton rbSqlServer;
        private System.Windows.Forms.Panel panelAccess;
        private System.Windows.Forms.Label lblAccessPath;
        private System.Windows.Forms.TextBox txtAccessPath;
        private System.Windows.Forms.Label lblAccessPassword;
        private System.Windows.Forms.TextBox txtAccessPassword;
        private System.Windows.Forms.Panel panelSqlServer;
        private System.Windows.Forms.Label lblSqlPassword;
        private System.Windows.Forms.TextBox txtSqlPassword;
        private System.Windows.Forms.Label lblSqlUser;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.Label lblSqlDatabase;
        private System.Windows.Forms.TextBox txtSqlDatabase;
        private System.Windows.Forms.Label lblSqlHost;
        private System.Windows.Forms.TextBox txtSqlHost;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
