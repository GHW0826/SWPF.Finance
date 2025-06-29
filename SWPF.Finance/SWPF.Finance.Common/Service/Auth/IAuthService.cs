using SWPF.Finance.Common.Contracts.Auth;
using System.Threading.Tasks;

namespace SWPF.Finance.Common.Service.Auth
{
    public interface IAuthService
    {
        public Task<SignUpResponse> SignUpAsync(SignUpRequest request);
        public Task<SignInResponse> SignInAsync(SignInRequest request);
    }
}
