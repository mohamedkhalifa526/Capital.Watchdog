using Capital.Core.Constants;
using Capital.Core.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Capital.NamedPipeServer.Classes
{
    public class MessageSender
    {
        private readonly IModel _channel;

        public MessageSender()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(exchange: RabbitMQConstants.TicksExchange, type: ExchangeType.Fanout);
        }

        public void Publish(MqlTick message)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _channel.BasicPublish(exchange: RabbitMQConstants.TicksExchange,
                                 routingKey: message.Pair.ToLower(),
                                 basicProperties: null,
                                 body: body);
        }
    }
}