using System;
using System.Windows.Forms;
using ScaleControl.Data;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;
using ScaleControl.Core;
using ScaleControl.Hardware;
using ScaleControl.UI.Forms;

namespace ScaleControl.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 显示启动画面
            var splash = new frmSplash();
            splash.Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);

            // 设置文件位于应用程序目录下的settings文件夹
            string appDir = Application.StartupPath;
            string configPath = System.IO.Path.Combine(appDir, "settings", "dbsettings.xml");
            string hardwareConfigPath = System.IO.Path.Combine(appDir, "settings", "hardware.xml");

            if (!System.IO.File.Exists(configPath))
            {
                // 配置文件不存在，显示数据库配置窗口
                splash.Hide();
                splash.Dispose();
                using (var dbConfigForm = new frmDatabaseConfig(configPath, appDir))
                {
                    if (dbConfigForm.ShowDialog() != DialogResult.OK)
                        return;
                }
                splash = new frmSplash();
                splash.Show();
                Application.DoEvents();
            }

            // 加载数据库配置
            var dbConfig = DatabaseConfigLoader.Load(configPath);

            // 根据启用标志确定连接哪个数据库
            bool useLocalDb = dbConfig.EnableLocalDb && !dbConfig.EnableSqlServer;
            bool useSqlServer = dbConfig.EnableSqlServer && !dbConfig.EnableLocalDb;

            // 如果两个都启用或都没启用，默认使用本地数据库
            if (useLocalDb == useSqlServer)
            {
                useLocalDb = true;
                useSqlServer = false;
            }

            // 将相对路径转换为绝对路径（基于应用程序目录）
            if (!System.IO.Path.IsPathRooted(dbConfig.AccessDatabasePath))
            {
                dbConfig.AccessDatabasePath = System.IO.Path.Combine(appDir, dbConfig.AccessDatabasePath);
            }

            // 初始化数据库连接
            IDatabaseConnectionFactory connFactory;
            if (useSqlServer)
            {
                connFactory = new SqlConnectionFactory(dbConfig);
            }
            else
            {
                connFactory = new AccessConnectionFactory(dbConfig);
            }

            var dbInit = new DatabaseInitializer(connFactory);
            if (!dbInit.TestConnection())
            {
                MessageBox.Show("数据库连接失败，请检查配置", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (useSqlServer)
            {
                dbInit.CreateSqlServerDatabase(dbConfig.SqlServerHost, dbConfig.SqlDatabase, dbConfig.SqlUser, dbConfig.SqlPassword);
            }

            // 创建仓储
            var repository = new WeighingRepository(connFactory);

            // 加载硬件配置并创建仪表驱动
            var scaleConfigs = HardwareConfigLoader.Load(hardwareConfigPath);
            var scaleConfig = scaleConfigs.Count > 0 ? scaleConfigs[0] : new ScaleConnectionConfig();
            var scaleDriver = ScaleDriverFactory.CreateDriver(scaleConfig);

            // 创建工作流
            var workflow = new WeighingWorkflow(repository, scaleDriver, new AntiCheatConfig(), "01");

            // 显示登录窗口
            splash.Hide();
            splash.Dispose();
            var login = new frmLogin(repository);
            if (login.ShowDialog() != DialogResult.OK) return;

            // 显示主界面
            Application.Run(new frmMain(workflow, repository, login.CurrentUser));
        }
    }
}
