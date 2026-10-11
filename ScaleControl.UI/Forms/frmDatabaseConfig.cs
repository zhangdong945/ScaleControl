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
        private readonly string _appDir;

        public frmDatabaseConfig(string configPath, string appDir)
        {
            InitializeComponent();
            _configPath = configPath;
            _appDir = appDir;
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

                // 显示绝对路径（如果是相对路径则转换为基于应用程序目录的绝对路径）
                string dbPath = _config.AccessDatabasePath;
                if (!string.IsNullOrEmpty(dbPath) && !System.IO.Path.IsPathRooted(dbPath) && _appDir != null)
                {
                    dbPath = System.IO.Path.Combine(_appDir, dbPath);
                }
                txtAccessPath.Text = dbPath;
                txtAccessPassword.Text = _config.AccessPassword;
                txtSqlHost.Text = _config.SqlServerHost;
                txtSqlDatabase.Text = _config.SqlDatabase;
                txtSqlUser.Text = _config.SqlUser;
                txtSqlPassword.Text = _config.SqlPassword;

                // Select tab based on provider
                if (_config.Provider == "SqlServer")
                {
                    tabControl.SelectedTab = tabNetwork;
                }
                else
                {
                    tabControl.SelectedTab = tabLocal;
                }
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
                    // For Access: create connection factory, create connection, open to verify
                    string dbPath = testConfig.AccessDatabasePath;
                    if (string.IsNullOrEmpty(dbPath))
                    {
                        MessageBox.Show("请输入Access数据库路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // 转换为绝对路径
                    if (!System.IO.Path.IsPathRooted(dbPath) && _appDir != null)
                    {
                        dbPath = System.IO.Path.Combine(_appDir, dbPath);
                        testConfig.AccessDatabasePath = dbPath;
                    }

                    var factory = new AccessConnectionFactory(testConfig);
                    using (var connection = factory.CreateConnection())
                    {
                        connection.Open();
                    }
                    MessageBox.Show("Access连接成功！", "测试连接",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // For SQL Server: create connection factory, create connection, open to verify
                    var factory = new SqlConnectionFactory(testConfig);
                    using (var connection = factory.CreateConnection())
                    {
                        connection.Open();
                    }
                    MessageBox.Show("SQL Server连接成功！", "测试连接",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                // 确保配置文件目录存在
                string configDir = System.IO.Path.GetDirectoryName(_configPath);
                if (!string.IsNullOrEmpty(configDir) && !System.IO.Directory.Exists(configDir))
                {
                    System.IO.Directory.CreateDirectory(configDir);
                }

                // 如果使用Access且数据库文件不存在，自动创建数据库和表
                if (_config.Provider == "Access")
                {
                    string dbPath = _config.AccessDatabasePath;
                    // 转换为绝对路径
                    if (!System.IO.Path.IsPathRooted(dbPath) && _appDir != null)
                    {
                        dbPath = System.IO.Path.Combine(_appDir, dbPath);
                    }
                    bool isNewDb = !System.IO.File.Exists(dbPath);
                    if (isNewDb)
                    {
                        string dbDir = System.IO.Path.GetDirectoryName(dbPath);
                        if (!string.IsNullOrEmpty(dbDir) && !System.IO.Directory.Exists(dbDir))
                        {
                            System.IO.Directory.CreateDirectory(dbDir);
                        }
                        CreateAccessDatabase(dbPath, _config.AccessPassword);
                    }
                    // 模板数据库已包含所有表结构，无需额外创建
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

        /// <summary>
        /// 创建Access数据库文件（从模板复制）
        /// </summary>
        private void CreateAccessDatabase(string dbPath, string password)
        {
            try
            {
                var factory = new AccessConnectionFactory(_config);
                var initializer = new DatabaseInitializer(factory);
                initializer.CreateFromTemplate(dbPath);
            }
            catch (System.Exception ex)
            {
                throw new System.InvalidOperationException($"创建Access数据库失败: {ex.Message}", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Access数据库文件 (*.mdb)|*.mdb|所有文件 (*.*)|*.*";
                dlg.Title = "选择Access数据库文件";
                if (!string.IsNullOrEmpty(txtAccessPath.Text))
                {
                    try
                    {
                        dlg.InitialDirectory = System.IO.Path.GetDirectoryName(txtAccessPath.Text);
                    }
                    catch
                    {
                        // ignore
                    }
                }
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtAccessPath.Text = dlg.FileName;
                }
            }
        }

        private void btnCreateDb_Click(object sender, EventArgs e)
        {
            try
            {
                string dbDir = System.IO.Path.Combine(_appDir, "database");
                if (!System.IO.Directory.Exists(dbDir))
                {
                    System.IO.Directory.CreateDirectory(dbDir);
                }

                string dbPath = System.IO.Path.Combine(dbDir, "sc.mdb");
                const string password = "sss2014aw";

                if (System.IO.File.Exists(dbPath))
                {
                    var result = MessageBox.Show(
                        $"数据库文件已存在：{dbPath}\n\n是否覆盖？",
                        "确认覆盖",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                    System.IO.File.Delete(dbPath);
                }

                CreateAccessDatabase(dbPath, password);

                txtAccessPath.Text = dbPath;
                txtAccessPassword.Text = password;

                MessageBox.Show("数据库创建成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("创建数据库失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DatabaseConfig GetConfigFromFields()
        {
            string dbPath = txtAccessPath.Text.Trim();
            // 如果路径在应用程序目录下，存储为相对路径
            if (!string.IsNullOrEmpty(dbPath) && _appDir != null && dbPath.StartsWith(_appDir, StringComparison.OrdinalIgnoreCase))
            {
                dbPath = dbPath.Substring(_appDir.Length).TrimStart('\\', '/');
            }

            return new DatabaseConfig
            {
                Provider = tabControl.SelectedTab == tabNetwork ? "SqlServer" : "Access",
                AccessDatabasePath = dbPath,
                AccessPassword = txtAccessPassword.Text,
                SqlServerHost = txtSqlHost.Text.Trim(),
                SqlDatabase = txtSqlDatabase.Text.Trim(),
                SqlUser = txtSqlUser.Text.Trim(),
                SqlPassword = txtSqlPassword.Text
            };
        }
    }
}
