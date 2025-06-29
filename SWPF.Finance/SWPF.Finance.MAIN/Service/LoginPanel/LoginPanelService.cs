using SWPF.Finance.Common.Contracts.Auth;
using SWPF.Finance.Common.Service.Auth;
using System.Threading.Tasks;

namespace SWPF.Finance.MAIN.Service.LoginPanel
{
    public class LoginPanelService : ILoginPanelService
    {
        private readonly IAuthService _authService;

        public LoginPanelService(IAuthService authService)
        {
            _authService = authService;
        }

        public Task<SignInResponse> SignInAsync(SignInRequest request)
        {
            return _authService.SignInAsync(request);
        }

        public Task<SignUpResponse> SignUpAsync(SignUpRequest request)
        {
            return _authService.SignUpAsync(request);
        }
    }
}
