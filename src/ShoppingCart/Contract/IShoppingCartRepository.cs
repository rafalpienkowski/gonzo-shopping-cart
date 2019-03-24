using ShoppingCart.Domain;

namespace ShoppingCart.Contract
{
    public interface IShoppingCartRepository
    {
        Cart Get(int userId);
        void Save(Cart cart);
    }
}