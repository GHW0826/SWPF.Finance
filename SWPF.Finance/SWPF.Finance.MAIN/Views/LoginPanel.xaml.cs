using Prism.Regions;
using SWPF.Finance.MAIN.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SWPF.Finance.MAIN.Views
{
    /// <summary>
    /// LoginPanel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPanel : UserControl
    {
        private readonly IRegionManager _regionManager;

        public LoginPanel(IRegionManager regionManager)
        {
            InitializeComponent();

            _regionManager = regionManager;
            var vm = DataContext as LoginPanelViewModel;
            if (vm != null)
            {
                vm.LoginSucceeded += OnLoginSucceeded;
            }
        }
        private void OnLoginSucceeded()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(LobbyPanel));
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            /*
            if (DataContext is ViewModels.LoginPanelViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
            */
        }
    }
}
