using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPF.Finance.MAIN.Dto.Auth
{
    public class SignUpRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
