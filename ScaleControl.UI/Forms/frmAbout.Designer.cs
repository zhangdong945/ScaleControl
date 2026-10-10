namespace ScaleControl.UI.Forms
{
    partial class frmAbout
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblProductName
            //
            this.lblProductName.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.lblProductName.Location = new System.Drawing.Point(0, 20);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(350, 40);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "称重管理系统";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblVersion
            //
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblVersion.Location = new System.Drawing.Point(0, 70);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(350, 25);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "版本: 1.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblCopyright
            //
            this.lblCopyright.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblCopyright.Location = new System.Drawing.Point(0, 110);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(350, 25);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright © 2026 ScaleControl";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblDescription
            //
            this.lblDescription.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblDescription.Location = new System.Drawing.Point(0, 145);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(350, 50);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "基于 .NET Framework 4.8 的称重管理MVP系统";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(135, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // frmAbout
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 260);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblProductName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnOK;
    }
}
