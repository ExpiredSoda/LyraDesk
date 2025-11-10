using LyraDesk.App.ViewModels.NavigationPanel;
using System.Windows.Controls;

namespace LyraDesk.App.Views.NavigationPanel
{
    public partial class NavigationPanel : UserControl
    {
        public NavigationPanel()
        {
            InitializeComponent();
            DataContext = new NavigationPanelViewModel();
        }
    }
}
