using LyraDesk.App.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LyraDesk.App.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Wire up window control buttons from the custom template
            var minimizeButton = (Button)Template.FindName("MinimizeButton", this);
            var maximizeButton = (Button)Template.FindName("MaximizeButton", this);
            var closeButton = (Button)Template.FindName("CloseButton", this);

            if (minimizeButton != null)
                minimizeButton.Click += MinimizeButton_Click;

            if (maximizeButton != null)
                maximizeButton.Click += MaximizeButton_Click;

            if (closeButton != null)
                closeButton.Click += CloseButton_Click;

            // Wire up title bar drag
            var titleBar = (Border)Template.FindName("TitleBar", this);
            if (titleBar != null)
                titleBar.MouseLeftButtonDown += TitleBar_MouseLeftButtonDown;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                // Double-click to maximize/restore
                MaximizeButton_Click(sender, e);
            }
            else
            {
                // Single-click to drag
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}