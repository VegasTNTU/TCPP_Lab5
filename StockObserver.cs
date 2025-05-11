using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string stock, double price);
}

public interface IStockNotifier
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify(string stock, double price);
}

public class StockExchange : IStockNotifier
{
    private readonly List<IObserver> _observers = new();

    public void Subscribe(IObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

    public void Notify(string stock, double price)
    {
        foreach (var obs in _observers)
            obs.Update(stock, price);
    }

    public void UpdateStock(string stock, double price)
    {
        Console.WriteLine($"Stock updated: {stock} - {price}$");
        Notify(stock, price);
    }
}

public class User : IObserver
{
    public string Name { get; }
    public string WatchedStock { get; }

    public User(string name, string watchedStock)
    {
        Name = name;
        WatchedStock = watchedStock;
    }

    public void Update(string stock, double price)
    {
        if (stock == WatchedStock)
        {
            Console.WriteLine($"{Name} notified: {stock} is now {price}$");
        }
    }
}

public class Program
{
    public static void Main()
    {
        StockExchange exchange = new();

        User alice = new("Alice", "AAPL");
        User bob = new("Bob", "GOOG");

        exchange.Subscribe(alice);
        exchange.Subscribe(bob);

        exchange.UpdateStock("AAPL", 150.0); // Only Alice gets notified
        exchange.UpdateStock("GOOG", 2800.5); // Only Bob gets notified
        exchange.UpdateStock("TSLA", 720.3); // No one gets notified
    }
}
