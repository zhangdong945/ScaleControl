namespace ScaleControl.UI.Forms
{
    partial class frmCustomerEdit
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
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.rbSender = new System.Windows.Forms.RadioButton();
            this.rbReceiver = new System.Windows.Forms.RadioButton();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblInputCode = new System.Windows.Forms.Label();
            this.txtInputCode = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.flowButtons.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            //
            // flowButtons
            //
            this.flowButtons.Controls.Add(this.btnNew);
            this.flowButtons.Controls.Add(this.btnEdit);
            this.flowButtons.Controls.Add(this.btnDelete);
            this.flowButtons.Controls.Add(this.btnSave);
            this.flowButtons.Controls.Add(this.btnCancel);
            this.flowButtons.Controls.Add(this.btnExport);
            this.flowButtons.Controls.Add(this.lblFilter);
            this.flowButtons.Controls.Add(this.txtFilter);
            this.flowButtons.Controls.Add(this.rbSender);
            this.flowButtons.Controls.Add(this.rbReceiver);
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowButtons.Location = new System.Drawing.Point(0, 0);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Padding = new System.Windows.Forms.Padding(5);
            this.flowButtons.Size = new System.Drawing.Size(800, 45);
            this.flowButtons.TabIndex = 0;
            //
            // btnNew
            //
            this.btnNew.Location = new System.Drawing.Point(8, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 28);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            //
            // btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(74, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 28);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(140, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(206, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(272, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnExport
            //
            this.btnExport.Location = new System.Drawing.Point(338, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 28);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // lblFilter
            //
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(408, 14);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(6, 6, 3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(41, 12);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "过滤：";
            //
            // txtFilter
            //
            this.txtFilter.Location = new System.Drawing.Point(455, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(120, 21);
            this.txtFilter.TabIndex = 7;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            //
            // rbSender
            //
            this.rbSender.AutoSize = true;
            this.rbSender.Checked = true;
            this.rbSender.Location = new System.Drawing.Point(581, 11);
            this.rbSender.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.rbSender.Name = "rbSender";
            this.rbSender.Size = new System.Drawing.Size(59, 16);
            this.rbSender.TabIndex = 8;
            this.rbSender.TabStop = true;
            this.rbSender.Text = "发货方";
            this.rbSender.UseVisualStyleBackColor = true;
            this.rbSender.CheckedChanged += new System.EventHandler(this.rbSender_CheckedChanged);
            //
            // rbReceiver
            //
            this.rbReceiver.AutoSize = true;
            this.rbReceiver.Location = new System.Drawing.Point(646, 11);
            this.rbReceiver.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.rbReceiver.Name = "rbReceiver";
            this.rbReceiver.Size = new System.Drawing.Size(59, 16);
            this.rbReceiver.TabIndex = 9;
            this.rbReceiver.Text = "收货方";
            this.rbReceiver.UseVisualStyleBackColor = true;
            this.rbReceiver.CheckedChanged += new System.EventHandler(this.rbReceiver_CheckedChanged);
            //
            // panelDetails
            //
            this.panelDetails.Controls.Add(this.txtRemark);
            this.panelDetails.Controls.Add(this.lblRemark);
            this.panelDetails.Controls.Add(this.txtInputCode);
            this.panelDetails.Controls.Add(this.lblInputCode);
            this.panelDetails.Controls.Add(this.txtName);
            this.panelDetails.Controls.Add(this.lblName);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 45);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(800, 80);
            this.panelDetails.TabIndex = 1;
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "单位名称:";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(70, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 21);
            this.txtName.TabIndex = 1;
            //
            // lblInputCode
            //
            this.lblInputCode.AutoSize = true;
            this.lblInputCode.Location = new System.Drawing.Point(290, 15);
            this.lblInputCode.Name = "lblInputCode";
            this.lblInputCode.Size = new System.Drawing.Size(53, 12);
            this.lblInputCode.TabIndex = 2;
            this.lblInputCode.Text = "输入码：";
            //
            // txtInputCode
            //
            this.txtInputCode.Location = new System.Drawing.Point(350, 12);
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.Size = new System.Drawing.Size(120, 21);
            this.txtInputCode.TabIndex = 3;
            //
            // lblRemark
            //
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(12, 50);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 4;
            this.lblRemark.Text = "备注：";
            //
            // txtRemark
            //
            this.txtRemark.Location = new System.Drawing.Point(60, 47);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(300, 21);
            this.txtRemark.TabIndex = 5;
            //
            // dgvCustomers
            //
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 125);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowTemplate.Height = 23;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(800, 375);
            this.dgvCustomers.TabIndex = 2;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            //
            // frmCustomerEdit
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.flowButtons);
            this.Name = "frmCustomerEdit";
            this.Load += new System.EventHandler(this.frmCustomerEdit_Load);
            this.flowButtons.ResumeLayout(false);
            this.flowButtons.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.RadioButton rbSender;
        private System.Windows.Forms.RadioButton rbReceiver;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblInputCode;
        private System.Windows.Forms.TextBox txtInputCode;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}
