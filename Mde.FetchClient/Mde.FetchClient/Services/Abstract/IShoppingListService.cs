using System.Threading.Tasks;
using Mde.FetchClient.Entities;

namespace Mde.FetchClient.Services.Abstract
{
    public interface IShoppingListService
    {
        /// <param name="shopping"></param>
        /// <returns>a value > 0 if successful, 0 if failed</returns>
        Task<int> AddShoppingList(ShoppingList shopping);

        Task<bool> ShareShoppingList(int shoppingListId, string associateUserName);
    }
}
