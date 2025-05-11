// Інтерфейс для уніфікованого доступу
public interface ISocialMedia
{
    void PostMessage(string message);
}

// Адаптери
public class FacebookAPI
{
    public void PostToFacebook(string msg) => Console.WriteLine($"Facebook: {msg}");
}

public class TwitterAPI
{
    public void Tweet(string msg) => Console.WriteLine($"Twitter: {msg}");
}

public class InstagramAPI
{
    public void PostPhoto(string msg) => Console.WriteLine($"Instagram: {msg}");
}

// Адаптери
public class FacebookAdapter : ISocialMedia
{
    private readonly FacebookAPI _facebook = new();
    public void PostMessage(string message) => _facebook.PostToFacebook(message);
}

public class TwitterAdapter : ISocialMedia
{
    private readonly TwitterAPI _twitter = new();
    public void PostMessage(string message) => _twitter.Tweet(message);
}

public class InstagramAdapter : ISocialMedia
{
    private readonly InstagramAPI _instagram = new();
    public void PostMessage(string message) => _instagram.PostPhoto(message);
}
