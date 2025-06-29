using SWPF.Finance.Common.Contracts.Auth;
using System.Threading.Tasks;

namespace SWPF.Finance.MAIN.Service.LoginPanel
{
    public interface ILoginPanelService
    {

        Task<SignInResponse> SignInAsync(SignInRequest request);
        Task<SignUpResponse> SignUpAsync(SignUpRequest request);
    }
}
