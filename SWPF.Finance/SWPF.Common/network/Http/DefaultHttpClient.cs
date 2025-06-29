using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWPF.Common.Network.Http
{
    public class DefaultHttpClient : IHttpClient
    {
        private readonly HttpClient _client;

        public DefaultHttpClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://127.0.0.1:8888/");
            _client.Timeout = TimeSpan.FromSeconds(30); // 기본 Timeout
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            /*
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseJson);
            */

            try
            {
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(url, content);

                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TResponse>(responseJson);

                if (result == null)
                    throw new InvalidOperationException("Failed to deserialize response.");

                return result;
            }
            catch (Exception ex)
            {
                // 기타 예외
                Console.WriteLine($"Unhandled error: {ex.Message}");
                throw;
            }
        }

        public async Task<string> GetStringAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
