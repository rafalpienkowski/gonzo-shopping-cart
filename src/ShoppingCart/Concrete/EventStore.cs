using System;
using ShoppingCart.Domain;

namespace ShoppingCart.Concrete
{
    public class EventStore: IEventStore

    {
        public void Raise(string eventName, object o)
        {
            Console.WriteLine($"Event: {eventName}, object: {o}");
        }
    }
}