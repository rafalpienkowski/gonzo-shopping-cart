using System.Collections.Generic;

namespace ShoppingCart.Contract
{
    public interface IShoppingCartRepository
    {
        Cart Get(int userId);
    }

    public class Cart
    {
        public int UserId { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }

    public class Item
    {
        public int ProductCatalogId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
    }

    public class Money
    {
        public CurrencyType Currency { get; }
        public decimal Amount { get; }

        private Money()
        {
        }

        public Money(CurrencyType currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }
    }

    public enum CurrencyType
    {
        Eur = 1
    }
}