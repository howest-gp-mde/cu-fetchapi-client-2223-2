using Mde.FetchClient.Exceptions;
using Mde.FetchClient.Services.Abstract;
using Mde.FetchClient.Services.Implementation.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mde.FetchClient.Services.Implementation
{

    public class FetchApiClient : HttpClient, IApiClient
    {
        protected readonly ITokenHandler _tokenHandler;

        public FetchApiClient(ITokenHandler tokenHandler) 
        {
            _tokenHandler = tokenHandler;
            BaseAddress = new Uri(Constants.ApiBase);
        }

        private async Task AddAuthAsync()
        {
            string token = await _tokenHandler.GetToken();
            if(_tokenHandler.ValidateToken(token))
            {
                DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("BEARER", token);
            }
            else
            {
                DefaultRequestHeaders.Authorization = null;
            }
        }


        public void ThrowOnErrorCode(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                switch((int)response.StatusCode)
                {
                    case 403:
                        throw new ApplicationException("You have no power here!");

                    case 401:
                        throw new UnauthorizedApiException("Authorization failed");

                    case 404:
                        throw new ApplicationException("Not Found!");

                    case 422:
                        throw new ApplicationException("Validation error!");

                    default:
                        throw new ApplicationException("Unexpected response");
                }
            }
        }

        public async Task<HttpResponseMessage> PostCallApi<TIn>(string uri, TIn dto)
        {
            string json = JsonConvert.SerializeObject(dto);

            await AddAuthAsync();

            var response = await PostAsync(
                    uri,
                    new StringContent(json, Encoding.UTF8, "application/json"));

            return response;
        }

        public Task<HttpResponseMessage> DeleteCallApi(string uri)
        {
            throw new NotImplementedException();
        }

        Task<HttpResponseMessage> IApiClient.GetApiResult<Tin>(string uri)
        {
            throw new NotImplementedException();
        }


        public Task<HttpResponseMessage> PutCallApi<TIn>(string uri, TIn entity)
        {
            throw new NotImplementedException();
        }

    }
}
