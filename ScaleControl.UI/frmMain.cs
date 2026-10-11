using System;
using System.Windows.Forms;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;
using ScaleControl.UI.Controls;

namespace ScaleControl.UI
{
    public partial class frmMain : Form
    {
        private readonly IWeighingWorkflow _workflow;
        private readonly IWeighingRepository _repository;
        private readonly UserInfo _currentUser;

        // Custom controls
        private WeightDisplayPanel _weightDisplayPanel;
        private EquipmentStatusPanel _equipmentStatusPanel;
        private DataInputPanel _dataInputPanel;
        private VideoMonitorPanel _videoMonitorPanel;
        private HistoryTarePanel _historyTarePanel;
        private QuickDataBrowsePanel _quickDataBrowsePanel;

        public frmMain(IWeighingWorkflow workflow, IWeighingRepository repository, UserInfo currentUser)
        {
            _workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _currentUser = currentUser;

            InitializeComponent();
            InitializeCustomControls();
            WireEvents();
            ApplyUserInfo();
        }

        private void InitializeCustomControls()
        {
            // --- WeightDisplayPanel (narrow, top-left of center area) ---
            _weightDisplayPanel = new WeightDisplayPanel
            {
                Dock = DockStyle.Fill
            };
            centerTableLayout.Controls.Add(_weightDisplayPanel, 0, 0);

            // --- EquipmentStatusPanel (below weight display) ---
            _equipmentStatusPanel = new EquipmentStatusPanel
            {
                Dock = DockStyle.Fill
            };
            centerTableLayout.Controls.Add(_equipmentStatusPanel, 0, 1);

            // --- DataInputPanel (right of weight+equipment, spans both rows) ---
            _dataInputPanel = new DataInputPanel
            {
                Dock = DockStyle.Fill
            };
            centerTableLayout.SetRowSpan(_dataInputPanel, 2);
            centerTableLayout.Controls.Add(_dataInputPanel, 1, 0);

            // --- VideoMonitorPanel (docked right, flush against right border) ---
            _videoMonitorPanel = new VideoMonitorPanel
            {
                Dock = DockStyle.Fill
            };
            rightTableLayout.Controls.Add(_videoMonitorPanel, 0, 0);

            // --- HistoryTarePanel (bottom-left) ---
            _historyTarePanel = new HistoryTarePanel
            {
                Dock = DockStyle.Fill
            };
            bottomTableLayout.Controls.Add(_historyTarePanel, 0, 0);

            // --- QuickDataBrowsePanel (bottom-right) ---
            _quickDataBrowsePanel = new QuickDataBrowsePanel
            {
                Dock = DockStyle.Fill
            };
            bottomTableLayout.Controls.Add(_quickDataBrowsePanel, 1, 0);
        }

        private void WireEvents()
        {
            // Menu item clicks
            menuBar.MenuItemClicked += MenuBar_MenuItemClicked;

            // Weight display scale selection
            _weightDisplayPanel.ScaleSelected += WeightDisplayPanel_ScaleSelected;

            // Data input panel - truck number leave event
            _dataInputPanel.TruckNumberChanged += DataInputPanel_TruckNumberChanged;

            // Toolbar buttons
            btnContinue.Click += BtnContinue_Click;
            btnRead.Click += BtnRead_Click;
            btnSave.Click += BtnSave_Click;
            btnPrint.Click += BtnPrint_Click;
            btnSwitchUser.Click += BtnSwitchUser_Click;
            btnExit.Click += BtnExit_Click;

            // Workflow events - subscribe to scale driver if available
            SubscribeToScaleDriver();

            // Form closing
            this.FormClosing += FrmMain_FormClosing;
        }

        private void DataInputPanel_TruckNumberChanged(object sender, EventArgs e)
        {
            string truckNo = _dataInputPanel.GetFieldValues()["车号"];
            if (!string.IsNullOrWhiteSpace(truckNo))
            {
                _workflow.LoadTruckInfo(truckNo);
                var record = _workflow.CurrentRecord;
                _historyTarePanel.SetCurrentTruck(truckNo);

                // Update data input panel with loaded truck info
                if (record.Tare.HasValue)
                {
                    _dataInputPanel.SetWeightValues(
                        record.Gross ?? 0,
                        record.Tare ?? 0,
                        record.Net ?? 0);
                }

                statusLabel.Text = "已加载车号: " + truckNo;
            }
        }

        private void SubscribeToScaleDriver()
        {
            // Subscribe to weight updates from the workflow's scale driver
            var driver = _workflow.ScaleDriver;
            if (driver != null)
            {
                driver.WeightUpdated += ScaleDriver_WeightUpdated;
                driver.ConnectionStatusChanged += ScaleDriver_ConnectionStatusChanged;
            }
        }

        private void ApplyUserInfo()
        {
            if (_currentUser != null)
            {
                lblUser.Text = "用户: " + (_currentUser.UserName ?? _currentUser.LogName ?? "未知");
            }
            else
            {
                lblUser.Text = "用户: 未登录";
            }
            lblShift.Text = "班次: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        #region Event Handlers

        private void MenuBar_MenuItemClicked(object sender, MenuItem e)
        {
            statusLabel.Text = "菜单: " + e.Title;

            switch (e.Id)
            {
                case "m_weigh":
                    // Already on weighing page
                    statusLabel.Text = "当前: 称重页面";
                    break;
                case "m_tare":
                    MessageBox.Show("皮重管理功能开发中...", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "m_truck":
                    MessageBox.Show("车号管理功能开发中...", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "m_report_weigh":
                case "m_report_daily":
                case "m_report_monthly":
                    MessageBox.Show("报表查询功能开发中...", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "m_sys_config":
                case "m_sys_user":
                case "m_sys_device":
                    MessageBox.Show("系统设置功能开发中...", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "m_help_about":
                    MessageBox.Show("称重管理系统 V1.0\n.NET Framework 4.8 MVP",
                        "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    statusLabel.Text = "选中: " + e.Title;
                    break;
            }
        }

        private void WeightDisplayPanel_ScaleSelected(object sender, int scaleIndex)
        {
            statusLabel.Text = "已选择: 磅" + scaleIndex;
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            _workflow.Continue();
            _dataInputPanel.ClearFields();
            statusLabel.Text = "已继续 - 准备新一次称重";
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            if (!_workflow.IsReadingAllowed)
            {
                statusLabel.Text = "读数失败: 秤未连接或重量不稳定";
                return;
            }

            WeightData weightData = _workflow.ReadWeight();
            if (weightData != null)
            {
                _weightDisplayPanel.SetWeight((double)weightData.Weight);
                _weightDisplayPanel.SetStable(weightData.IsStable);

                // Update data input panel with current record values
                var record = _workflow.CurrentRecord;
                _dataInputPanel.SetWeightValues(
                    record.Gross ?? 0,
                    record.Tare ?? 0,
                    record.Net ?? 0);

                statusLabel.Text = $"读数成功: {weightData.Weight} kg {(weightData.IsStable ? "(稳定)" : "(波动)")}";
            }
            else
            {
                statusLabel.Text = "读数失败: 无法获取重量数据";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!_dataInputPanel.ValidateRequiredFields())
            {
                MessageBox.Show("请填写必填字段（车号）", "验证失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sync data input fields to workflow record
            SyncInputToRecord();

            bool success = _workflow.SaveRecord();
            if (success)
            {
                statusLabel.Text = "保存成功 - 磅单号: " + _workflow.CurrentRecord.TicketNo1;
                MessageBox.Show("称重记录保存成功！", "成功",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                statusLabel.Text = "保存失败 - 防作弊检查未通过";
                MessageBox.Show("保存失败：防作弊检查未通过，请检查数据。", "失败",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            _workflow.PrintTicket();
            statusLabel.Text = "打印: 磅单已发送到打印机";
        }

        private void BtnSwitchUser_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确定要切换用户吗？", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // MVP: close current form, would show login form in full version
                this.Close();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确定要退出系统吗？", "确认退出",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ScaleDriver_WeightUpdated(object sender, WeightData e)
        {
            if (e == null) return;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ScaleDriver_WeightUpdated(sender, e)));
                return;
            }

            _weightDisplayPanel.SetWeight((double)e.Weight);
            _weightDisplayPanel.SetStable(e.IsStable);
            _weightDisplayPanel.SetConnected(true);
        }

        private void ScaleDriver_ConnectionStatusChanged(object sender, string e)
        {
            bool connected = e == "Connected" || e == "已连接";

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ScaleDriver_ConnectionStatusChanged(sender, e)));
                return;
            }

            _weightDisplayPanel.SetConnected(connected);
            statusLabel.Text = connected
                ? "秤已连接"
                : "秤已断开";
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unsubscribe from events
            try
            {
                var field = _workflow.GetType().GetField("_scaleDriver",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
                if (field != null)
                {
                    var driver = field.GetValue(_workflow) as IScaleDriver;
                    if (driver != null)
                    {
                        driver.WeightUpdated -= ScaleDriver_WeightUpdated;
                        driver.ConnectionStatusChanged -= ScaleDriver_ConnectionStatusChanged;
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Helper Methods

        private void SyncInputToRecord()
        {
            var fields = _dataInputPanel.GetFieldValues();
            var record = _workflow.CurrentRecord;

            if (fields.ContainsKey("车号"))
                record.TruckNo = fields["车号"];
            if (fields.ContainsKey("货物"))
                record.Product = fields["货物"];
            if (fields.ContainsKey("发货单位"))
                record.Sender = fields["发货单位"];
            if (fields.ContainsKey("收货单位"))
                record.Receiver = fields["收货单位"];
            if (fields.ContainsKey("规格"))
                record.Specification = fields["规格"];
            if (fields.ContainsKey("司机"))
                record.Driver = fields["司机"];
            if (fields.ContainsKey("业务单号"))
                record.BusinessNo = fields["业务单号"];
            if (fields.ContainsKey("货物类型"))
                record.BusinessType = fields["货物类型"];

            // Set operator info
            if (_currentUser != null)
            {
                record.UserId1 = _currentUser.UserId;
                record.UserName1 = _currentUser.UserName;
            }
        }

        #endregion
    }
}
