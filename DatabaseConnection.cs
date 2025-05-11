public class DatabaseConnection
{
    private static DatabaseConnection _instance;
    private static readonly object _lock = new();
    public string ConnectionString { get; private set; }

    private DatabaseConnection()
    {
        ConnectionString = "Data Source=server;Initial Catalog=db;User ID=user;Password=pass;";
        Console.WriteLine("Database connection created.");
    }

    public static DatabaseConnection GetInstance()
    {
        lock (_lock)
        {
            return _instance ??= new DatabaseConnection();
        }
    }

    public void Connect() => Console.WriteLine("Connected to DB.");
}
