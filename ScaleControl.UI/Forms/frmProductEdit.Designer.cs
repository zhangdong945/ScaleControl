namespace ScaleControl.UI.Forms
{
    partial class frmProductEdit
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
            this.panelDetails = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblInputCode = new System.Windows.Forms.Label();
            this.txtInputCode = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.chkEnableMaxNetLimit = new System.Windows.Forms.CheckBox();
            this.lblMaxNetLimit = new System.Windows.Forms.Label();
            this.numMaxNetLimit = new System.Windows.Forms.NumericUpDown();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.flowButtons.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxNetLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
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
            this.flowButtons.Size = new System.Drawing.Size(800, 45);
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
            this.lblFilter.Text = "货物过滤：";
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
            this.panelDetails.Controls.Add(this.numMaxNetLimit);
            this.panelDetails.Controls.Add(this.lblMaxNetLimit);
            this.panelDetails.Controls.Add(this.chkEnableMaxNetLimit);
            this.panelDetails.Controls.Add(this.txtRemark);
            this.panelDetails.Controls.Add(this.lblRemark);
            this.panelDetails.Controls.Add(this.txtInputCode);
            this.panelDetails.Controls.Add(this.lblInputCode);
            this.panelDetails.Controls.Add(this.txtCode);
            this.panelDetails.Controls.Add(this.lblCode);
            this.panelDetails.Controls.Add(this.txtProductName);
            this.panelDetails.Controls.Add(this.lblProductName);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 45);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(800, 120);
            this.panelDetails.TabIndex = 1;
            //
            // lblProductName
            //
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(12, 15);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(65, 12);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "货物名称：";
            //
            // txtProductName
            //
            this.txtProductName.Location = new System.Drawing.Point(85, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(150, 21);
            this.txtProductName.TabIndex = 1;
            //
            // lblCode
            //
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(260, 15);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 12);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "编码：";
            //
            // txtCode
            //
            this.txtCode.Location = new System.Drawing.Point(310, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(120, 21);
            this.txtCode.TabIndex = 3;
            //
            // lblInputCode
            //
            this.lblInputCode.AutoSize = true;
            this.lblInputCode.Location = new System.Drawing.Point(460, 15);
            this.lblInputCode.Name = "lblInputCode";
            this.lblInputCode.Size = new System.Drawing.Size(53, 12);
            this.lblInputCode.TabIndex = 4;
            this.lblInputCode.Text = "输入码：";
            //
            // txtInputCode
            //
            this.txtInputCode.Location = new System.Drawing.Point(520, 12);
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.Size = new System.Drawing.Size(100, 21);
            this.txtInputCode.TabIndex = 5;
            //
            // lblRemark
            //
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(12, 50);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 6;
            this.lblRemark.Text = "备注：";
            //
            // txtRemark
            //
            this.txtRemark.Location = new System.Drawing.Point(60, 47);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(200, 21);
            this.txtRemark.TabIndex = 7;
            //
            // chkEnableMaxNetLimit
            //
            this.chkEnableMaxNetLimit.AutoSize = true;
            this.chkEnableMaxNetLimit.Location = new System.Drawing.Point(290, 49);
            this.chkEnableMaxNetLimit.Name = "chkEnableMaxNetLimit";
            this.chkEnableMaxNetLimit.Size = new System.Drawing.Size(120, 16);
            this.chkEnableMaxNetLimit.TabIndex = 8;
            this.chkEnableMaxNetLimit.Text = "启用最大净重限制";
            this.chkEnableMaxNetLimit.UseVisualStyleBackColor = true;
            //
            // lblMaxNetLimit
            //
            this.lblMaxNetLimit.AutoSize = true;
            this.lblMaxNetLimit.Location = new System.Drawing.Point(440, 50);
            this.lblMaxNetLimit.Name = "lblMaxNetLimit";
            this.lblMaxNetLimit.Size = new System.Drawing.Size(89, 12);
            this.lblMaxNetLimit.TabIndex = 9;
            this.lblMaxNetLimit.Text = "最大净重限制：";
            //
            // numMaxNetLimit
            //
            this.numMaxNetLimit.Location = new System.Drawing.Point(535, 47);
            this.numMaxNetLimit.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numMaxNetLimit.Name = "numMaxNetLimit";
            this.numMaxNetLimit.Size = new System.Drawing.Size(100, 21);
            this.numMaxNetLimit.TabIndex = 10;
            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 165);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 23;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(800, 335);
            this.dgvProducts.TabIndex = 2;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            //
            // frmProductEdit
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.flowButtons);
            this.Name = "frmProductEdit";
            this.Load += new System.EventHandler(this.frmProductEdit_Load);
            this.flowButtons.ResumeLayout(false);
            this.flowButtons.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxNetLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
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
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblInputCode;
        private System.Windows.Forms.TextBox txtInputCode;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.CheckBox chkEnableMaxNetLimit;
        private System.Windows.Forms.Label lblMaxNetLimit;
        private System.Windows.Forms.NumericUpDown numMaxNetLimit;
        private System.Windows.Forms.DataGridView dgvProducts;
    }
}
