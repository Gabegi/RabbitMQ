using Subscriber;

internal class Program
{
    private static void Main(string[] args)
    {
        var subscriber = new RabbitMqSubscriber();

        subscriber.Subscribe();

        Console.WriteLine("Subscriber executed");
    }
}