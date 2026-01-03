using System;
using System.Windows;
using System.Windows.Forms;
using NotifyIcon = System.Windows.Forms.NotifyIcon;
using ContextMenuStrip = System.Windows.Forms.ContextMenuStrip;
using ToolStripMenuItem = System.Windows.Forms.ToolStripMenuItem;
using System.Drawing;

namespace Windows11WpfApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        // 系统托盘图标
        private NotifyIcon _notifyIcon;
        // 主窗口实例
        private MainWindow _mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 初始化系统托盘图标
            InitializeNotifyIcon();

            // 创建主窗口但不显示
            _mainWindow = new MainWindow();
        }

        /// <summary>
        /// 初始化系统托盘图标
        /// </summary>
        private void InitializeNotifyIcon()
        {
            // 创建上下文菜单
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("退出");
            exitMenuItem.Click += ExitMenuItem_Click;
            contextMenu.Items.Add(exitMenuItem);

            // 创建托盘图标
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "Windows 11 WPF App";
            _notifyIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            _notifyIcon.ContextMenuStrip = contextMenu;
            _notifyIcon.MouseClick += NotifyIcon_MouseClick;
            _notifyIcon.Visible = true;
        }

        /// <summary>
        /// 托盘图标鼠标点击事件
        /// </summary>
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // 左键点击显示/隐藏主窗口
            if (e.Button == MouseButtons.Left)
            {
                if (_mainWindow.IsVisible)
                {
                    _mainWindow.Hide();
                }
                else
                {
                    _mainWindow.Show();
                    _mainWindow.Activate();
                }
            }
        }

        /// <summary>
        /// 退出菜单项点击事件
        /// </summary>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            Shutdown();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            base.OnExit(e);
        }
    }
}