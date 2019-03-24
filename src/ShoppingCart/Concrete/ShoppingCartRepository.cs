using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Contract;

namespace ShoppingCart.Concrete
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        
        private List<Cart> _db = new List<Cart>
        {
            new Cart
            {
                UserId = 123,
                Items = new List<Item>
                {
                    new Item
                    {
                        ProductCatalogId = 1,
                        ProductName = "Basic T-shirt",
                        Description = "a quiet t-shirt",
                        Price = new Money(CurrencyType.Eur, 40)
                    },
                    new Item
                    {
                        ProductCatalogId = 2,
                        ProductName = "Fancy T-shirt",
                        Description = "a loud t-shirt",
                        Price = new Money(CurrencyType.Eur, 50)
                    }
                }
            },
            new Cart()
        };
        
        public Cart Get(int userId)
        {
            return _db.FirstOrDefault(sc => sc.UserId.Equals(userId));
        }
    }
}