namespace ScaleControl.UI.Forms
{
    partial class frmScaleConfig
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
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.rbSerial = new System.Windows.Forms.RadioButton();
            this.rbNetwork = new System.Windows.Forms.RadioButton();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.lblPortName = new System.Windows.Forms.Label();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.numBaudRate = new System.Windows.Forms.NumericUpDown();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.numDataBits = new System.Windows.Forms.NumericUpDown();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.panelNetwork = new System.Windows.Forms.Panel();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblStableTime = new System.Windows.Forms.Label();
            this.numStableTime = new System.Windows.Forms.NumericUpDown();
            this.lblStableChange = new System.Windows.Forms.Label();
            this.numStableChange = new System.Windows.Forms.NumericUpDown();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.numMinWeight = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelSerial.SuspendLayout();
            this.panelNetwork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaudRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDataBits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStableTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStableChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinWeight)).BeginInit();
            this.SuspendLayout();
            //
            // lblDeviceName
            //
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(20, 15);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(65, 12);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "设备名称：";
            //
            // txtDeviceName
            //
            this.txtDeviceName.Location = new System.Drawing.Point(90, 12);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(150, 21);
            this.txtDeviceName.TabIndex = 1;
            //
            // rbSerial
            //
            this.rbSerial.AutoSize = true;
            this.rbSerial.Checked = true;
            this.rbSerial.Location = new System.Drawing.Point(20, 50);
            this.rbSerial.Name = "rbSerial";
            this.rbSerial.Size = new System.Drawing.Size(71, 16);
            this.rbSerial.TabIndex = 2;
            this.rbSerial.TabStop = true;
            this.rbSerial.Text = "串口连接";
            this.rbSerial.UseVisualStyleBackColor = true;
            this.rbSerial.CheckedChanged += new System.EventHandler(this.rbSerial_CheckedChanged);
            //
            // rbNetwork
            //
            this.rbNetwork.AutoSize = true;
            this.rbNetwork.Location = new System.Drawing.Point(150, 50);
            this.rbNetwork.Name = "rbNetwork";
            this.rbNetwork.Size = new System.Drawing.Size(71, 16);
            this.rbNetwork.TabIndex = 3;
            this.rbNetwork.Text = "网络连接";
            this.rbNetwork.UseVisualStyleBackColor = true;
            this.rbNetwork.CheckedChanged += new System.EventHandler(this.rbNetwork_CheckedChanged);
            //
            // panelSerial
            //
            this.panelSerial.Controls.Add(this.cmbParity);
            this.panelSerial.Controls.Add(this.lblParity);
            this.panelSerial.Controls.Add(this.cmbStopBits);
            this.panelSerial.Controls.Add(this.lblStopBits);
            this.panelSerial.Controls.Add(this.numDataBits);
            this.panelSerial.Controls.Add(this.lblDataBits);
            this.panelSerial.Controls.Add(this.numBaudRate);
            this.panelSerial.Controls.Add(this.lblBaudRate);
            this.panelSerial.Controls.Add(this.txtPortName);
            this.panelSerial.Controls.Add(this.lblPortName);
            this.panelSerial.Location = new System.Drawing.Point(12, 75);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(460, 80);
            this.panelSerial.TabIndex = 4;
            //
            // lblPortName
            //
            this.lblPortName.AutoSize = true;
            this.lblPortName.Location = new System.Drawing.Point(10, 10);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(41, 12);
            this.lblPortName.TabIndex = 0;
            this.lblPortName.Text = "端口：";
            //
            // txtPortName
            //
            this.txtPortName.Location = new System.Drawing.Point(60, 7);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(80, 21);
            this.txtPortName.TabIndex = 1;
            //
            // lblBaudRate
            //
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(160, 10);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(53, 12);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "波特率：";
            //
            // numBaudRate
            //
            this.numBaudRate.Location = new System.Drawing.Point(220, 7);
            this.numBaudRate.Maximum = new decimal(new int[] { 115200, 0, 0, 0 });
            this.numBaudRate.Name = "numBaudRate";
            this.numBaudRate.Size = new System.Drawing.Size(80, 21);
            this.numBaudRate.TabIndex = 3;
            this.numBaudRate.Value = new decimal(new int[] { 9600, 0, 0, 0 });
            //
            // lblDataBits
            //
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(320, 10);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(53, 12);
            this.lblDataBits.TabIndex = 4;
            this.lblDataBits.Text = "数据位：";
            //
            // numDataBits
            //
            this.numDataBits.Location = new System.Drawing.Point(380, 7);
            this.numDataBits.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            this.numDataBits.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numDataBits.Name = "numDataBits";
            this.numDataBits.Size = new System.Drawing.Size(50, 21);
            this.numDataBits.TabIndex = 5;
            this.numDataBits.Value = new decimal(new int[] { 8, 0, 0, 0 });
            //
            // lblStopBits
            //
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(10, 45);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(53, 12);
            this.lblStopBits.TabIndex = 6;
            this.lblStopBits.Text = "停止位：";
            //
            // cmbStopBits
            //
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cmbStopBits.Location = new System.Drawing.Point(70, 42);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(70, 20);
            this.cmbStopBits.TabIndex = 7;
            //
            // lblParity
            //
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(160, 45);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(53, 12);
            this.lblParity.TabIndex = 8;
            this.lblParity.Text = "校验位：";
            //
            // cmbParity
            //
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cmbParity.Location = new System.Drawing.Point(220, 42);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(80, 20);
            this.cmbParity.TabIndex = 9;
            //
            // panelNetwork
            //
            this.panelNetwork.Controls.Add(this.numPort);
            this.panelNetwork.Controls.Add(this.lblPort);
            this.panelNetwork.Controls.Add(this.txtIpAddress);
            this.panelNetwork.Controls.Add(this.lblIpAddress);
            this.panelNetwork.Enabled = false;
            this.panelNetwork.Location = new System.Drawing.Point(12, 160);
            this.panelNetwork.Name = "panelNetwork";
            this.panelNetwork.Size = new System.Drawing.Size(460, 40);
            this.panelNetwork.TabIndex = 5;
            //
            // lblIpAddress
            //
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Location = new System.Drawing.Point(10, 12);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(50, 12);
            this.lblIpAddress.TabIndex = 0;
            this.lblIpAddress.Text = "IP地址：";
            //
            // txtIpAddress
            //
            this.txtIpAddress.Location = new System.Drawing.Point(70, 9);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(150, 21);
            this.txtIpAddress.TabIndex = 1;
            //
            // lblPort
            //
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(240, 12);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 12);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "端口：";
            //
            // numPort
            //
            this.numPort.Location = new System.Drawing.Point(290, 9);
            this.numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(80, 21);
            this.numPort.TabIndex = 3;
            this.numPort.Value = new decimal(new int[] { 8000, 0, 0, 0 });
            //
            // lblStableTime
            //
            this.lblStableTime.AutoSize = true;
            this.lblStableTime.Location = new System.Drawing.Point(20, 215);
            this.lblStableTime.Name = "lblStableTime";
            this.lblStableTime.Size = new System.Drawing.Size(89, 12);
            this.lblStableTime.TabIndex = 6;
            this.lblStableTime.Text = "稳态判断时间(秒):";
            //
            // numStableTime
            //
            this.numStableTime.Location = new System.Drawing.Point(115, 212);
            this.numStableTime.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numStableTime.Name = "numStableTime";
            this.numStableTime.Size = new System.Drawing.Size(60, 21);
            this.numStableTime.TabIndex = 7;
            this.numStableTime.Value = new decimal(new int[] { 3, 0, 0, 0 });
            //
            // lblStableChange
            //
            this.lblStableChange.AutoSize = true;
            this.lblStableChange.Location = new System.Drawing.Point(200, 215);
            this.lblStableChange.Name = "lblStableChange";
            this.lblStableChange.Size = new System.Drawing.Size(101, 12);
            this.lblStableChange.TabIndex = 8;
            this.lblStableChange.Text = "稳态允许变化(kg):";
            //
            // numStableChange
            //
            this.numStableChange.Location = new System.Drawing.Point(310, 212);
            this.numStableChange.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numStableChange.Name = "numStableChange";
            this.numStableChange.Size = new System.Drawing.Size(60, 21);
            this.numStableChange.TabIndex = 9;
            this.numStableChange.Value = new decimal(new int[] { 20, 0, 0, 0 });
            //
            // lblMinWeight
            //
            this.lblMinWeight.AutoSize = true;
            this.lblMinWeight.Location = new System.Drawing.Point(20, 250);
            this.lblMinWeight.Name = "lblMinWeight";
            this.lblMinWeight.Size = new System.Drawing.Size(89, 12);
            this.lblMinWeight.TabIndex = 10;
            this.lblMinWeight.Text = "最小重量(kg):";
            //
            // numMinWeight
            //
            this.numMinWeight.Location = new System.Drawing.Point(115, 247);
            this.numMinWeight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numMinWeight.Name = "numMinWeight";
            this.numMinWeight.Size = new System.Drawing.Size(80, 21);
            this.numMinWeight.TabIndex = 11;
            this.numMinWeight.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(130, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(250, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // frmScaleConfig
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 340);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numMinWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.numStableChange);
            this.Controls.Add(this.lblStableChange);
            this.Controls.Add(this.numStableTime);
            this.Controls.Add(this.lblStableTime);
            this.Controls.Add(this.panelNetwork);
            this.Controls.Add(this.panelSerial);
            this.Controls.Add(this.rbNetwork);
            this.Controls.Add(this.rbSerial);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.lblDeviceName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScaleConfig";
            this.Load += new System.EventHandler(this.frmScaleConfig_Load);
            this.panelSerial.ResumeLayout(false);
            this.panelSerial.PerformLayout();
            this.panelNetwork.ResumeLayout(false);
            this.panelNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaudRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDataBits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStableTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStableChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.RadioButton rbSerial;
        private System.Windows.Forms.RadioButton rbNetwork;
        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.TextBox txtPortName;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.NumericUpDown numBaudRate;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.NumericUpDown numDataBits;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Panel panelNetwork;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblStableTime;
        private System.Windows.Forms.NumericUpDown numStableTime;
        private System.Windows.Forms.Label lblStableChange;
        private System.Windows.Forms.NumericUpDown numStableChange;
        private System.Windows.Forms.Label lblMinWeight;
        private System.Windows.Forms.NumericUpDown numMinWeight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
