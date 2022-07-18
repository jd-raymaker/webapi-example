public interface ILogger
{
    void Log(string message);
}

public class LogToConsole : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
