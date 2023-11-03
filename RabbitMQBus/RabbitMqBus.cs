using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQBus
{
    public class RabbitMqBus: IRabbitMqBus
    {
        private readonly string _queueName = "BobSQueue";
        private readonly string _exchangeName = "bob-fanout-exchange";

        // channel publish
        public async Task Publish<T>(T command)
        {
            // Create Connection
            using(var connection = SetUpConnection())
            {
                // Create Channel
                using (var channel = SetUpChannel(connection))
                {
                    // Create a fanout exchange
                    channel.ExchangeDeclare(
                        _exchangeName, //name of exchange
                        ExchangeType.Fanout, //type of exchange
                        false, // durable
                        false, // durable
                        null // arguments
                        );

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

                    // Create the message
                    var message = CreateBody(command);

                    // publish the message
                    channel.BasicPublish
                        (
                        _exchangeName, //exchangeName
                        string.Empty, //routingKey > not needed for fanout exchange
                        false, //mandatory
                        null, //basicProperties
                        message //body
                        );
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
            return connection.CreateModel(); // channel = where apis reside

            // A channel (a virtual connection) is created in the TCP connection.
            // Publishing /consuming messages and subscribing to a queue are all done over a channel.
        }

        // Encode message body
        private byte[] CreateBody<T> (T command)
        {
            var message = JsonConvert.SerializeObject(command);

            return Encoding.UTF8.GetBytes(message);
        }
    }
}