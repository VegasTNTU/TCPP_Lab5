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

    public User(string name) => Name = name;

    public void Update(string stock, double price)
        => Console.WriteLine($"{Name} notified: {stock} is now {price}$");
}
