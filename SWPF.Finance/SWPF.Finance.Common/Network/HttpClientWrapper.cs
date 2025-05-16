using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SWPF.GameDevTool.Common.Network
{
    public class HttpClientWrapper : INetworkClient
    {
        private HttpClient _httpClient;

        public async Task<bool> ConnectAsync(string address, int port)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri($"http://{address}:{port}/") };
            return true;
        }

        public async Task SendAsync(string message)
        {
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/send", content);
        }

        public async Task<string> ReceiveAsync() => "HTTP polling not implemented";
        public async Task DisconnectAsync() => _httpClient.Dispose();
    }
}
