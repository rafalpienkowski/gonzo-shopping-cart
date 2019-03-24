using Nancy;
using ShoppingCart.Contract;

namespace ShoppingCart.Modules
{
    public class ShoppingCartModule : NancyModule
    {
        public ShoppingCartModule(IShoppingCartRepository shoppingCartRepository) : base("/shoppingcart")
        {
            
            Get("/{userid:int}", parameters =>
            {
                var userId = (int) parameters.userid;
                return shoppingCartRepository.Get(userId);
            });
        }
    }
}