using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Commands;
using SWPF.Finance.Common.Contracts.Auth;
using SWPF.Finance.MAIN.Service.LoginPanel;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWPF.Finance.MAIN.ViewModels
{
    public partial class LoginPanelViewModel : ObservableObject
    {

        private readonly ILoginPanelService _loginPanelService;

        public event Action LoginSucceeded;

        public ICommand SetupCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand ExitCommand { get; }

        public LoginPanelViewModel(ILoginPanelService loginPanelService)
        {
           _loginPanelService = loginPanelService;

            SetupCommand = new DelegateCommand(OnSetup);
            LoginCommand = new DelegateCommand(OnLogin);
            ExitCommand = new DelegateCommand(OnExit);
        }

        public async Task LoginAsync()
        {
            var request = new SignInRequest
            {
                ClientId = "test",
                Password = "testtest"
            };
            LoginSucceeded?.Invoke();

            /*
            var response = await _loginPanelService.SignInAsync(request);

            if (!string.IsNullOrEmpty(response?.AcceccToken))
            {
                // 로그인 성공 처리
                LoginSucceeded?.Invoke();
            }
            */
        }

        private void OnSetup()
        {
            // Setup logic
        }

        private async void OnLogin()
        {
            // Login logic
            await LoginAsync();
        }

        private void OnExit()
        {
            // Exit logic
        }
    }
}
