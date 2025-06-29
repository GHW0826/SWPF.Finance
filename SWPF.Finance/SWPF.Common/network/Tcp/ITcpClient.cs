using System.Threading.Tasks;

namespace SWPF.Common.Network.Tcp
{
    public interface ITcpClient
    {
        Task ConnectAsync(string host, int port);
        Task SendAsync(byte[] data);
        Task<byte[]> ReceiveAsync();
        Task DisconnectAsync();
    }
}
