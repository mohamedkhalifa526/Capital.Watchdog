using Capital.CandleCalculator.Extentions;
using Capital.Core.Constants;
using Capital.Core.Enums;
using Capital.Core.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;

namespace Capital.CandleCalculator
{
    public static class Program
    {
        private static IModel _channel;
        private static ConcurrentDictionary<TimeFrame, Candle> Last = new();
        private static ConcurrentDictionary<TimeFrame, Candle> Current = new();

        static Program()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(exchange: RabbitMQConstants.CandlesExchange, type: ExchangeType.Fanout);
        }

        public static void Main(string[] args)
        {
            var pair = args[0].ToLower();

            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: RabbitMQConstants.TicksExchange, type: ExchangeType.Fanout);

                string ticksQueue = string.Format(RabbitMQConstants.CandleCalculatorQueue, pair);
                channel.QueueBind(queue: ticksQueue,
                                  exchange: RabbitMQConstants.TicksExchange,
                                  routingKey: pair);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Calculate;
                channel.BasicConsume(queue: pair, autoAck: true, consumer: consumer);

                Console.ReadLine();
            }
        }

        private static void Calculate(object? model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var tick = JsonConvert.DeserializeObject<MqlTick>(message);

            var timeframes = Enum.GetValues<TimeFrame>();
            foreach (var frame in timeframes)
            {
                if (!Last.Keys.Contains(frame) && !Current.Keys.Contains(frame))
                {
                    Candle candle = tick.CreateCandle();
                    Last.TryAdd(frame, candle);
                    Current.TryAdd(frame, candle);

                    return;
                }
                else if (!Last.Keys.Contains(frame) && Current.Keys.Contains(frame))
                {
                    var ccdl = Current[frame];
                    Current[frame] = tick.CreateCandle();
                    Last.TryAdd(frame, ccdl);
                }
                else if (tick.IsNewCandle(Last[frame], frame))
                {
                    // Get last candle
                    var ccdl = Current[frame];
                    var lcdl = Last[frame];

                    Current[frame] = tick.CreateCandle();
                    Last[frame] = ccdl;

                    // TODO: Save candle
                    PublishCandle(ccdl);
                }
                else
                {
                    var ccdl = Current[frame];
                    Current[frame] = ccdl.UpdateCandle(tick);
                }
            }
        }

        private static void PublishCandle(Candle candle)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(candle));
            _channel.BasicPublish(exchange: RabbitMQConstants.TicksExchange,
                                 routingKey: candle.Symbol.ToString().ToLower(),
                                 basicProperties: null,
                                 body: body);
        }
    }
}