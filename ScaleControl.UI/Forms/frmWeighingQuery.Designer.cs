namespace ScaleControl.UI.Forms
{
    partial class frmWeighingQuery
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblDataType = new System.Windows.Forms.Label();
            this.cboDataType = new System.Windows.Forms.ComboBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.filterPanel1 = new System.Windows.Forms.Panel();
            this.cboField1 = new System.Windows.Forms.ComboBox();
            this.cboOperator1 = new System.Windows.Forms.ComboBox();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.filterPanel2 = new System.Windows.Forms.Panel();
            this.cboField2 = new System.Windows.Forms.ComboBox();
            this.cboOperator2 = new System.Windows.Forms.ComboBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.filterPanel3 = new System.Windows.Forms.Panel();
            this.cboField3 = new System.Windows.Forms.ComboBox();
            this.cboOperator3 = new System.Windows.Forms.ComboBox();
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.filterPanel4 = new System.Windows.Forms.Panel();
            this.cboField4 = new System.Windows.Forms.ComboBox();
            this.cboOperator4 = new System.Windows.Forms.ComboBox();
            this.txtValue4 = new System.Windows.Forms.TextBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.filterPanel1.SuspendLayout();
            this.filterPanel2.SuspendLayout();
            this.filterPanel3.SuspendLayout();
            this.filterPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.Controls.Add(this.btnReset);
            this.panelTop.Controls.Add(this.btnQuery);
            this.panelTop.Controls.Add(this.dtpEnd);
            this.panelTop.Controls.Add(this.lblEndTime);
            this.panelTop.Controls.Add(this.dtpStart);
            this.panelTop.Controls.Add(this.lblStartTime);
            this.panelTop.Controls.Add(this.cboDataType);
            this.panelTop.Controls.Add(this.lblDataType);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 45);
            this.panelTop.TabIndex = 0;
            //
            // lblDataType
            //
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(12, 15);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(53, 12);
            this.lblDataType.TabIndex = 0;
            this.lblDataType.Text = "数据源：";
            //
            // cboDataType
            //
            this.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataType.FormattingEnabled = true;
            this.cboDataType.Location = new System.Drawing.Point(70, 12);
            this.cboDataType.Name = "cboDataType";
            this.cboDataType.Size = new System.Drawing.Size(100, 20);
            this.cboDataType.TabIndex = 1;
            //
            // lblStartTime
            //
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(185, 15);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(41, 12);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "开始：";
            //
            // dtpStart
            //
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(230, 11);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 21);
            this.dtpStart.TabIndex = 3;
            //
            // lblEndTime
            //
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(385, 15);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(41, 12);
            this.lblEndTime.TabIndex = 4;
            this.lblEndTime.Text = "结束：";
            //
            // dtpEnd
            //
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(430, 11);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(140, 21);
            this.dtpEnd.TabIndex = 5;
            //
            // btnQuery
            //
            this.btnQuery.Location = new System.Drawing.Point(590, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(60, 25);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(660, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 25);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // panelFilters
            //
            this.panelFilters.Controls.Add(this.filterPanel4);
            this.panelFilters.Controls.Add(this.filterPanel3);
            this.panelFilters.Controls.Add(this.filterPanel2);
            this.panelFilters.Controls.Add(this.filterPanel1);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 45);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(900, 70);
            this.panelFilters.TabIndex = 1;
            //
            // filterPanel1
            //
            this.filterPanel1.Controls.Add(this.txtValue1);
            this.filterPanel1.Controls.Add(this.cboOperator1);
            this.filterPanel1.Controls.Add(this.cboField1);
            this.filterPanel1.Location = new System.Drawing.Point(5, 3);
            this.filterPanel1.Name = "filterPanel1";
            this.filterPanel1.Size = new System.Drawing.Size(890, 28);
            this.filterPanel1.TabIndex = 0;
            //
            // cboField1
            //
            this.cboField1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField1.FormattingEnabled = true;
            this.cboField1.Location = new System.Drawing.Point(3, 3);
            this.cboField1.Name = "cboField1";
            this.cboField1.Size = new System.Drawing.Size(120, 20);
            this.cboField1.TabIndex = 0;
            //
            // cboOperator1
            //
            this.cboOperator1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator1.FormattingEnabled = true;
            this.cboOperator1.Location = new System.Drawing.Point(130, 3);
            this.cboOperator1.Name = "cboOperator1";
            this.cboOperator1.Size = new System.Drawing.Size(70, 20);
            this.cboOperator1.TabIndex = 1;
            //
            // txtValue1
            //
            this.txtValue1.Location = new System.Drawing.Point(207, 3);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(150, 21);
            this.txtValue1.TabIndex = 2;
            //
            // filterPanel2
            //
            this.filterPanel2.Controls.Add(this.txtValue2);
            this.filterPanel2.Controls.Add(this.cboOperator2);
            this.filterPanel2.Controls.Add(this.cboField2);
            this.filterPanel2.Location = new System.Drawing.Point(5, 35);
            this.filterPanel2.Name = "filterPanel2";
            this.filterPanel2.Size = new System.Drawing.Size(890, 28);
            this.filterPanel2.TabIndex = 1;
            //
            // cboField2
            //
            this.cboField2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField2.FormattingEnabled = true;
            this.cboField2.Location = new System.Drawing.Point(3, 3);
            this.cboField2.Name = "cboField2";
            this.cboField2.Size = new System.Drawing.Size(120, 20);
            this.cboField2.TabIndex = 0;
            //
            // cboOperator2
            //
            this.cboOperator2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator2.FormattingEnabled = true;
            this.cboOperator2.Location = new System.Drawing.Point(130, 3);
            this.cboOperator2.Name = "cboOperator2";
            this.cboOperator2.Size = new System.Drawing.Size(70, 20);
            this.cboOperator2.TabIndex = 1;
            //
            // txtValue2
            //
            this.txtValue2.Location = new System.Drawing.Point(207, 3);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(150, 21);
            this.txtValue2.TabIndex = 2;
            //
            // filterPanel3
            //
            this.filterPanel3.Controls.Add(this.txtValue3);
            this.filterPanel3.Controls.Add(this.cboOperator3);
            this.filterPanel3.Controls.Add(this.cboField3);
            this.filterPanel3.Location = new System.Drawing.Point(365, 3);
            this.filterPanel3.Name = "filterPanel3";
            this.filterPanel3.Size = new System.Drawing.Size(530, 28);
            this.filterPanel3.TabIndex = 2;
            //
            // cboField3
            //
            this.cboField3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField3.FormattingEnabled = true;
            this.cboField3.Location = new System.Drawing.Point(3, 3);
            this.cboField3.Name = "cboField3";
            this.cboField3.Size = new System.Drawing.Size(120, 20);
            this.cboField3.TabIndex = 0;
            //
            // cboOperator3
            //
            this.cboOperator3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator3.FormattingEnabled = true;
            this.cboOperator3.Location = new System.Drawing.Point(130, 3);
            this.cboOperator3.Name = "cboOperator3";
            this.cboOperator3.Size = new System.Drawing.Size(70, 20);
            this.cboOperator3.TabIndex = 1;
            //
            // txtValue3
            //
            this.txtValue3.Location = new System.Drawing.Point(207, 3);
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.Size = new System.Drawing.Size(150, 21);
            this.txtValue3.TabIndex = 2;
            //
            // filterPanel4
            //
            this.filterPanel4.Controls.Add(this.txtValue4);
            this.filterPanel4.Controls.Add(this.cboOperator4);
            this.filterPanel4.Controls.Add(this.cboField4);
            this.filterPanel4.Location = new System.Drawing.Point(365, 35);
            this.filterPanel4.Name = "filterPanel4";
            this.filterPanel4.Size = new System.Drawing.Size(530, 28);
            this.filterPanel4.TabIndex = 3;
            //
            // cboField4
            //
            this.cboField4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField4.FormattingEnabled = true;
            this.cboField4.Location = new System.Drawing.Point(3, 3);
            this.cboField4.Name = "cboField4";
            this.cboField4.Size = new System.Drawing.Size(120, 20);
            this.cboField4.SelectedIndex = -1;
            this.cboField4.TabIndex = 0;
            //
            // cboOperator4
            //
            this.cboOperator4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator4.FormattingEnabled = true;
            this.cboOperator4.Location = new System.Drawing.Point(130, 3);
            this.cboOperator4.Name = "cboOperator4";
            this.cboOperator4.Size = new System.Drawing.Size(70, 20);
            this.cboOperator4.SelectedIndex = -1;
            this.cboOperator4.TabIndex = 1;
            //
            // txtValue4
            //
            this.txtValue4.Location = new System.Drawing.Point(207, 3);
            this.txtValue4.Name = "txtValue4";
            this.txtValue4.Size = new System.Drawing.Size(150, 21);
            this.txtValue4.TabIndex = 2;
            //
            // dgvResults
            //
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.AutoSizeColumnsMode.DisplayedCells;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 115);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowTemplate.Height = 23;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(900, 390);
            this.dgvResults.TabIndex = 2;
            //
            // panelBottom
            //
            this.panelBottom.Controls.Add(this.lblRecordCount);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnReprint);
            this.panelBottom.Controls.Add(this.btnViewDetail);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(0, 505);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(5);
            this.panelBottom.Size = new System.Drawing.Size(900, 40);
            this.panelBottom.TabIndex = 3;
            //
            // lblRecordCount
            //
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(812, 12);
            this.lblRecordCount.Margin = new System.Windows.Forms.Padding(3, 6, 10, 3);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(71, 12);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "共 0 条记录";
            //
            // btnExport
            //
            this.btnExport.Location = new System.Drawing.Point(746, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 25);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // btnReprint
            //
            this.btnReprint.Location = new System.Drawing.Point(680, 8);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(60, 25);
            this.btnReprint.TabIndex = 2;
            this.btnReprint.Text = "补打磅单";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            //
            // btnViewDetail
            //
            this.btnViewDetail.Location = new System.Drawing.Point(614, 8);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(60, 25);
            this.btnViewDetail.TabIndex = 3;
            this.btnViewDetail.Text = "查看详细";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            //
            // frmWeighingQuery
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 545);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Name = "frmWeighingQuery";
            this.Load += new System.EventHandler(this.frmWeighingQuery_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.filterPanel1.ResumeLayout(false);
            this.filterPanel1.PerformLayout();
            this.filterPanel2.ResumeLayout(false);
            this.filterPanel2.PerformLayout();
            this.filterPanel3.ResumeLayout(false);
            this.filterPanel3.PerformLayout();
            this.filterPanel4.ResumeLayout(false);
            this.filterPanel4.PerformLayout();
            this.panelFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.ComboBox cboDataType;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Panel filterPanel1;
        private System.Windows.Forms.ComboBox cboField1;
        private System.Windows.Forms.ComboBox cboOperator1;
        private System.Windows.Forms.TextBox txtValue1;
        private System.Windows.Forms.Panel filterPanel2;
        private System.Windows.Forms.ComboBox cboField2;
        private System.Windows.Forms.ComboBox cboOperator2;
        private System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.Panel filterPanel3;
        private System.Windows.Forms.ComboBox cboField3;
        private System.Windows.Forms.ComboBox cboOperator3;
        private System.Windows.Forms.TextBox txtValue3;
        private System.Windows.Forms.Panel filterPanel4;
        private System.Windows.Forms.ComboBox cboField4;
        private System.Windows.Forms.ComboBox cboOperator4;
        private System.Windows.Forms.TextBox txtValue4;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnViewDetail;
    }
}
