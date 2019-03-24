using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCart.Domain;

namespace ShoppingCart.Contract
{
    public interface IProductCatalogClient
    {
        Task<IEnumerable<Item>> GetProductCartItemsAsync(IEnumerable<int> productCatalogIds);
    }
}