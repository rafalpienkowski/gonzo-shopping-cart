using ShoppingCart.Contract;

namespace ShoppingCart.Domain
{
    public class Item
    {
        public int ProductCatalogId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }

        public Item(int productCatalogId, string productName, string description, Money price)
        {
            ProductCatalogId = productCatalogId;
            ProductName = productName;
            Description = description;
            Price = price;
        }
    }
}