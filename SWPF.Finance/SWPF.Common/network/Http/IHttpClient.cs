using System.Threading.Tasks;

namespace SWPF.Common.Network.Http
{
    public interface IHttpClient
    {
        Task<T> GetAsync<T>(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request);
    }
}
