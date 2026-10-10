namespace ScaleControl.UI.Forms
{
    partial class frmDetailRecord
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.flowBasic = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRow1 = new System.Windows.Forms.Panel();
            this.lblTicketNo1 = new System.Windows.Forms.Label();
            this.txtTicketNo1 = new System.Windows.Forms.TextBox();
            this.lblTicketNo2 = new System.Windows.Forms.Label();
            this.txtTicketNo2 = new System.Windows.Forms.TextBox();
            this.lblTruckNo = new System.Windows.Forms.Label();
            this.txtTruckNo = new System.Windows.Forms.TextBox();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.panelRow2 = new System.Windows.Forms.Panel();
            this.lblContractNo = new System.Windows.Forms.Label();
            this.txtContractNo = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblSpecification = new System.Windows.Forms.Label();
            this.txtSpecification = new System.Windows.Forms.TextBox();
            this.panelRow3 = new System.Windows.Forms.Panel();
            this.lblSender = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.lblTransporter = new System.Windows.Forms.Label();
            this.txtTransporter = new System.Windows.Forms.TextBox();
            this.panelRow4 = new System.Windows.Forms.Panel();
            this.lblFirstDateTime = new System.Windows.Forms.Label();
            this.txtFirstDateTime = new System.Windows.Forms.TextBox();
            this.lblSecondDateTime = new System.Windows.Forms.Label();
            this.txtSecondDateTime = new System.Windows.Forms.TextBox();
            this.lblGrossDateTime = new System.Windows.Forms.Label();
            this.txtGrossDateTime = new System.Windows.Forms.TextBox();
            this.lblTareDateTime = new System.Windows.Forms.Label();
            this.txtTareDateTime = new System.Windows.Forms.TextBox();
            this.panelRow5 = new System.Windows.Forms.Panel();
            this.lblFirstWeight = new System.Windows.Forms.Label();
            this.txtFirstWeight = new System.Windows.Forms.TextBox();
            this.lblSecondWeight = new System.Windows.Forms.Label();
            this.txtSecondWeight = new System.Windows.Forms.TextBox();
            this.lblGross = new System.Windows.Forms.Label();
            this.txtGross = new System.Windows.Forms.TextBox();
            this.lblTare = new System.Windows.Forms.Label();
            this.txtTare = new System.Windows.Forms.TextBox();
            this.panelRow6 = new System.Windows.Forms.Panel();
            this.lblNet = new System.Windows.Forms.Label();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.lblProductNet = new System.Windows.Forms.Label();
            this.txtProductNet = new System.Windows.Forms.TextBox();
            this.lblExceptWater = new System.Windows.Forms.Label();
            this.txtExceptWater = new System.Windows.Forms.TextBox();
            this.lblExceptOther = new System.Windows.Forms.Label();
            this.txtExceptOther = new System.Windows.Forms.TextBox();
            this.panelRow7 = new System.Windows.Forms.Panel();
            this.lblDriver = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.lblBusinessNo = new System.Windows.Forms.Label();
            this.txtBusinessNo = new System.Windows.Forms.TextBox();
            this.lblIdNumber = new System.Windows.Forms.Label();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
            this.lblBusinessType = new System.Windows.Forms.Label();
            this.txtBusinessType = new System.Windows.Forms.TextBox();
            this.panelRow8 = new System.Windows.Forms.Panel();
            this.lblUserName1 = new System.Windows.Forms.Label();
            this.txtUserName1 = new System.Windows.Forms.TextBox();
            this.lblUserName2 = new System.Windows.Forms.Label();
            this.txtUserName2 = new System.Windows.Forms.TextBox();
            this.lblDataStatus = new System.Windows.Forms.Label();
            this.txtDataStatus = new System.Windows.Forms.TextBox();
            this.lblReprintCount = new System.Windows.Forms.Label();
            this.txtReprintCount = new System.Windows.Forms.TextBox();
            this.tabWeight = new System.Windows.Forms.TabPage();
            this.splitWeight = new System.Windows.Forms.SplitContainer();
            this.panelWeightCurve = new System.Windows.Forms.Panel();
            this.lblCurveLabel = new System.Windows.Forms.Label();
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.lblPicLabel = new System.Windows.Forms.Label();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.flowBasic.SuspendLayout();
            this.panelRow1.SuspendLayout();
            this.panelRow2.SuspendLayout();
            this.panelRow3.SuspendLayout();
            this.panelRow4.SuspendLayout();
            this.panelRow5.SuspendLayout();
            this.panelRow6.SuspendLayout();
            this.panelRow7.SuspendLayout();
            this.panelRow8.SuspendLayout();
            this.tabWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitWeight)).BeginInit();
            this.splitWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.tabLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabBasic);
            this.tabControl.Controls.Add(this.tabWeight);
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 520);
            this.tabControl.TabIndex = 0;

            // tabBasic
            this.tabBasic.AutoScroll = true;
            this.tabBasic.Controls.Add(this.flowBasic);
            this.tabBasic.Location = new System.Drawing.Point(4, 22);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(5);
            this.tabBasic.Size = new System.Drawing.Size(892, 494);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "基本信息";
            this.tabBasic.UseVisualStyleBackColor = true;

            // flowBasic
            this.flowBasic.AutoScroll = true;
            this.flowBasic.Controls.Add(this.panelRow1);
            this.flowBasic.Controls.Add(this.panelRow2);
            this.flowBasic.Controls.Add(this.panelRow3);
            this.flowBasic.Controls.Add(this.panelRow4);
            this.flowBasic.Controls.Add(this.panelRow5);
            this.flowBasic.Controls.Add(this.panelRow6);
            this.flowBasic.Controls.Add(this.panelRow7);
            this.flowBasic.Controls.Add(this.panelRow8);
            this.flowBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowBasic.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowBasic.Location = new System.Drawing.Point(5, 5);
            this.flowBasic.Name = "flowBasic";
            this.flowBasic.Size = new System.Drawing.Size(882, 484);
            this.flowBasic.TabIndex = 0;
            this.flowBasic.WrapContents = false;

            // panelRow1 - TicketNo1, TicketNo2, TruckNo, CardNo
            this.panelRow1.Controls.Add(this.txtCardNo); this.panelRow1.Controls.Add(this.lblCardNo);
            this.panelRow1.Controls.Add(this.txtTruckNo); this.panelRow1.Controls.Add(this.lblTruckNo);
            this.panelRow1.Controls.Add(this.txtTicketNo2); this.panelRow1.Controls.Add(this.lblTicketNo2);
            this.panelRow1.Controls.Add(this.txtTicketNo1); this.panelRow1.Controls.Add(this.lblTicketNo1);
            this.panelRow1.Location = new System.Drawing.Point(3, 3);
            this.panelRow1.Name = "panelRow1";
            this.panelRow1.Size = new System.Drawing.Size(870, 32);
            this.panelRow1.TabIndex = 0;
            this.lblTicketNo1.AutoSize = true; this.lblTicketNo1.Location = new System.Drawing.Point(5, 8);
            this.lblTicketNo1.Text = "临时磅单号:"; this.lblTicketNo1.Size = new System.Drawing.Size(65, 12);
            this.txtTicketNo1.Location = new System.Drawing.Point(75, 5); this.txtTicketNo1.Size = new System.Drawing.Size(100, 21);
            this.txtTicketNo1.ReadOnly = true;
            this.lblTicketNo2.AutoSize = true; this.lblTicketNo2.Location = new System.Drawing.Point(185, 8);
            this.lblTicketNo2.Text = "交易磅单号:"; this.lblTicketNo2.Size = new System.Drawing.Size(65, 12);
            this.txtTicketNo2.Location = new System.Drawing.Point(255, 5); this.txtTicketNo2.Size = new System.Drawing.Size(100, 21);
            this.txtTicketNo2.ReadOnly = true;
            this.lblTruckNo.AutoSize = true; this.lblTruckNo.Location = new System.Drawing.Point(365, 8);
            this.lblTruckNo.Text = "车号："; this.lblTruckNo.Size = new System.Drawing.Size(41, 12);
            this.txtTruckNo.Location = new System.Drawing.Point(410, 5); this.txtTruckNo.Size = new System.Drawing.Size(80, 21);
            this.txtTruckNo.ReadOnly = true;
            this.lblCardNo.AutoSize = true; this.lblCardNo.Location = new System.Drawing.Point(500, 8);
            this.lblCardNo.Text = "卡号："; this.lblCardNo.Size = new System.Drawing.Size(41, 12);
            this.txtCardNo.Location = new System.Drawing.Point(545, 5); this.txtCardNo.Size = new System.Drawing.Size(80, 21);
            this.txtCardNo.ReadOnly = true;

            // panelRow2 - ContractNo, Product, ProductCode, Specification
            this.panelRow2.Controls.Add(this.txtSpecification); this.panelRow2.Controls.Add(this.lblSpecification);
            this.panelRow2.Controls.Add(this.txtProductCode); this.panelRow2.Controls.Add(this.lblProductCode);
            this.panelRow2.Controls.Add(this.txtProduct); this.panelRow2.Controls.Add(this.lblProduct);
            this.panelRow2.Controls.Add(this.txtContractNo); this.panelRow2.Controls.Add(this.lblContractNo);
            this.panelRow2.Location = new System.Drawing.Point(3, 35);
            this.panelRow2.Name = "panelRow2";
            this.panelRow2.Size = new System.Drawing.Size(870, 32);
            this.panelRow2.TabIndex = 1;
            this.lblContractNo.AutoSize = true; this.lblContractNo.Location = new System.Drawing.Point(5, 8);
            this.lblContractNo.Text = "合同号:"; this.lblContractNo.Size = new System.Drawing.Size(41, 12);
            this.txtContractNo.Location = new System.Drawing.Point(50, 5); this.txtContractNo.Size = new System.Drawing.Size(100, 21);
            this.txtContractNo.ReadOnly = true;
            this.lblProduct.AutoSize = true; this.lblProduct.Location = new System.Drawing.Point(160, 8);
            this.lblProduct.Text = "货物："; this.lblProduct.Size = new System.Drawing.Size(41, 12);
            this.txtProduct.Location = new System.Drawing.Point(205, 5); this.txtProduct.Size = new System.Drawing.Size(100, 21);
            this.txtProduct.ReadOnly = true;
            this.lblProductCode.AutoSize = true; this.lblProductCode.Location = new System.Drawing.Point(315, 8);
            this.lblProductCode.Text = "编码："; this.lblProductCode.Size = new System.Drawing.Size(41, 12);
            this.txtProductCode.Location = new System.Drawing.Point(360, 5); this.txtProductCode.Size = new System.Drawing.Size(80, 21);
            this.txtProductCode.ReadOnly = true;
            this.lblSpecification.AutoSize = true; this.lblSpecification.Location = new System.Drawing.Point(450, 8);
            this.lblSpecification.Text = "规格："; this.lblSpecification.Size = new System.Drawing.Size(41, 12);
            this.txtSpecification.Location = new System.Drawing.Point(495, 5); this.txtSpecification.Size = new System.Drawing.Size(100, 21);
            this.txtSpecification.ReadOnly = true;

            // panelRow3 - Sender, Receiver, Transporter
            this.panelRow3.Controls.Add(this.txtTransporter); this.panelRow3.Controls.Add(this.lblTransporter);
            this.panelRow3.Controls.Add(this.txtReceiver); this.panelRow3.Controls.Add(this.lblReceiver);
            this.panelRow3.Controls.Add(this.txtSender); this.panelRow3.Controls.Add(this.lblSender);
            this.panelRow3.Location = new System.Drawing.Point(3, 67);
            this.panelRow3.Name = "panelRow3";
            this.panelRow3.Size = new System.Drawing.Size(870, 32);
            this.panelRow3.TabIndex = 2;
            this.lblSender.AutoSize = true; this.lblSender.Location = new System.Drawing.Point(5, 8);
            this.lblSender.Text = "发货单位:"; this.lblSender.Size = new System.Drawing.Size(53, 12);
            this.txtSender.Location = new System.Drawing.Point(62, 5); this.txtSender.Size = new System.Drawing.Size(150, 21);
            this.txtSender.ReadOnly = true;
            this.lblReceiver.AutoSize = true; this.lblReceiver.Location = new System.Drawing.Point(222, 8);
            this.lblReceiver.Text = "收货单位:"; this.lblReceiver.Size = new System.Drawing.Size(53, 12);
            this.txtReceiver.Location = new System.Drawing.Point(279, 5); this.txtReceiver.Size = new System.Drawing.Size(150, 21);
            this.txtReceiver.ReadOnly = true;
            this.lblTransporter.AutoSize = true; this.lblTransporter.Location = new System.Drawing.Point(439, 8);
            this.lblTransporter.Text = "运输单位:"; this.lblTransporter.Size = new System.Drawing.Size(53, 12);
            this.txtTransporter.Location = new System.Drawing.Point(496, 5); this.txtTransporter.Size = new System.Drawing.Size(150, 21);
            this.txtTransporter.ReadOnly = true;

            // panelRow4 - FirstDateTime, SecondDateTime, GrossDateTime, TareDateTime
            this.panelRow4.Controls.Add(this.txtTareDateTime); this.panelRow4.Controls.Add(this.lblTareDateTime);
            this.panelRow4.Controls.Add(this.txtGrossDateTime); this.panelRow4.Controls.Add(this.lblGrossDateTime);
            this.panelRow4.Controls.Add(this.txtSecondDateTime); this.panelRow4.Controls.Add(this.lblSecondDateTime);
            this.panelRow4.Controls.Add(this.txtFirstDateTime); this.panelRow4.Controls.Add(this.lblFirstDateTime);
            this.panelRow4.Location = new System.Drawing.Point(3, 99);
            this.panelRow4.Name = "panelRow4";
            this.panelRow4.Size = new System.Drawing.Size(870, 32);
            this.panelRow4.TabIndex = 3;
            this.lblFirstDateTime.AutoSize = true; this.lblFirstDateTime.Location = new System.Drawing.Point(5, 8);
            this.lblFirstDateTime.Text = "临时时间:"; this.lblFirstDateTime.Size = new System.Drawing.Size(53, 12);
            this.txtFirstDateTime.Location = new System.Drawing.Point(62, 5); this.txtFirstDateTime.Size = new System.Drawing.Size(130, 21);
            this.txtFirstDateTime.ReadOnly = true;
            this.lblSecondDateTime.AutoSize = true; this.lblSecondDateTime.Location = new System.Drawing.Point(202, 8);
            this.lblSecondDateTime.Text = "交易时间:"; this.lblSecondDateTime.Size = new System.Drawing.Size(53, 12);
            this.txtSecondDateTime.Location = new System.Drawing.Point(259, 5); this.txtSecondDateTime.Size = new System.Drawing.Size(130, 21);
            this.txtSecondDateTime.ReadOnly = true;
            this.lblGrossDateTime.AutoSize = true; this.lblGrossDateTime.Location = new System.Drawing.Point(399, 8);
            this.lblGrossDateTime.Text = "毛重时间:"; this.lblGrossDateTime.Size = new System.Drawing.Size(53, 12);
            this.txtGrossDateTime.Location = new System.Drawing.Point(456, 5); this.txtGrossDateTime.Size = new System.Drawing.Size(130, 21);
            this.txtGrossDateTime.ReadOnly = true;
            this.lblTareDateTime.AutoSize = true; this.lblTareDateTime.Location = new System.Drawing.Point(596, 8);
            this.lblTareDateTime.Text = "皮重时间:"; this.lblTareDateTime.Size = new System.Drawing.Size(53, 12);
            this.txtTareDateTime.Location = new System.Drawing.Point(653, 5); this.txtTareDateTime.Size = new System.Drawing.Size(130, 21);
            this.txtTareDateTime.ReadOnly = true;

            // panelRow5 - FirstWeight, SecondWeight, Gross, Tare
            this.panelRow5.Controls.Add(this.txtTare); this.panelRow5.Controls.Add(this.lblTare);
            this.panelRow5.Controls.Add(this.txtGross); this.panelRow5.Controls.Add(this.lblGross);
            this.panelRow5.Controls.Add(this.txtSecondWeight); this.panelRow5.Controls.Add(this.lblSecondWeight);
            this.panelRow5.Controls.Add(this.txtFirstWeight); this.panelRow5.Controls.Add(this.lblFirstWeight);
            this.panelRow5.Location = new System.Drawing.Point(3, 131);
            this.panelRow5.Name = "panelRow5";
            this.panelRow5.Size = new System.Drawing.Size(870, 32);
            this.panelRow5.TabIndex = 4;
            this.lblFirstWeight.AutoSize = true; this.lblFirstWeight.Location = new System.Drawing.Point(5, 8);
            this.lblFirstWeight.Text = "临时重量:"; this.lblFirstWeight.Size = new System.Drawing.Size(53, 12);
            this.txtFirstWeight.Location = new System.Drawing.Point(62, 5); this.txtFirstWeight.Size = new System.Drawing.Size(80, 21);
            this.txtFirstWeight.ReadOnly = true;
            this.lblSecondWeight.AutoSize = true; this.lblSecondWeight.Location = new System.Drawing.Point(152, 8);
            this.lblSecondWeight.Text = "交易重量:"; this.lblSecondWeight.Size = new System.Drawing.Size(53, 12);
            this.txtSecondWeight.Location = new System.Drawing.Point(209, 5); this.txtSecondWeight.Size = new System.Drawing.Size(80, 21);
            this.txtSecondWeight.ReadOnly = true;
            this.lblGross.AutoSize = true; this.lblGross.Location = new System.Drawing.Point(299, 8);
            this.lblGross.Text = "毛重："; this.lblGross.Size = new System.Drawing.Size(41, 12);
            this.txtGross.Location = new System.Drawing.Point(344, 5); this.txtGross.Size = new System.Drawing.Size(80, 21);
            this.txtGross.ReadOnly = true;
            this.lblTare.AutoSize = true; this.lblTare.Location = new System.Drawing.Point(434, 8);
            this.lblTare.Text = "皮重："; this.lblTare.Size = new System.Drawing.Size(41, 12);
            this.txtTare.Location = new System.Drawing.Point(479, 5); this.txtTare.Size = new System.Drawing.Size(80, 21);
            this.txtTare.ReadOnly = true;

            // panelRow6 - Net, ProductNet, ExceptWater, ExceptOther
            this.panelRow6.Controls.Add(this.txtExceptOther); this.panelRow6.Controls.Add(this.lblExceptOther);
            this.panelRow6.Controls.Add(this.txtExceptWater); this.panelRow6.Controls.Add(this.lblExceptWater);
            this.panelRow6.Controls.Add(this.txtProductNet); this.panelRow6.Controls.Add(this.lblProductNet);
            this.panelRow6.Controls.Add(this.txtNet); this.panelRow6.Controls.Add(this.lblNet);
            this.panelRow6.Location = new System.Drawing.Point(3, 163);
            this.panelRow6.Name = "panelRow6";
            this.panelRow6.Size = new System.Drawing.Size(870, 32);
            this.panelRow6.TabIndex = 5;
            this.lblNet.AutoSize = true; this.lblNet.Location = new System.Drawing.Point(5, 8);
            this.lblNet.Text = "净重："; this.lblNet.Size = new System.Drawing.Size(41, 12);
            this.txtNet.Location = new System.Drawing.Point(50, 5); this.txtNet.Size = new System.Drawing.Size(80, 21);
            this.txtNet.ReadOnly = true;
            this.lblProductNet.AutoSize = true; this.lblProductNet.Location = new System.Drawing.Point(140, 8);
            this.lblProductNet.Text = "货物净重:"; this.lblProductNet.Size = new System.Drawing.Size(53, 12);
            this.txtProductNet.Location = new System.Drawing.Point(197, 5); this.txtProductNet.Size = new System.Drawing.Size(80, 21);
            this.txtProductNet.ReadOnly = true;
            this.lblExceptWater.AutoSize = true; this.lblExceptWater.Location = new System.Drawing.Point(287, 8);
            this.lblExceptWater.Text = "扣水："; this.lblExceptWater.Size = new System.Drawing.Size(41, 12);
            this.txtExceptWater.Location = new System.Drawing.Point(332, 5); this.txtExceptWater.Size = new System.Drawing.Size(80, 21);
            this.txtExceptWater.ReadOnly = true;
            this.lblExceptOther.AutoSize = true; this.lblExceptOther.Location = new System.Drawing.Point(422, 8);
            this.lblExceptOther.Text = "扣杂："; this.lblExceptOther.Size = new System.Drawing.Size(41, 12);
            this.txtExceptOther.Location = new System.Drawing.Point(467, 5); this.txtExceptOther.Size = new System.Drawing.Size(80, 21);
            this.txtExceptOther.ReadOnly = true;

            // panelRow7 - Driver, BusinessNo, IdNumber, BusinessType
            this.panelRow7.Controls.Add(this.txtBusinessType); this.panelRow7.Controls.Add(this.lblBusinessType);
            this.panelRow7.Controls.Add(this.txtIdNumber); this.panelRow7.Controls.Add(this.lblIdNumber);
            this.panelRow7.Controls.Add(this.txtBusinessNo); this.panelRow7.Controls.Add(this.lblBusinessNo);
            this.panelRow7.Controls.Add(this.txtDriver); this.panelRow7.Controls.Add(this.lblDriver);
            this.panelRow7.Location = new System.Drawing.Point(3, 195);
            this.panelRow7.Name = "panelRow7";
            this.panelRow7.Size = new System.Drawing.Size(870, 32);
            this.panelRow7.TabIndex = 6;
            this.lblDriver.AutoSize = true; this.lblDriver.Location = new System.Drawing.Point(5, 8);
            this.lblDriver.Text = "司机："; this.lblDriver.Size = new System.Drawing.Size(41, 12);
            this.txtDriver.Location = new System.Drawing.Point(50, 5); this.txtDriver.Size = new System.Drawing.Size(80, 21);
            this.txtDriver.ReadOnly = true;
            this.lblBusinessNo.AutoSize = true; this.lblBusinessNo.Location = new System.Drawing.Point(140, 8);
            this.lblBusinessNo.Text = "业务单号:"; this.lblBusinessNo.Size = new System.Drawing.Size(53, 12);
            this.txtBusinessNo.Location = new System.Drawing.Point(197, 5); this.txtBusinessNo.Size = new System.Drawing.Size(100, 21);
            this.txtBusinessNo.ReadOnly = true;
            this.lblIdNumber.AutoSize = true; this.lblIdNumber.Location = new System.Drawing.Point(307, 8);
            this.lblIdNumber.Text = "身份证:"; this.lblIdNumber.Size = new System.Drawing.Size(41, 12);
            this.txtIdNumber.Location = new System.Drawing.Point(352, 5); this.txtIdNumber.Size = new System.Drawing.Size(120, 21);
            this.txtIdNumber.ReadOnly = true;
            this.lblBusinessType.AutoSize = true; this.lblBusinessType.Location = new System.Drawing.Point(482, 8);
            this.lblBusinessType.Text = "业务类型:"; this.lblBusinessType.Size = new System.Drawing.Size(53, 12);
            this.txtBusinessType.Location = new System.Drawing.Point(539, 5); this.txtBusinessType.Size = new System.Drawing.Size(80, 21);
            this.txtBusinessType.ReadOnly = true;

            // panelRow8 - UserName1, UserName2, DataStatus, ReprintCount
            this.panelRow8.Controls.Add(this.txtReprintCount); this.panelRow8.Controls.Add(this.lblReprintCount);
            this.panelRow8.Controls.Add(this.txtDataStatus); this.panelRow8.Controls.Add(this.lblDataStatus);
            this.panelRow8.Controls.Add(this.txtUserName2); this.panelRow8.Controls.Add(this.lblUserName2);
            this.panelRow8.Controls.Add(this.txtUserName1); this.panelRow8.Controls.Add(this.lblUserName1);
            this.panelRow8.Location = new System.Drawing.Point(3, 227);
            this.panelRow8.Name = "panelRow8";
            this.panelRow8.Size = new System.Drawing.Size(870, 32);
            this.panelRow8.TabIndex = 7;
            this.lblUserName1.AutoSize = true; this.lblUserName1.Location = new System.Drawing.Point(5, 8);
            this.lblUserName1.Text = "临时操作员:"; this.lblUserName1.Size = new System.Drawing.Size(65, 12);
            this.txtUserName1.Location = new System.Drawing.Point(75, 5); this.txtUserName1.Size = new System.Drawing.Size(80, 21);
            this.txtUserName1.ReadOnly = true;
            this.lblUserName2.AutoSize = true; this.lblUserName2.Location = new System.Drawing.Point(160, 8);
            this.lblUserName2.Text = "交易操作员:"; this.lblUserName2.Size = new System.Drawing.Size(65, 12);
            this.txtUserName2.Location = new System.Drawing.Point(230, 5); this.txtUserName2.Size = new System.Drawing.Size(80, 21);
            this.txtUserName2.ReadOnly = true;
            this.lblDataStatus.AutoSize = true; this.lblDataStatus.Location = new System.Drawing.Point(320, 8);
            this.lblDataStatus.Text = "数据状态:"; this.lblDataStatus.Size = new System.Drawing.Size(53, 12);
            this.txtDataStatus.Location = new System.Drawing.Point(377, 5); this.txtDataStatus.Size = new System.Drawing.Size(60, 21);
            this.txtDataStatus.ReadOnly = true;
            this.lblReprintCount.AutoSize = true; this.lblReprintCount.Location = new System.Drawing.Point(447, 8);
            this.lblReprintCount.Text = "补打次数:"; this.lblReprintCount.Size = new System.Drawing.Size(53, 12);
            this.txtReprintCount.Location = new System.Drawing.Point(504, 5); this.txtReprintCount.Size = new System.Drawing.Size(50, 21);
            this.txtReprintCount.ReadOnly = true;

            // tabWeight
            this.tabWeight.Controls.Add(this.splitWeight);
            this.tabWeight.Location = new System.Drawing.Point(4, 22);
            this.tabWeight.Name = "tabWeight";
            this.tabWeight.Padding = new System.Windows.Forms.Padding(5);
            this.tabWeight.Size = new System.Drawing.Size(892, 494);
            this.tabWeight.TabIndex = 1;
            this.tabWeight.Text = "重量曲线/抓拍";
            this.tabWeight.UseVisualStyleBackColor = true;

            // splitWeight
            this.splitWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitWeight.Location = new System.Drawing.Point(5, 5);
            this.splitWeight.Name = "splitWeight";
            this.splitWeight.Size = new System.Drawing.Size(882, 484);
            this.splitWeight.SplitterDistance = 450;
            this.splitWeight.SplitterWidth = 6;
            this.splitWeight.TabIndex = 0;
            this.splitWeight.Panel1.Controls.Add(this.panelWeightCurve);
            this.splitWeight.Panel1.Controls.Add(this.lblCurveLabel);
            this.splitWeight.Panel2.Controls.Add(this.picCapture);
            this.splitWeight.Panel2.Controls.Add(this.lblPicLabel);

            // lblCurveLabel
            this.lblCurveLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurveLabel.Location = new System.Drawing.Point(0, 0);
            this.lblCurveLabel.Name = "lblCurveLabel";
            this.lblCurveLabel.Size = new System.Drawing.Size(450, 20);
            this.lblCurveLabel.TabIndex = 0;
            this.lblCurveLabel.Text = "重量曲线";

            // panelWeightCurve
            this.panelWeightCurve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelWeightCurve.BackColor = System.Drawing.Color.White;
            this.panelWeightCurve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWeightCurve.Location = new System.Drawing.Point(3, 23);
            this.panelWeightCurve.Name = "panelWeightCurve";
            this.panelWeightCurve.Size = new System.Drawing.Size(444, 458);
            this.panelWeightCurve.TabIndex = 1;

            // lblPicLabel
            this.lblPicLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPicLabel.Location = new System.Drawing.Point(0, 0);
            this.lblPicLabel.Name = "lblPicLabel";
            this.lblPicLabel.Size = new System.Drawing.Size(426, 20);
            this.lblPicLabel.TabIndex = 0;
            this.lblPicLabel.Text = "抓拍图片";

            // picCapture
            this.picCapture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.picCapture.BackColor = System.Drawing.Color.LightGray;
            this.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCapture.Location = new System.Drawing.Point(3, 23);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(420, 458);
            this.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCapture.TabIndex = 1;
            this.picCapture.TabStop = false;

            // tabLogs
            this.tabLogs.Controls.Add(this.dgvLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 22);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(5);
            this.tabLogs.Size = new System.Drawing.Size(892, 494);
            this.tabLogs.TabIndex = 2;
            this.tabLogs.Text = "操作日志";
            this.tabLogs.UseVisualStyleBackColor = true;

            // dgvLogs
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.AutoSizeColumnsMode.DisplayedCells;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(5, 5);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowTemplate.Height = 23;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(882, 484);
            this.dgvLogs.TabIndex = 0;

            // panelButtons
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnPrint);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(0, 520);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.panelButtons.Size = new System.Drawing.Size(900, 40);
            this.panelButtons.TabIndex = 1;

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(832, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 25);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(766, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(700, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // btnPrint
            this.btnPrint.Location = new System.Drawing.Point(634, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 25);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(568, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // frmDetailRecord
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelButtons);
            this.Name = "frmDetailRecord";
            this.Load += new System.EventHandler(this.frmDetailRecord_Load);
            this.tabControl.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.flowBasic.ResumeLayout(false);
            this.panelRow1.ResumeLayout(false); this.panelRow1.PerformLayout();
            this.panelRow2.ResumeLayout(false); this.panelRow2.PerformLayout();
            this.panelRow3.ResumeLayout(false); this.panelRow3.PerformLayout();
            this.panelRow4.ResumeLayout(false); this.panelRow4.PerformLayout();
            this.panelRow5.ResumeLayout(false); this.panelRow5.PerformLayout();
            this.panelRow6.ResumeLayout(false); this.panelRow6.PerformLayout();
            this.panelRow7.ResumeLayout(false); this.panelRow7.PerformLayout();
            this.panelRow8.ResumeLayout(false); this.panelRow8.PerformLayout();
            this.tabWeight.ResumeLayout(false);
            this.splitWeight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.tabLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.FlowLayoutPanel flowBasic;
        private System.Windows.Forms.Panel panelRow1;
        private System.Windows.Forms.Label lblTicketNo1;
        private System.Windows.Forms.TextBox txtTicketNo1;
        private System.Windows.Forms.Label lblTicketNo2;
        private System.Windows.Forms.TextBox txtTicketNo2;
        private System.Windows.Forms.Label lblTruckNo;
        private System.Windows.Forms.TextBox txtTruckNo;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Panel panelRow2;
        private System.Windows.Forms.Label lblContractNo;
        private System.Windows.Forms.TextBox txtContractNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblSpecification;
        private System.Windows.Forms.TextBox txtSpecification;
        private System.Windows.Forms.Panel panelRow3;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.Label lblTransporter;
        private System.Windows.Forms.TextBox txtTransporter;
        private System.Windows.Forms.Panel panelRow4;
        private System.Windows.Forms.Label lblFirstDateTime;
        private System.Windows.Forms.TextBox txtFirstDateTime;
        private System.Windows.Forms.Label lblSecondDateTime;
        private System.Windows.Forms.TextBox txtSecondDateTime;
        private System.Windows.Forms.Label lblGrossDateTime;
        private System.Windows.Forms.TextBox txtGrossDateTime;
        private System.Windows.Forms.Label lblTareDateTime;
        private System.Windows.Forms.TextBox txtTareDateTime;
        private System.Windows.Forms.Panel panelRow5;
        private System.Windows.Forms.Label lblFirstWeight;
        private System.Windows.Forms.TextBox txtFirstWeight;
        private System.Windows.Forms.Label lblSecondWeight;
        private System.Windows.Forms.TextBox txtSecondWeight;
        private System.Windows.Forms.Label lblGross;
        private System.Windows.Forms.TextBox txtGross;
        private System.Windows.Forms.Label lblTare;
        private System.Windows.Forms.TextBox txtTare;
        private System.Windows.Forms.Panel panelRow6;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.TextBox txtNet;
        private System.Windows.Forms.Label lblProductNet;
        private System.Windows.Forms.TextBox txtProductNet;
        private System.Windows.Forms.Label lblExceptWater;
        private System.Windows.Forms.TextBox txtExceptWater;
        private System.Windows.Forms.Label lblExceptOther;
        private System.Windows.Forms.TextBox txtExceptOther;
        private System.Windows.Forms.Panel panelRow7;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label lblBusinessNo;
        private System.Windows.Forms.TextBox txtBusinessNo;
        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.Label lblBusinessType;
        private System.Windows.Forms.TextBox txtBusinessType;
        private System.Windows.Forms.Panel panelRow8;
        private System.Windows.Forms.Label lblUserName1;
        private System.Windows.Forms.TextBox txtUserName1;
        private System.Windows.Forms.Label lblUserName2;
        private System.Windows.Forms.TextBox txtUserName2;
        private System.Windows.Forms.Label lblDataStatus;
        private System.Windows.Forms.TextBox txtDataStatus;
        private System.Windows.Forms.Label lblReprintCount;
        private System.Windows.Forms.TextBox txtReprintCount;
        private System.Windows.Forms.TabPage tabWeight;
        private System.Windows.Forms.SplitContainer splitWeight;
        private System.Windows.Forms.Panel panelWeightCurve;
        private System.Windows.Forms.Label lblCurveLabel;
        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Label lblPicLabel;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}
