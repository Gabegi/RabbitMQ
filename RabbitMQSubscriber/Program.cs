namespace RabbitMQSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscriber = new RabbitMqSubscriber();

            subscriber.Subscribe();
        }
    }
}
