using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mde.FetchClient.Entities;
using Mde.FetchClient.Services.Abstract;
using Mde.FetchClient.Services.Implementation.Models;
using Newtonsoft.Json;

namespace Mde.FetchClient.Services.Implementation
{
    public class ShoppingListApiService : IShoppingListService
    {
        protected readonly ITokenHandler _tokenHandler;
        protected readonly IApiClient _client;

        public ShoppingListApiService(ITokenHandler tokenHandler, IApiClient client)
        {
            _tokenHandler = tokenHandler;
            _client = client;
        }

        public async Task<int> AddShoppingList(ShoppingList shopping)
        {
            var dto = new AddShoppingListRequest
            {
                Title = shopping.Name,
                Color = shopping.Color.ToHex()
            };

            var response = await _client.PostCallApi("v1/shoppinglists", dto);

            if (response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync();
                return int.Parse(text);
            }

            _client.ThrowOnErrorCode(response);
            return default;
        }

        public async Task<bool> ShareShoppingList(int shoppingListId, string associateUserName)
        {
            var dto = new ShareShoppingListRequest
            {
                Id = shoppingListId,
                AssociateUserName = associateUserName
            };

            var response = await _client.PostCallApi<ShareShoppingListRequest>(
                    $"v1/shoppinglists/{shoppingListId}/share", dto);

            _client.ThrowOnErrorCode(response);

            return response.IsSuccessStatusCode;
        }
    }
}
