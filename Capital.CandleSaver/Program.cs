using Capital.Core.Constants;
using Capital.Core.Model;
using Capital.TickSaver.Documents;
using Capital.TickSaver.Indices;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Raven.Client.Documents;
using System.Text;

namespace Capital.TickSaver
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var pair = args[0].ToLower();

            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: RabbitMQConstants.TicksExchange, type: ExchangeType.Fanout);

                string ticksQueue = string.Format(RabbitMQConstants.TicksQueue, pair);
                channel.QueueBind(queue: ticksQueue,
                                  exchange: RabbitMQConstants.TicksExchange,
                                  routingKey: pair);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Save;
                channel.BasicConsume(queue: pair, autoAck: true, consumer: consumer);

                Console.ReadLine();
            }
        }

        private static void Save(object? model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var m = JsonConvert.DeserializeObject<MqlTick>(message);

            using (DocumentStore store = new DocumentStore()
            {
                Urls = new string[] { "http://127.0.0.1:8080" },
                Database = "capital-ticks"
            })
            {
                // Initialize RavenDB data store
                store.Initialize();

                // Open RavenDB session
                var session = store.OpenSession();

                // Create index if not exists
                new Tick_Data().Execute(store);

                // Inserd document
                session.Store(new TickDocument(m, m.Pair), Guid.NewGuid().ToString());

                // Save changes
                session.SaveChanges();
            }

            Console.WriteLine(" [x] {0}", message);
        }
    }
}