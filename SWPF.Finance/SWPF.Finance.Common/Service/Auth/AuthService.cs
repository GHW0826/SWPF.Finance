using SWPF.Common.Network.Http;
using SWPF.Finance.MAIN.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return _httpClient.PostAsync<SignInRequest, SignInResponse>("/auth/signin", request);
        }
    }
}
