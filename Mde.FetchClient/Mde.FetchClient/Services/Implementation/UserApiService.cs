using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mde.FetchClient.Services.Abstract;
using Mde.FetchClient.Services.Implementation.Models;
using Newtonsoft.Json;

namespace Mde.FetchClient.Services.Implementation
{

    public class UserApiService : IUserService
    {
        protected readonly ITokenHandler _tokenHandler;
        protected readonly IApiClient _client;

        public UserApiService(ITokenHandler tokenHandler, IApiClient client)
        {
            _tokenHandler = tokenHandler;
            _client = client;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var dto = new AuthenticationRequest
            {
                UserName = username,
                Password = password,
            };

            var response = await _client.PostCallApi("v1/users/authenticate", dto);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuthenticationResult>(json);

                //save token!
                await _tokenHandler.SaveToken(result.Token);
                return true;
            }

            _client.ThrowOnErrorCode(response);

            return false;
        }

        public Task Logout()
        {
            return _tokenHandler.SaveToken(null);
        }

        public Task<IEnumerable<string>> GetUsers()
        {
            throw new System.NotImplementedException();
        }

    }
}
