using System;
using System.Windows;
using System.Windows.Interop;

namespace Windows11WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // 设置窗口初始位置到屏幕右下角
            PositionWindowToBottomRight();
            
            // 添加窗口激活事件，确保窗口始终在最前面
            Activated += MainWindow_Activated;
        }

        /// <summary>
        /// 设置窗口位置到屏幕右下角
        /// </summary>
        private void PositionWindowToBottomRight()
        {
            // 获取屏幕工作区大小（排除任务栏）
            System.Drawing.Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            
            // 计算窗口位置：右下角对齐，距离边缘8px
            Left = workingArea.Right - Width - 8;
            Top = workingArea.Bottom - Height - 8;
        }

        /// <summary>
        /// 窗口激活事件处理
        /// </summary>
        private void MainWindow_Activated(object sender, EventArgs e)
        {
            // 确保窗口始终在最前面
            Topmost = true;
            Topmost = false;
        }

        /// <summary>
        /// 窗口加载完成事件
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 再次调整窗口位置，确保在加载完成后位置正确
            PositionWindowToBottomRight();
        }

        /// <summary>
        /// 重写窗口关闭事件，改为隐藏窗口
        /// </summary>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // 取消关闭操作，改为隐藏窗口
            e.Cancel = true;
            Hide();
        }
    }
}