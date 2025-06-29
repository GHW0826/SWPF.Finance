using System;
using System.Threading;
using System.Threading.Tasks;

namespace SWPF.Common.Network.WebSocket
{
    public interface IWebSocketClient
    {
        Task ConnectAsync(Uri uri, CancellationToken cancellationToken);
        Task SendAsync(string message);
        Task<string> ReceiveAsync();
        Task CloseAsync();
    }

}
