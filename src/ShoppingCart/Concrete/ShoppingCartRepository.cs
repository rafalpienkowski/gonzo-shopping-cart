using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Contract;
using ShoppingCart.Domain;

namespace ShoppingCart.Concrete
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        
        private readonly List<Cart> _db = new List<Cart>
        {
            new Cart(123, new List<Item>
            {
                new Item(1, "Basic T-shirt", "a quiet t-shirt", new Money(CurrencyType.Eur, 40)),
                new Item(2, "Fancy T-shirt", "a loud t-shirt", new Money(CurrencyType.Eur, 50)),
            })
        };
        
        public Cart Get(int userId)
        {
            return _db.FirstOrDefault(sc => sc.UserId.Equals(userId));
        }

        public void Save(Cart cart)
        {
            _db.Add(cart);
        }
    }
}