using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mde.FetchClient.Services.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<string>> GetUsers();

        Task<bool> Authenticate(string username, string password);

        Task Logout();
    }
}
