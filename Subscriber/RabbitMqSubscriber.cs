using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Subscriber
{
    public class RabbitMqSubscriber : IRabbitMqSubscriber
    {

        private readonly string _queueName = "BobSQueue";
        private readonly string _exchangeName = "bob-fanout-exchange";

        public void Subscribe()
        {
            using(var connection = SetUpConnection())
            {
                using(var channel = SetUpChannel(connection))
                {
                     // Bind queue 1
                    channel.QueueBind(
                        _queueName + 1, // queue name
                        _exchangeName, // exchange name
                        String.Empty, // routing key
                        null // arguments
                        );

                    // Bind queue 2
                    channel.QueueBind(
                        _queueName + 2, // queue name
                        _exchangeName, // exchange name
                        String.Empty, // routing key
                        null // arguments
                        );

                    // Create consumer
                    var consumer = new EventingBasicConsumer(channel);

                    // Receive Message
                    consumer.Received += (sender, e) =>
                    {
                        var message = Encoding.UTF8.GetString(e.Body.ToArray());
                        Console.WriteLine(message);
                    };

                    // Subscribe to the queue
                    var result1 = channel.BasicConsume(_queueName + 1, true, consumer);
                    var result2 = channel.BasicConsume(_queueName + 2, true, consumer);

                    Console.WriteLine(result1);
                    Console.WriteLine(result2);
                }
            }
        }

        // CreateConnection
        private IConnection SetUpConnection()
        {
            var connectionFactory = new ConnectionFactory();

            connectionFactory.HostName = "localhost"; // connect to a RabbitMQ node on local machine
            connectionFactory.VirtualHost = "/";
            connectionFactory.Port = 5672;
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";

            return connectionFactory.CreateConnection(); // abstract socket connection
        }

        // Create Channel
        private IModel SetUpChannel(IConnection connection)
        {
            return connection.CreateModel();
        }
    }


}