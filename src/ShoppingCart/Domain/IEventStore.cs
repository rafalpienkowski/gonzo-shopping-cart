namespace ShoppingCart.Domain
{
    public interface IEventStore
    {
        void Raise(string eventName, object o);
    }
}