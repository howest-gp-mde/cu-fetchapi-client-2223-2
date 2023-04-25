using System.Threading.Tasks;

namespace Mde.FetchClient.Services.Abstract
{
    public interface ITokenHandler
    {
        bool ValidateToken(string token);

        Task<string> GetToken();

        Task SaveToken(string token);
    }
}
