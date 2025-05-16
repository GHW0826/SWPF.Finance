using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPF.GameDevTool.Common.Network
{
    public class GrpcClient 
    {
        /*
        private ChannelBase _channel;
        private MyGrpcService.MyGrpcServiceClient _client;

        public async Task<bool> ConnectAsync(string address, int port)
        {
            _channel = GrpcChannel.ForAddress($"http://{address}:{port}");
            _client = new MyGrpcService.MyGrpcServiceClient(_channel);
            return true;
        }

        public async Task SendAsync(string message)
        {
            await _client.SendMessageAsync(new MyMessage { Content = message });
        }

        public async Task<string> ReceiveAsync() => "gRPC response not supported as stream";
        public async Task DisconnectAsync() => await _channel.ShutdownAsync();
        */
    }
}
