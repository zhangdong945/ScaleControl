using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScaleControl.UI.Controls
{
    public class MenuItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ParentId { get; set; }
        public Image Icon { get; set; }
    }

    public class MenuBarControl : UserControl
    {
        private Panel bottomPanel;
        private Panel topPanel;
        private Dictionary<string, List<MenuItem>> menuGroups;
        private string currentCategoryId;

        public event EventHandler<MenuItem> MenuItemClicked;

        public MenuBarControl()
        {
            InitializeComponent();
            LoadMenuData();
            BuildMenu();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Left;
            this.Width = 200;
            this.BackColor = Color.FromArgb(50, 50, 60);

            bottomPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 240,
                BackColor = Color.FromArgb(40, 40, 50)
            };

            topPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(50, 50, 60),
                AutoScroll = true,
                Padding = new Padding(5)
            };

            this.Controls.Add(topPanel);
            this.Controls.Add(bottomPanel);
        }

        private void LoadMenuData()
        {
            menuGroups = new Dictionary<string, List<MenuItem>>();

            var basicCategory = new MenuItem { Id = "cat_basic", Title = "基础功能", ParentId = null };
            var reportCategory = new MenuItem { Id = "cat_report", Title = "报表查询", ParentId = null };
            var systemCategory = new MenuItem { Id = "cat_system", Title = "系统设置", ParentId = null };
            var helpCategory = new MenuItem { Id = "cat_help", Title = "帮助", ParentId = null };

            menuGroups[basicCategory.Id] = new List<MenuItem>
            {
                new MenuItem { Id = "m_weigh", Title = "称重", ParentId = basicCategory.Id },
                new MenuItem { Id = "m_tare", Title = "皮重管理", ParentId = basicCategory.Id },
                new MenuItem { Id = "m_truck", Title = "车号管理", ParentId = basicCategory.Id }
            };

            menuGroups[reportCategory.Id] = new List<MenuItem>
            {
                new MenuItem { Id = "m_report_weigh", Title = "称重记录", ParentId = reportCategory.Id },
                new MenuItem { Id = "m_report_daily", Title = "日报表", ParentId = reportCategory.Id },
                new MenuItem { Id = "m_report_monthly", Title = "月报表", ParentId = reportCategory.Id }
            };

            menuGroups[systemCategory.Id] = new List<MenuItem>
            {
                new MenuItem { Id = "m_sys_config", Title = "系统配置", ParentId = systemCategory.Id },
                new MenuItem { Id = "m_sys_user", Title = "用户管理", ParentId = systemCategory.Id },
                new MenuItem { Id = "m_sys_device", Title = "设备管理", ParentId = systemCategory.Id }
            };

            menuGroups[helpCategory.Id] = new List<MenuItem>
            {
                new MenuItem { Id = "m_help_about", Title = "关于", ParentId = helpCategory.Id }
            };
        }

        private void BuildMenu()
        {
            bottomPanel.Controls.Clear();

            int buttonIndex = 0;
            foreach (var group in menuGroups)
            {
                var categoryId = group.Key;
                var items = group.Value;
                if (items.Count == 0) continue;

                var categoryItem = GetCategoryById(categoryId);
                if (categoryItem == null) continue;

                var btn = new Button
                {
                    Text = categoryItem.Title,
                    Width = 180,
                    Height = 50,
                    Left = 10,
                    Top = 10 + buttonIndex * 55,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(60, 60, 80),
                    ForeColor = Color.White,
                    Font = new Font("微软雅黑", 11),
                    Tag = categoryId
                };
                btn.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 100);
                btn.Click += CategoryButton_Click;

                bottomPanel.Controls.Add(btn);
                buttonIndex++;
            }
        }

        private MenuItem GetCategoryById(string id)
        {
            foreach (var group in menuGroups)
            {
                foreach (var item in group.Value)
                {
                    if (item.Id == id) return item;
                }
            }

            if (id == "cat_basic") return new MenuItem { Id = "cat_basic", Title = "基础功能" };
            if (id == "cat_report") return new MenuItem { Id = "cat_report", Title = "报表查询" };
            if (id == "cat_system") return new MenuItem { Id = "cat_system", Title = "系统设置" };
            if (id == "cat_help") return new MenuItem { Id = "cat_help", Title = "帮助" };
            return null;
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            currentCategoryId = btn.Tag as string;
            ShowSubMenu(currentCategoryId);
        }

        private void ShowSubMenu(string categoryId)
        {
            topPanel.Controls.Clear();

            if (!menuGroups.ContainsKey(categoryId)) return;

            var items = menuGroups[categoryId];
            int itemIndex = 0;

            foreach (var item in items)
            {
                var itemPanel = new Panel
                {
                    Width = this.Width - 20,
                    Height = 40,
                    Left = 5,
                    Top = 5 + itemIndex * 45,
                    BackColor = Color.FromArgb(55, 55, 70),
                    Cursor = Cursors.Hand,
                    Tag = item
                };

                var lbl = new Label
                {
                    Text = "  " + item.Title,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ForeColor = Color.White,
                    Font = new Font("微软雅黑", 10)
                };

                itemPanel.Controls.Add(lbl);
                itemPanel.Click += SubMenuItem_Click;
                foreach (Control c in itemPanel.Controls)
                    c.Click += SubMenuItem_Click;

                topPanel.Controls.Add(itemPanel);
                itemIndex++;
            }
        }

        private void SubMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            MenuItem item = null;

            while (ctrl != null)
            {
                if (ctrl.Tag is MenuItem)
                {
                    item = ctrl.Tag as MenuItem;
                    break;
                }
                ctrl = ctrl.Parent;
            }

            if (item != null)
            {
                MenuItemClicked?.Invoke(this, item);
            }
        }
    }
}
