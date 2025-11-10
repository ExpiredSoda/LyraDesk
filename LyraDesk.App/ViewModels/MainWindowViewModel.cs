using System;
using System.ComponentModel;
using System.Runtime.CompilerServices; 
using System.Windows;
using System.Windows.Input;
using LyraDesk.App.Commands;

namespace LyraDesk.App.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        // Status Bar
        private string _status = "Online";
        private string _selectedProgram = "--";
        private string _currentUser = "--";

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedProgram
        {
            get => _selectedProgram;
            set
            {
                if (_selectedProgram != value)
                {
                    _selectedProgram = value;
                    OnPropertyChanged();
                    UpdateDashboard();
                }
            }
        }

        public string CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged();
                }
            }
        }

        // Dashboard Properties
        private string _dashboardTitle = "Welcome to LyraDesk";
        private string _dashboardSubtitle = "Select a program to begin.";
        private string? _dashboardBackgroundImage = null;
        private int _totalCases = 0;
        private int _openCases = 0;

        public string DashboardTitle
        {
            get => _dashboardTitle;
            set
            {
                if (_dashboardTitle != value)
                {
                    _dashboardTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DashboardSubtitle
        {
            get => _dashboardSubtitle;
            set
            {
                if (_dashboardSubtitle != value)
                {
                    _dashboardSubtitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? DashboardBackgroundImage
        {
            get => _dashboardBackgroundImage;
            set
            {
                if (_dashboardBackgroundImage != value)
                {
                    _dashboardBackgroundImage = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TotalCases
        {
            get => _totalCases;
            set
            {
                if (_totalCases != value)
                {
                    _totalCases = value;
                    OnPropertyChanged();
                }
            }
        }

        public int OpenCases
        {
            get => _openCases;
            set
            {
                if (_openCases != value)
                {
                    _openCases = value;
                    OnPropertyChanged();
                }
            }
        }
        
        // File Menu Commands
        public ICommand NewWindowCommand { get; }
        public ICommand ProfileCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ExitCommand { get; }

        // Program Menu Commands
        public ICommand ChooseProgramCommand { get; }

        // View Menu Commands
        public ICommand ToggleThemeCommand { get; }

        // Settings Menu Commands
        public ICommand OpenSettingsCommand { get; }

        // Help Menu Commands
        public ICommand OpenHelpCommand { get; }
        public ICommand AboutCommand { get; }

        public MainWindowViewModel()
        {
            // Initialize commands with implementations
            NewWindowCommand = new SimpleRelayCommand(NewWindow);
            ProfileCommand = new SimpleRelayCommand(OpenProfile);
            LoginCommand = new SimpleRelayCommand(Login);
            LogoutCommand = new SimpleRelayCommand(Logout);
            ExitCommand = new SimpleRelayCommand(Exit);
            ChooseProgramCommand = new SimpleRelayCommand(ChooseProgram);
            ToggleThemeCommand = new SimpleRelayCommand(ToggleTheme);
            OpenSettingsCommand = new SimpleRelayCommand(OpenSettings);
            OpenHelpCommand = new SimpleRelayCommand(OpenHelp);
            AboutCommand = new SimpleRelayCommand(ShowAbout);
        }

        // Command Implementations

        private void NewWindow()
        {
            // Create a new window instance
            var newWindow = new Views.MainWindow();
            newWindow.Show();
        }

        private void OpenProfile()
        {
            MessageBox.Show("Profile window coming soon!", "LyraDesk", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Login()
        {
            MessageBox.Show("Login dialog coming soon!", "LyraDesk", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Logout()
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?", 
                "Logout", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                CurrentUser = "--";
                MessageBox.Show("Logged out successfully!", "LyraDesk", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void ChooseProgram()
        {
            MessageBox.Show("Choose Program functionality coming soon!", "LyraDesk", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OpenSettings()
        {
            MessageBox.Show("Settings window coming soon!", "LyraDesk", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ToggleTheme()
        {
            MessageBox.Show("Theme toggle coming soon!", "LyraDesk", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OpenHelp()
        {
            MessageBox.Show("Help documentation coming soon!", "LyraDesk", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowAbout()
        {
            MessageBox.Show(
                "LyraDesk - Desktop Application\n\nVersion 1.0.0\n\n© 2025", 
                "About LyraDesk", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }

        private void UpdateDashboard()
        {
            // Default state - no program selected
            if (SelectedProgram == "--" || string.IsNullOrWhiteSpace(SelectedProgram))
            {
                DashboardTitle = "Welcome to LyraDesk";
                DashboardSubtitle = "Select a program to begin.";
                DashboardBackgroundImage = null;
                TotalCases = 0;
                OpenCases = 0;
            }
            else
            {
                // Program selected - update with program-specific data
                DashboardTitle = $"{SelectedProgram} Dashboard";
                DashboardSubtitle = $"Overview of {SelectedProgram} activities.";

                // TODO: Load actual background image from program settings
                // DashboardBackgroundImage = programSettings.BackgroundImagePath;

                // TODO: Load actual case counts from database
                // TotalCases = _caseService.GetTotalCases(SelectedProgram);
                // OpenCases = _caseService.GetOpenCases(SelectedProgram);

                // Placeholder values for now
                TotalCases = 0;
                OpenCases = 0;
            }

        }

        // INotifyPropertyChanged Code
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}