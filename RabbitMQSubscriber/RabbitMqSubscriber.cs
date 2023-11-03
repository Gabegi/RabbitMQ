using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQSubscriber
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
                    // channel QueueDeclare = create 1st queue
                    channel.QueueDeclare(_queueName + 1,
                                            false, //durable: messages sent using this method persist only in the memory and not survive a server restart.
                                            false, //exclusive
                                            false, // auto-delete
                                            null); // arguments

                    

                    // channel QueueDeclare = create 2nd queue
                    channel.QueueDeclare(_queueName + 2,
                                            false, //durable: messages sent using this method persist only in the memory and not survive a server restart.
                                            false, //exclusive
                                            false, // auto-delete
                                            null); // arguments
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
                    var result = channel.BasicConsume(_queueName, true, consumer);
                }
            }
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            throw new NotImplementedException();
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

        // Get result from queue

        private BasicGetResult GetResult(IModel channel)
        {
            return channel.BasicGet(_queueName, true);
        }


        // Decode body


    }


}