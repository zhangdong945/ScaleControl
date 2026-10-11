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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.lblAccessPath = new System.Windows.Forms.Label();
            this.txtAccessPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblAccessPassword = new System.Windows.Forms.Label();
            this.txtAccessPassword = new System.Windows.Forms.TextBox();
            this.btnCreateDb = new System.Windows.Forms.Button();
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.lblSqlHost = new System.Windows.Forms.Label();
            this.txtSqlHost = new System.Windows.Forms.TextBox();
            this.lblSqlDatabase = new System.Windows.Forms.Label();
            this.txtSqlDatabase = new System.Windows.Forms.TextBox();
            this.lblSqlUser = new System.Windows.Forms.Label();
            this.txtSqlUser = new System.Windows.Forms.TextBox();
            this.lblSqlPassword = new System.Windows.Forms.Label();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabLocal.SuspendLayout();
            this.tabNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabLocal);
            this.tabControl.Controls.Add(this.tabNetwork);
            this.tabControl.Location = new System.Drawing.Point(24, 24);
            this.tabControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 540);
            this.tabControl.TabIndex = 0;
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.lblAccessPath);
            this.tabLocal.Controls.Add(this.txtAccessPath);
            this.tabLocal.Controls.Add(this.btnBrowse);
            this.tabLocal.Controls.Add(this.lblAccessPassword);
            this.tabLocal.Controls.Add(this.txtAccessPassword);
            this.tabLocal.Controls.Add(this.btnCreateDb);
            this.tabLocal.Location = new System.Drawing.Point(8, 39);
            this.tabLocal.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.tabLocal.Size = new System.Drawing.Size(884, 493);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "本地数据库";
            this.tabLocal.UseVisualStyleBackColor = true;
            // 
            // lblAccessPath
            // 
            this.lblAccessPath.AutoSize = true;
            this.lblAccessPath.Location = new System.Drawing.Point(40, 60);
            this.lblAccessPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAccessPath.Name = "lblAccessPath";
            this.lblAccessPath.Size = new System.Drawing.Size(154, 24);
            this.lblAccessPath.TabIndex = 0;
            this.lblAccessPath.Text = "数据库文件：";
            // 
            // txtAccessPath
            // 
            this.txtAccessPath.Location = new System.Drawing.Point(200, 54);
            this.txtAccessPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAccessPath.Name = "txtAccessPath";
            this.txtAccessPath.Size = new System.Drawing.Size(576, 35);
            this.txtAccessPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(788, 49);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(60, 46);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblAccessPassword
            // 
            this.lblAccessPassword.AutoSize = true;
            this.lblAccessPassword.Location = new System.Drawing.Point(40, 140);
            this.lblAccessPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAccessPassword.Name = "lblAccessPassword";
            this.lblAccessPassword.Size = new System.Drawing.Size(130, 24);
            this.lblAccessPassword.TabIndex = 2;
            this.lblAccessPassword.Text = "访问密码：";
            // 
            // txtAccessPassword
            // 
            this.txtAccessPassword.Location = new System.Drawing.Point(200, 134);
            this.txtAccessPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAccessPassword.Name = "txtAccessPassword";
            this.txtAccessPassword.PasswordChar = '*';
            this.txtAccessPassword.Size = new System.Drawing.Size(396, 35);
            this.txtAccessPassword.TabIndex = 3;
            // 
            // btnCreateDb
            // 
            this.btnCreateDb.Location = new System.Drawing.Point(44, 218);
            this.btnCreateDb.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCreateDb.Name = "btnCreateDb";
            this.btnCreateDb.Size = new System.Drawing.Size(180, 56);
            this.btnCreateDb.TabIndex = 5;
            this.btnCreateDb.Text = "创建数据库";
            this.btnCreateDb.UseVisualStyleBackColor = true;
            this.btnCreateDb.Click += new System.EventHandler(this.btnCreateDb_Click);
            // 
            // tabNetwork
            // 
            this.tabNetwork.Controls.Add(this.lblSqlHost);
            this.tabNetwork.Controls.Add(this.txtSqlHost);
            this.tabNetwork.Controls.Add(this.lblSqlDatabase);
            this.tabNetwork.Controls.Add(this.txtSqlDatabase);
            this.tabNetwork.Controls.Add(this.lblSqlUser);
            this.tabNetwork.Controls.Add(this.txtSqlUser);
            this.tabNetwork.Controls.Add(this.lblSqlPassword);
            this.tabNetwork.Controls.Add(this.txtSqlPassword);
            this.tabNetwork.Controls.Add(this.btnCreateSqlDb);
            this.tabNetwork.Location = new System.Drawing.Point(8, 39);
            this.tabNetwork.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.tabNetwork.Size = new System.Drawing.Size(884, 493);
            this.tabNetwork.TabIndex = 1;
            this.tabNetwork.Text = "网络数据库";
            this.tabNetwork.UseVisualStyleBackColor = true;
            // 
            // lblSqlHost
            // 
            this.lblSqlHost.AutoSize = true;
            this.lblSqlHost.Location = new System.Drawing.Point(40, 60);
            this.lblSqlHost.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSqlHost.Name = "lblSqlHost";
            this.lblSqlHost.Size = new System.Drawing.Size(82, 24);
            this.lblSqlHost.TabIndex = 0;
            this.lblSqlHost.Text = "主机：";
            // 
            // txtSqlHost
            // 
            this.txtSqlHost.Location = new System.Drawing.Point(140, 54);
            this.txtSqlHost.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSqlHost.Name = "txtSqlHost";
            this.txtSqlHost.Size = new System.Drawing.Size(296, 35);
            this.txtSqlHost.TabIndex = 1;
            // 
            // lblSqlDatabase
            // 
            this.lblSqlDatabase.AutoSize = true;
            this.lblSqlDatabase.Location = new System.Drawing.Point(480, 60);
            this.lblSqlDatabase.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSqlDatabase.Name = "lblSqlDatabase";
            this.lblSqlDatabase.Size = new System.Drawing.Size(106, 24);
            this.lblSqlDatabase.TabIndex = 2;
            this.lblSqlDatabase.Text = "数据库：";
            // 
            // txtSqlDatabase
            // 
            this.txtSqlDatabase.Location = new System.Drawing.Point(600, 54);
            this.txtSqlDatabase.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSqlDatabase.Name = "txtSqlDatabase";
            this.txtSqlDatabase.Size = new System.Drawing.Size(236, 35);
            this.txtSqlDatabase.TabIndex = 3;
            // 
            // lblSqlUser
            // 
            this.lblSqlUser.AutoSize = true;
            this.lblSqlUser.Location = new System.Drawing.Point(40, 140);
            this.lblSqlUser.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSqlUser.Name = "lblSqlUser";
            this.lblSqlUser.Size = new System.Drawing.Size(82, 24);
            this.lblSqlUser.TabIndex = 4;
            this.lblSqlUser.Text = "用户：";
            // 
            // txtSqlUser
            // 
            this.txtSqlUser.Location = new System.Drawing.Point(140, 134);
            this.txtSqlUser.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSqlUser.Name = "txtSqlUser";
            this.txtSqlUser.Size = new System.Drawing.Size(296, 35);
            this.txtSqlUser.TabIndex = 5;
            // 
            // lblSqlPassword
            // 
            this.lblSqlPassword.AutoSize = true;
            this.lblSqlPassword.Location = new System.Drawing.Point(480, 140);
            this.lblSqlPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSqlPassword.Name = "lblSqlPassword";
            this.lblSqlPassword.Size = new System.Drawing.Size(82, 24);
            this.lblSqlPassword.TabIndex = 6;
            this.lblSqlPassword.Text = "密码：";
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(600, 134);
            this.txtSqlPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.PasswordChar = '*';
            this.txtSqlPassword.Size = new System.Drawing.Size(236, 35);
            this.txtSqlPassword.TabIndex = 7;
            //
            // btnCreateSqlDb
            //
            this.btnCreateSqlDb.Location = new System.Drawing.Point(44, 218);
            this.btnCreateSqlDb.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCreateSqlDb.Name = "btnCreateSqlDb";
            this.btnCreateSqlDb.Size = new System.Drawing.Size(180, 56);
            this.btnCreateSqlDb.TabIndex = 8;
            this.btnCreateSqlDb.Text = "建立空白数据";
            this.btnCreateSqlDb.UseVisualStyleBackColor = true;
            this.btnCreateSqlDb.Click += new System.EventHandler(this.btnCreateSqlDb_Click);
            //
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(200, 590);
            this.btnTest.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(160, 60);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(400, 590);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 60);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(600, 590);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 60);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDatabaseConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 680);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库配置";
            this.tabControl.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            this.tabNetwork.ResumeLayout(false);
            this.tabNetwork.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabNetwork;
        private System.Windows.Forms.Label lblAccessPath;
        private System.Windows.Forms.TextBox txtAccessPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblAccessPassword;
        private System.Windows.Forms.TextBox txtAccessPassword;
        private System.Windows.Forms.Button btnCreateDb;
        private System.Windows.Forms.Label lblSqlHost;
        private System.Windows.Forms.TextBox txtSqlHost;
        private System.Windows.Forms.Label lblSqlDatabase;
        private System.Windows.Forms.TextBox txtSqlDatabase;
        private System.Windows.Forms.Label lblSqlUser;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.Label lblSqlPassword;
        private System.Windows.Forms.TextBox txtSqlPassword;
        private System.Windows.Forms.Button btnCreateSqlDb;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
