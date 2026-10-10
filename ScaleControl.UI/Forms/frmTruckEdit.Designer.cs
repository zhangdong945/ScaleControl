namespace ScaleControl.UI.Forms
{
    partial class frmTruckEdit
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
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblTruckNo = new System.Windows.Forms.Label();
            this.txtTruckNo = new System.Windows.Forms.TextBox();
            this.lblTare = new System.Windows.Forms.Label();
            this.numTare = new System.Windows.Forms.NumericUpDown();
            this.lblTareDate = new System.Windows.Forms.Label();
            this.dtpTareDate = new System.Windows.Forms.DateTimePicker();
            this.lblInputCode = new System.Windows.Forms.Label();
            this.txtInputCode = new System.Windows.Forms.TextBox();
            this.lblEffectDay = new System.Windows.Forms.Label();
            this.numEffectDay = new System.Windows.Forms.NumericUpDown();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblMaxGross = new System.Windows.Forms.Label();
            this.numMaxGross = new System.Windows.Forms.NumericUpDown();
            this.lblMaxNet = new System.Windows.Forms.Label();
            this.numMaxNet = new System.Windows.Forms.NumericUpDown();
            this.dgvTrucks = new System.Windows.Forms.DataGridView();
            this.flowButtons.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEffectDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxNet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrucks)).BeginInit();
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
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowButtons.Location = new System.Drawing.Point(0, 0);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Padding = new System.Windows.Forms.Padding(5);
            this.flowButtons.Size = new System.Drawing.Size(850, 45);
            this.flowButtons.TabIndex = 0;
            //
            // btnNew
            //
            this.btnNew.Location = new System.Drawing.Point(8, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            //
            // btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(89, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 28);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(170, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(251, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(332, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnExport
            //
            this.btnExport.Location = new System.Drawing.Point(413, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 28);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // lblFilter
            //
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(498, 14);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(6, 6, 3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(68, 12);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "车号过滤：";
            //
            // txtFilter
            //
            this.txtFilter.Location = new System.Drawing.Point(572, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(150, 21);
            this.txtFilter.TabIndex = 7;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            //
            // panelDetails
            //
            this.panelDetails.Controls.Add(this.numMaxNet);
            this.panelDetails.Controls.Add(this.lblMaxNet);
            this.panelDetails.Controls.Add(this.numMaxGross);
            this.panelDetails.Controls.Add(this.lblMaxGross);
            this.panelDetails.Controls.Add(this.txtRemark);
            this.panelDetails.Controls.Add(this.lblRemark);
            this.panelDetails.Controls.Add(this.numEffectDay);
            this.panelDetails.Controls.Add(this.lblEffectDay);
            this.panelDetails.Controls.Add(this.txtInputCode);
            this.panelDetails.Controls.Add(this.lblInputCode);
            this.panelDetails.Controls.Add(this.dtpTareDate);
            this.panelDetails.Controls.Add(this.lblTareDate);
            this.panelDetails.Controls.Add(this.numTare);
            this.panelDetails.Controls.Add(this.lblTare);
            this.panelDetails.Controls.Add(this.txtTruckNo);
            this.panelDetails.Controls.Add(this.lblTruckNo);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 45);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(850, 130);
            this.panelDetails.TabIndex = 1;
            //
            // lblTruckNo
            //
            this.lblTruckNo.AutoSize = true;
            this.lblTruckNo.Location = new System.Drawing.Point(12, 15);
            this.lblTruckNo.Name = "lblTruckNo";
            this.lblTruckNo.Size = new System.Drawing.Size(41, 12);
            this.lblTruckNo.TabIndex = 0;
            this.lblTruckNo.Text = "车号：";
            //
            // txtTruckNo
            //
            this.txtTruckNo.Location = new System.Drawing.Point(70, 12);
            this.txtTruckNo.Name = "txtTruckNo";
            this.txtTruckNo.Size = new System.Drawing.Size(120, 21);
            this.txtTruckNo.TabIndex = 1;
            //
            // lblTare
            //
            this.lblTare.AutoSize = true;
            this.lblTare.Location = new System.Drawing.Point(210, 15);
            this.lblTare.Name = "lblTare";
            this.lblTare.Size = new System.Drawing.Size(41, 12);
            this.lblTare.TabIndex = 2;
            this.lblTare.Text = "皮重：";
            //
            // numTare
            //
            this.numTare.Location = new System.Drawing.Point(260, 12);
            this.numTare.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numTare.Name = "numTare";
            this.numTare.Size = new System.Drawing.Size(100, 21);
            this.numTare.TabIndex = 3;
            //
            // lblTareDate
            //
            this.lblTareDate.AutoSize = true;
            this.lblTareDate.Location = new System.Drawing.Point(380, 15);
            this.lblTareDate.Name = "lblTareDate";
            this.lblTareDate.Size = new System.Drawing.Size(65, 12);
            this.lblTareDate.TabIndex = 4;
            this.lblTareDate.Text = "皮重时间：";
            //
            // dtpTareDate
            //
            this.dtpTareDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTareDate.Location = new System.Drawing.Point(450, 12);
            this.dtpTareDate.Name = "dtpTareDate";
            this.dtpTareDate.Size = new System.Drawing.Size(120, 21);
            this.dtpTareDate.TabIndex = 5;
            //
            // lblInputCode
            //
            this.lblInputCode.AutoSize = true;
            this.lblInputCode.Location = new System.Drawing.Point(590, 15);
            this.lblInputCode.Name = "lblInputCode";
            this.lblInputCode.Size = new System.Drawing.Size(53, 12);
            this.lblInputCode.TabIndex = 6;
            this.lblInputCode.Text = "输入码：";
            //
            // txtInputCode
            //
            this.txtInputCode.Location = new System.Drawing.Point(650, 12);
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.Size = new System.Drawing.Size(80, 21);
            this.txtInputCode.TabIndex = 7;
            //
            // lblEffectDay
            //
            this.lblEffectDay.AutoSize = true;
            this.lblEffectDay.Location = new System.Drawing.Point(12, 50);
            this.lblEffectDay.Name = "lblEffectDay";
            this.lblEffectDay.Size = new System.Drawing.Size(65, 12);
            this.lblEffectDay.TabIndex = 8;
            this.lblEffectDay.Text = "有效天数：";
            //
            // numEffectDay
            //
            this.numEffectDay.Location = new System.Drawing.Point(80, 47);
            this.numEffectDay.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            this.numEffectDay.Name = "numEffectDay";
            this.numEffectDay.Size = new System.Drawing.Size(80, 21);
            this.numEffectDay.TabIndex = 9;
            //
            // lblRemark
            //
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(180, 50);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 10;
            this.lblRemark.Text = "备注：";
            //
            // txtRemark
            //
            this.txtRemark.Location = new System.Drawing.Point(230, 47);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(200, 21);
            this.txtRemark.TabIndex = 11;
            //
            // lblMaxGross
            //
            this.lblMaxGross.AutoSize = true;
            this.lblMaxGross.Location = new System.Drawing.Point(450, 50);
            this.lblMaxGross.Name = "lblMaxGross";
            this.lblMaxGross.Size = new System.Drawing.Size(65, 12);
            this.lblMaxGross.TabIndex = 12;
            this.lblMaxGross.Text = "最大毛重：";
            //
            // numMaxGross
            //
            this.numMaxGross.Location = new System.Drawing.Point(520, 47);
            this.numMaxGross.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numMaxGross.Name = "numMaxGross";
            this.numMaxGross.Size = new System.Drawing.Size(100, 21);
            this.numMaxGross.TabIndex = 13;
            //
            // lblMaxNet
            //
            this.lblMaxNet.AutoSize = true;
            this.lblMaxNet.Location = new System.Drawing.Point(12, 85);
            this.lblMaxNet.Name = "lblMaxNet";
            this.lblMaxNet.Size = new System.Drawing.Size(65, 12);
            this.lblMaxNet.TabIndex = 14;
            this.lblMaxNet.Text = "最大净重：";
            //
            // numMaxNet
            //
            this.numMaxNet.Location = new System.Drawing.Point(80, 82);
            this.numMaxNet.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numMaxNet.Name = "numMaxNet";
            this.numMaxNet.Size = new System.Drawing.Size(100, 21);
            this.numMaxNet.TabIndex = 15;
            //
            // dgvTrucks
            //
            this.dgvTrucks.AllowUserToAddRows = false;
            this.dgvTrucks.AllowUserToDeleteRows = false;
            this.dgvTrucks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrucks.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrucks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrucks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrucks.Location = new System.Drawing.Point(0, 175);
            this.dgvTrucks.MultiSelect = false;
            this.dgvTrucks.Name = "dgvTrucks";
            this.dgvTrucks.ReadOnly = true;
            this.dgvTrucks.RowTemplate.Height = 23;
            this.dgvTrucks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrucks.Size = new System.Drawing.Size(850, 325);
            this.dgvTrucks.TabIndex = 2;
            this.dgvTrucks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrucks_CellClick);
            //
            // frmTruckEdit
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.dgvTrucks);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.flowButtons);
            this.Name = "frmTruckEdit";
            this.Load += new System.EventHandler(this.frmTruckEdit_Load);
            this.flowButtons.ResumeLayout(false);
            this.flowButtons.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEffectDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxNet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrucks)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblTruckNo;
        private System.Windows.Forms.TextBox txtTruckNo;
        private System.Windows.Forms.Label lblTare;
        private System.Windows.Forms.NumericUpDown numTare;
        private System.Windows.Forms.Label lblTareDate;
        private System.Windows.Forms.DateTimePicker dtpTareDate;
        private System.Windows.Forms.Label lblInputCode;
        private System.Windows.Forms.TextBox txtInputCode;
        private System.Windows.Forms.Label lblEffectDay;
        private System.Windows.Forms.NumericUpDown numEffectDay;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblMaxGross;
        private System.Windows.Forms.NumericUpDown numMaxGross;
        private System.Windows.Forms.Label lblMaxNet;
        private System.Windows.Forms.NumericUpDown numMaxNet;
        private System.Windows.Forms.DataGridView dgvTrucks;
    }
}
