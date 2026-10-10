using System;
using System.Windows.Forms;
using ScaleControl.Data;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;
using ScaleControl.Hardware;

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

            // 加载数据库配置
            var dbConfig = DatabaseConfigLoader.Load("settings/dbsettings.xml");

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

            // 加载硬件配置
            var scaleConfigs = HardwareConfigLoader.Load("settings/hardware.xml");

            // 显示登录窗口
            splash.Hide();
            var login = new frmLogin(connFactory);
            if (login.ShowDialog() != DialogResult.OK) return;

            // 显示主界面
            Application.Run(new frmMain(connFactory, scaleConfigs, login.CurrentUser));
        }
    }
}
