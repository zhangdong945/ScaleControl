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
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.lblAccessPath = new System.Windows.Forms.Label();
            this.txtAccessPath = new System.Windows.Forms.TextBox();
            this.lblAccessPassword = new System.Windows.Forms.Label();
            this.txtAccessPassword = new System.Windows.Forms.TextBox();
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
            this.tabLocal.SuspendLayout();
            this.tabNetwork.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabLocal);
            this.tabControl.Controls.Add(this.tabNetwork);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(450, 270);
            this.tabControl.TabIndex = 0;
            //
            // tabLocal
            //
            this.tabLocal.Controls.Add(this.lblAccessPath);
            this.tabLocal.Controls.Add(this.txtAccessPath);
            this.tabLocal.Controls.Add(this.lblAccessPassword);
            this.tabLocal.Controls.Add(this.txtAccessPassword);
            this.tabLocal.Location = new System.Drawing.Point(4, 22);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(10);
            this.tabLocal.Size = new System.Drawing.Size(442, 244);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "本地数据库";
            this.tabLocal.UseVisualStyleBackColor = true;
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
            this.tabNetwork.Location = new System.Drawing.Point(4, 22);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Padding = new System.Windows.Forms.Padding(10);
            this.tabNetwork.Size = new System.Drawing.Size(442, 244);
            this.tabNetwork.TabIndex = 1;
            this.tabNetwork.Text = "网络数据库";
            this.tabNetwork.UseVisualStyleBackColor = true;
            //
            // lblAccessPath
            //
            this.lblAccessPath.AutoSize = true;
            this.lblAccessPath.Location = new System.Drawing.Point(20, 30);
            this.lblAccessPath.Name = "lblAccessPath";
            this.lblAccessPath.Size = new System.Drawing.Size(77, 12);
            this.lblAccessPath.TabIndex = 0;
            this.lblAccessPath.Text = "数据库路径：";
            //
            // txtAccessPath
            //
            this.txtAccessPath.Location = new System.Drawing.Point(100, 27);
            this.txtAccessPath.Name = "txtAccessPath";
            this.txtAccessPath.Size = new System.Drawing.Size(320, 21);
            this.txtAccessPath.TabIndex = 1;
            //
            // lblAccessPassword
            //
            this.lblAccessPassword.AutoSize = true;
            this.lblAccessPassword.Location = new System.Drawing.Point(20, 70);
            this.lblAccessPassword.Name = "lblAccessPassword";
            this.lblAccessPassword.Size = new System.Drawing.Size(65, 12);
            this.lblAccessPassword.TabIndex = 2;
            this.lblAccessPassword.Text = "访问密码：";
            //
            // txtAccessPassword
            //
            this.txtAccessPassword.Location = new System.Drawing.Point(100, 67);
            this.txtAccessPassword.Name = "txtAccessPassword";
            this.txtAccessPassword.PasswordChar = '*';
            this.txtAccessPassword.Size = new System.Drawing.Size(200, 21);
            this.txtAccessPassword.TabIndex = 3;
            //
            // lblSqlHost
            //
            this.lblSqlHost.AutoSize = true;
            this.lblSqlHost.Location = new System.Drawing.Point(20, 30);
            this.lblSqlHost.Name = "lblSqlHost";
            this.lblSqlHost.Size = new System.Drawing.Size(47, 12);
            this.lblSqlHost.TabIndex = 0;
            this.lblSqlHost.Text = "主机：";
            //
            // txtSqlHost
            //
            this.txtSqlHost.Location = new System.Drawing.Point(70, 27);
            this.txtSqlHost.Name = "txtSqlHost";
            this.txtSqlHost.Size = new System.Drawing.Size(150, 21);
            this.txtSqlHost.TabIndex = 1;
            //
            // lblSqlDatabase
            //
            this.lblSqlDatabase.AutoSize = true;
            this.lblSqlDatabase.Location = new System.Drawing.Point(240, 30);
            this.lblSqlDatabase.Name = "lblSqlDatabase";
            this.lblSqlDatabase.Size = new System.Drawing.Size(53, 12);
            this.lblSqlDatabase.TabIndex = 2;
            this.lblSqlDatabase.Text = "数据库：";
            //
            // txtSqlDatabase
            //
            this.txtSqlDatabase.Location = new System.Drawing.Point(300, 27);
            this.txtSqlDatabase.Name = "txtSqlDatabase";
            this.txtSqlDatabase.Size = new System.Drawing.Size(120, 21);
            this.txtSqlDatabase.TabIndex = 3;
            //
            // lblSqlUser
            //
            this.lblSqlUser.AutoSize = true;
            this.lblSqlUser.Location = new System.Drawing.Point(20, 70);
            this.lblSqlUser.Name = "lblSqlUser";
            this.lblSqlUser.Size = new System.Drawing.Size(41, 12);
            this.lblSqlUser.TabIndex = 4;
            this.lblSqlUser.Text = "用户：";
            //
            // txtSqlUser
            //
            this.txtSqlUser.Location = new System.Drawing.Point(70, 67);
            this.txtSqlUser.Name = "txtSqlUser";
            this.txtSqlUser.Size = new System.Drawing.Size(150, 21);
            this.txtSqlUser.TabIndex = 5;
            //
            // lblSqlPassword
            //
            this.lblSqlPassword.AutoSize = true;
            this.lblSqlPassword.Location = new System.Drawing.Point(240, 70);
            this.lblSqlPassword.Name = "lblSqlPassword";
            this.lblSqlPassword.Size = new System.Drawing.Size(41, 12);
            this.lblSqlPassword.TabIndex = 6;
            this.lblSqlPassword.Text = "密码：";
            //
            // txtSqlPassword
            //
            this.txtSqlPassword.Location = new System.Drawing.Point(300, 67);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.PasswordChar = '*';
            this.txtSqlPassword.Size = new System.Drawing.Size(120, 21);
            this.txtSqlPassword.TabIndex = 7;
            //
            // btnTest
            //
            this.btnTest.Location = new System.Drawing.Point(100, 295);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(80, 30);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(200, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(300, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // frmDatabaseConfig
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 340);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库配置";
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            this.tabNetwork.ResumeLayout(false);
            this.tabNetwork.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabNetwork;
        private System.Windows.Forms.Label lblAccessPath;
        private System.Windows.Forms.TextBox txtAccessPath;
        private System.Windows.Forms.Label lblAccessPassword;
        private System.Windows.Forms.TextBox txtAccessPassword;
        private System.Windows.Forms.Label lblSqlHost;
        private System.Windows.Forms.TextBox txtSqlHost;
        private System.Windows.Forms.Label lblSqlDatabase;
        private System.Windows.Forms.TextBox txtSqlDatabase;
        private System.Windows.Forms.Label lblSqlUser;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.Label lblSqlPassword;
        private System.Windows.Forms.TextBox txtSqlPassword;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
