namespace ShoppingCart.Domain
{
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
}