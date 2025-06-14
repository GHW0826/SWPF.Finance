using SWPF.Finance.MAIN.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPF.Finance.Common.Service.Auth
{
    public interface IAuthService
    {
        public Task<SignUpResponse> SignUpAsync(SignUpRequest request);
        public Task<SignInResponse> SignInAsync(SignInRequest request);
    }
}
