using SWPF.Common.Network.Http;
using SWPF.Finance.Common.Contracts.Auth;
using System.Threading.Tasks;

namespace SWPF.Finance.Common.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClient _httpClient;

        public AuthService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<SignUpResponse> SignUpAsync(SignUpRequest request)
        {
            return _httpClient.PostAsync<SignUpRequest, SignUpResponse>("/auth/signup", request);
        }

        public Task<SignInResponse> SignInAsync(SignInRequest request)
        {
            var result = _httpClient.PostAsync<SignInRequest, SignInResponse>("/auth/signin", request);
            return result;
        }
    }
}
