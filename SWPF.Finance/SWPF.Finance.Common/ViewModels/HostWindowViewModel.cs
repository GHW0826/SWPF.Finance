using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace SWPF.Finance.Common.ViewModels
{
    public partial class HostWindowViewModel : ObservableObject
    {
        public event Action RequestClose;

        public ICommand CloseCommand { get; }

        public HostWindowViewModel()
        {
            CloseCommand = new RelayCommand(OnClose);
        }

        private void OnClose()
        {
            RequestClose?.Invoke();
        }

    }
}
