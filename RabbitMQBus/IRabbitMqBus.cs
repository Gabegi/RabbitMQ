namespace RabbitMQBus
{
    public interface IRabbitMqBus
    {
        Task Publish<T> (T command);
    }
}
