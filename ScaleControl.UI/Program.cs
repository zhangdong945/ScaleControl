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

            // 检查数据库配置文件是否存在
            string configPath = "settings/dbsettings.xml";
            if (!System.IO.File.Exists(configPath))
            {
                // 配置文件不存在，显示数据库配置窗口
                splash.Hide();
                splash.Dispose();
                using (var dbConfigForm = new frmDatabaseConfig(configPath))
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

            // 初始化数据库连接
            IDatabaseConnectionFactory connFactory = dbConfig.Provider == "Access"
                ? new AccessConnectionFactory(dbConfig)
                : (IDatabaseConnectionFactory)new SqlConnectionFactory(dbConfig);

            var dbInit = new DatabaseInitializer(connFactory);
            if (!dbInit.TestConnection())
            {
                MessageBox.Show("数据库连接失败，请检查配置", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 初始化数据库表（如果不存在）
            dbInit.Initialize();

            // 创建仓储
            var repository = new WeighingRepository(connFactory);

            // 加载硬件配置并创建仪表驱动
            var scaleConfigs = HardwareConfigLoader.Load("settings/hardware.xml");
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
