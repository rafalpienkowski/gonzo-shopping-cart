using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Contract;

namespace ShoppingCart.Domain
{
    public class Cart
    {
        public int UserId { get; set; }
        public IList<Item> Items { get; set; }

        public Cart(int userId, IList<Item> items)
        {
            UserId = userId;
            Items = items;
        }

        public void AddItems(IEnumerable<Item> cartItems, IEventStore eventStore)
        {
            foreach (var item in cartItems)
            {
                Items.Add(item);
                eventStore.Raise("ShoppingCartItemAdded", new { UserId, item });
            }
        }

        public void RemoveItems(int[] productCatalogIds, IEventStore eventStore)
        {
            foreach (var productCatalogId in productCatalogIds)
            {
                var itemToRemove = Items.FirstOrDefault(i => i.ProductCatalogId.Equals(productCatalogId));
                if (itemToRemove != null)
                {
                    Items.Remove(itemToRemove);
                    eventStore.Raise("ShoppingCartItemRemoved", new { UserId, itemToRemove });
                }
            }
        }
    }
}