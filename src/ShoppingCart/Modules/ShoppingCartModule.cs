using Nancy;
using Nancy.ModelBinding;
using ShoppingCart.Contract;
using ShoppingCart.Domain;

namespace ShoppingCart.Modules
{
    public class ShoppingCartModule : NancyModule
    {
        public ShoppingCartModule(IShoppingCartRepository shoppingCartRepository, IProductCatalogClient productCatalogClient, IEventStore eventStore) : base("/shoppingcart")
        {
            
            Get("/{userid:int}", parameters =>
            {
                var userId = (int) parameters.userid;
                return shoppingCartRepository.Get(userId);
            });
            
            Post("/{userid:int}/items", async (parameters, _) =>
            {
                var userId = (int) parameters.userid;
                var productCatalogIds = this.Bind<int[]>();

                var cart = shoppingCartRepository.Get(userId);
                var cartItems = await productCatalogClient.GetProductCartItemsAsync(productCatalogIds);

                cart.AddItems(cartItems, eventStore);

                shoppingCartRepository.Save(cart);
                return new Response
                {
                    StatusCode = HttpStatusCode.Created
                };
            });
            
            Delete("/{userid:int}/items", parameters =>
            {
                var userId = (int) parameters.userid;
                var productCatalogIds = this.Bind<int[]>();
                
                var cart = shoppingCartRepository.Get(userId);
                cart.RemoveItems(productCatalogIds, eventStore);
                
                shoppingCartRepository.Save(cart);
                return new Response
                {
                    StatusCode = HttpStatusCode.Accepted
                };
            });
        }
    }
}