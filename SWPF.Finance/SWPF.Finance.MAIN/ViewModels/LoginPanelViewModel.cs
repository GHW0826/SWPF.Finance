using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWPF.Finance.MAIN.ViewModels
{
    public partial class LoginPanelViewModel : ObservableObject
    {
        [ObservableProperty]
        private string clientId;

        [ObservableProperty]
        private string password;

        public ICommand SetupCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand ExitCommand { get; }

        public LoginPanelViewModel()
        {
            SetupCommand = new DelegateCommand(OnSetup);
            LoginCommand = new DelegateCommand(OnLogin);
            ExitCommand = new DelegateCommand(OnExit);
        }

        private void OnSetup()
        {
            // Setup logic
        }

        private void OnLogin()
        {
            // Login logic
        }

        private void OnExit()
        {
            // Exit logic
        }
    }
}
