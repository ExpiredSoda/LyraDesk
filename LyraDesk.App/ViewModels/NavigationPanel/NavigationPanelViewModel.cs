using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LyraDesk.App.Commands;

namespace LyraDesk.App.ViewModels.NavigationPanel
{
    public class NavigationPanelViewModel : INotifyPropertyChanged
    {
        private bool _isExpanded = true;
        private double _navigationWidth = 150;
        private string _toggleButtonContent = "◀";

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                    NavigationWidth = value ? 85 : 0;
                    ToggleButtonContent = value ? "◀" : "▶";
                }
            }
        }

        public double NavigationWidth
        {
            get => _navigationWidth;
            set
            {
                if (_navigationWidth != value)
                {
                    _navigationWidth = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ToggleButtonContent
        {
            get => _toggleButtonContent;
            set
            {
                if (_toggleButtonContent != value)
                {
                    _toggleButtonContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleNavigationCommand { get; }

        public NavigationPanelViewModel()
        {
            ToggleNavigationCommand = new SimpleRelayCommand(ToggleNavigation);
        }

        private void ToggleNavigation()
        {
            IsExpanded = !IsExpanded;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}