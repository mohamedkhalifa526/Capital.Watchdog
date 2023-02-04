using System.Text.Json.Serialization;
using Capital.Core.Enums;

namespace Capital.Core.Model
{
    public class MessageModel
    {
        public Messagedata MessageData { get; set; }
        public Chartdata ChartData { get; set; }
        public Pricedata PriceData { get; set; }
        public Balancedata BalanceData { get; set; }
        public Dictionary<string, decimal> IndicatorData { get; set; }
        public Trade[] Trades { get; set; }
    }

    public class Messagedata
    {
        public Guid MessageId { get; set; } = Guid.NewGuid();
        public DateTime TimeStamp { get; set; }
    }

    public class Chartdata
    {
        public long MagicId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Symbol Symbol { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeFrame TimeFrame { get; set; }
    }

    public class Pricedata
    {
        public decimal AskPrice { get; set; }
        public decimal BidPrice { get; set; }
        public decimal? StopSell { get; set; }
        public decimal? StopBuy { get; set; }
    }

    public class Balancedata
    {
        public decimal Balance { get; set; }
        public decimal Equity { get; set; }
        public decimal FreeMargin { get; set; }
    }

    public class Trade
    {
        public long MagicId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Symbol Symbol { get; set; }

        public decimal Volume { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TradeDirection Direction { get; set; }

        public decimal StartPrice { get; set; }
        public decimal? StopLoss { get; set; }
        public decimal? TakeProfit { get; set; }
        public string Comment { get; set; }
    }
}