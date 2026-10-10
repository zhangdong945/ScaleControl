using System;
using System.Windows.Forms;
using ScaleControl.Data;
using ScaleControl.Models.Config;

namespace ScaleControl.UI.Forms
{
    public partial class frmDatabaseConfig : Form
    {
        private DatabaseConfig _config;
        private readonly string _configPath;

        public frmDatabaseConfig(string configPath)
        {
            InitializeComponent();
            _configPath = configPath;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "数据库配置";
        }

        private void frmDatabaseConfig_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                if (System.IO.File.Exists(_configPath))
                {
                    _config = DatabaseConfigLoader.Load(_configPath);
                }
                else
                {
                    _config = new DatabaseConfig();
                }

                txtAccessPath.Text = _config.AccessDatabasePath;
                txtAccessPassword.Text = _config.AccessPassword;
                txtSqlHost.Text = _config.SqlServerHost;
                txtSqlDatabase.Text = _config.SqlDatabase;
                txtSqlUser.Text = _config.SqlUser;
                txtSqlPassword.Text = _config.SqlPassword;
                rbAccess.Checked = _config.Provider == "Access";
                rbSqlServer.Checked = _config.Provider == "SqlServer";
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载配置失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _config = new DatabaseConfig();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                var testConfig = GetConfigFromFields();
                if (testConfig.Provider == "Access")
                {
                    // For Access, just check if the file path is valid
                    string path = txtAccessPath.Text.Trim();
                    if (string.IsNullOrEmpty(path))
                    {
                        MessageBox.Show("请输入Access数据库路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MessageBox.Show("Access配置已填写，请确保数据库文件存在。", "测试连接",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // For SQL Server, use DatabaseInitializer.TestConnection
                    var factory = new ScaleControl.Data.SqlConnectionFactory(testConfig.GetSqlServerConnectionString());
                    var initializer = new DatabaseInitializer(factory);
                    bool success = initializer.TestConnection();
                    if (success)
                    {
                        MessageBox.Show("SQL Server连接成功！", "测试连接",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("SQL Server连接失败，请检查配置。", "测试连接",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接测试失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _config = GetConfigFromFields();
                string dir = System.IO.Path.GetDirectoryName(_configPath);
                if (!string.IsNullOrEmpty(dir) && !System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                DatabaseConfigLoader.Save(_config, _configPath);
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

        private DatabaseConfig GetConfigFromFields()
        {
            return new DatabaseConfig
            {
                Provider = rbAccess.Checked ? "Access" : "SqlServer",
                AccessDatabasePath = txtAccessPath.Text.Trim(),
                AccessPassword = txtAccessPassword.Text,
                SqlServerHost = txtSqlHost.Text.Trim(),
                SqlDatabase = txtSqlDatabase.Text.Trim(),
                SqlUser = txtSqlUser.Text.Trim(),
                SqlPassword = txtSqlPassword.Text
            };
        }

        private void rbAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAccess.Checked)
            {
                panelAccess.Enabled = true;
                panelSqlServer.Enabled = false;
            }
        }

        private void rbSqlServer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSqlServer.Checked)
            {
                panelAccess.Enabled = false;
                panelSqlServer.Enabled = true;
            }
        }
    }
}
