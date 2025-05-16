using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPF.Finance.Common.Network
{
    public interface INetworkClient
    {
        Task<bool> ConnectAsync(string address, int port);
        Task SendAsync(string message);
        Task<string> ReceiveAsync();
        Task DisconnectAsync();
    }
}
