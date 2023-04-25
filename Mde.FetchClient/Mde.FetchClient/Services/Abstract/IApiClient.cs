using System.Net.Http;
using System.Threading.Tasks;

namespace Mde.FetchClient.Services.Abstract
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> DeleteCallApi(string uri);
        Task<HttpResponseMessage> GetApiResult<Tin>(string uri);
        Task<HttpResponseMessage> PostCallApi<TIn>(string uri, TIn entity);
        Task<HttpResponseMessage> PutCallApi<TIn>(string uri, TIn entity);

        void ThrowOnErrorCode(HttpResponseMessage response);
    }
}
