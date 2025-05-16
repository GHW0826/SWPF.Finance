using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SWPF.GameDevTool.Common.Network
{
    public class TcpClientWrapper : INetworkClient
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public async Task<bool> ConnectAsync(string address, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(address, port);
            _stream = _client.GetStream();
            return true;
        }

        public async Task SendAsync(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<string> ReceiveAsync()
        {
            var buffer = new byte[4096];
            var len = await _stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, len);
        }

        public async Task DisconnectAsync() => _client.Close();
    }

}
