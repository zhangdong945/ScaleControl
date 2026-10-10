using System;
using System.Windows.Forms;
using ScaleControl.Data;
using ScaleControl.Models.Config;

namespace ScaleControl.UI.Forms
{
    public partial class frmScaleConfig : Form
    {
        private ScaleConnectionConfig _config;
        private readonly string _configPath;

        public frmScaleConfig(string configPath)
        {
            InitializeComponent();
            _configPath = configPath;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "秤台配置";
        }

        private void frmScaleConfig_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                if (System.IO.File.Exists(_configPath))
                {
                    _config = HardwareConfigLoader.Load(_configPath);
                }
                else
                {
                    _config = new ScaleConnectionConfig();
                }

                txtDeviceName.Text = _config.DeviceName;
                txtPortName.Text = _config.PortName;
                numBaudRate.Value = _config.BaudRate;
                numDataBits.Value = _config.DataBits;
                cmbStopBits.Text = _config.StopBits.ToString();
                cmbParity.Text = _config.Parity.ToString();
                txtIpAddress.Text = _config.IpAddress;
                numPort.Value = _config.Port;
                numStableTime.Value = _config.StableDetectTime;
                numStableChange.Value = _config.StableAllowChange;
                numMinWeight.Value = _config.MinWeight;
                rbSerial.Checked = _config.ConnectionType == ScaleControl.Models.Enums.ConnectionType.Serial;
                rbNetwork.Checked = _config.ConnectionType == ScaleControl.Models.Enums.ConnectionType.Network;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载配置失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _config = new ScaleConnectionConfig();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _config.DeviceName = txtDeviceName.Text.Trim();
                _config.PortName = txtPortName.Text.Trim();
                _config.BaudRate = (int)numBaudRate.Value;
                _config.DataBits = (int)numDataBits.Value;

                // StopBits and Parity are set via reflection to avoid System.IO.Ports dependency
                SetEnumValue("StopBits", cmbStopBits.Text);
                SetEnumValue("Parity", cmbParity.Text);

                _config.IpAddress = txtIpAddress.Text.Trim();
                _config.Port = (int)numPort.Value;
                _config.StableDetectTime = (int)numStableTime.Value;
                _config.StableAllowChange = (int)numStableChange.Value;
                _config.MinWeight = (int)numMinWeight.Value;
                _config.ConnectionType = rbSerial.Checked
                    ? ScaleControl.Models.Enums.ConnectionType.Serial
                    : ScaleControl.Models.Enums.ConnectionType.Network;

                string dir = System.IO.Path.GetDirectoryName(_configPath);
                if (!string.IsNullOrEmpty(dir) && !System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                HardwareConfigLoader.Save(_config, _configPath);
                MessageBox.Show("配置保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetEnumValue(string propertyName, string value)
        {
            try
            {
                var prop = _config.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    var enumType = prop.PropertyType;
                    if (enumType.IsEnum)
                    {
                        object parsed;
                        if (int.TryParse(value, out int intVal))
                        {
                            parsed = Enum.ToObject(enumType, intVal);
                        }
                        else
                        {
                            parsed = Enum.Parse(enumType, value);
                        }
                        prop.SetValue(_config, parsed);
                    }
                }
            }
            catch
            {
                // If parsing fails, keep the default value
            }
        }

        private void rbSerial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSerial.Checked)
            {
                panelSerial.Enabled = true;
                panelNetwork.Enabled = false;
            }
        }

        private void rbNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNetwork.Checked)
            {
                panelSerial.Enabled = false;
                panelNetwork.Enabled = true;
            }
        }
    }
}
