using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Mde.FetchClient.Services.Abstract;
using Xamarin.Essentials;

namespace Mde.FetchClient.Services.Implementation
{
    public class TokenHandler : ITokenHandler
    {
        const string tokenKey = "AUTHTOKEN";

        public Task<string> GetToken() 
            => SecureStorage.GetAsync(tokenKey);

        public async Task SaveToken(string token)
        {
            if (token == null)
                SecureStorage.Remove(tokenKey);
            else
                await SecureStorage.SetAsync(tokenKey, token);
        }
        
        public bool ValidateToken(string token)
        {
            if (token == null)
                return false;

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(token);

            return
                securityToken.ValidTo.ToUniversalTime() >= DateTime.UtcNow &&
                securityToken.ValidFrom.ToUniversalTime() <= DateTime.UtcNow;
        }
    }
}
