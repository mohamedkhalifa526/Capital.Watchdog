namespace Capital.Core.Constants
{
    public static class RabbitMQConstants
    {
        public const string TicksExchange = "capital.ticks.exchange";
        public const string TicksQueue = "capital.ticks.{0}.queque";
        public const string CandleCalculatorQueue = "capital.candle.calc.{0}.queque";

        public const string CandlesExchange = "capital.candles.exchange";
        public const string CandlesQueue = "capital.candles.{0}.queque";
    }
}