using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWPF.Finance.MAIN.ViewModels
{
    public class AppInfo
    {
        public string Title { get; set; }
        public string Tag { get; set; }
    }

    public partial class LobbyPanelViewModel : ObservableObject
    {
        public ObservableCollection<AppInfo> Apps { get; }

        public event Action<string> AppSelected;

        public ICommand AppClickCommand { get; }

        public LobbyPanelViewModel()
        {
            AppClickCommand = new RelayCommand<string>(OnAppClick);

            Apps = new ObservableCollection<AppInfo>
            {
                new AppInfo { Title = "Product", Tag = "Product" },
                new AppInfo { Title = "Booking", Tag = "Booking" },
                new AppInfo { Title = "Trade", Tag = "Trade" },
                new AppInfo { Title = "Test", Tag = "Test"},
            };
        }

        private void OnAppClick(string appType)
        {
            AppSelected?.Invoke(appType);
        }
    }
}
