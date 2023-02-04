using Capital.Core.Enums;
using System.Text.Json.Serialization;

namespace Capital.Core.Model
{
    public class Candle
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Symbol Symbol { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeFrame TimeFrame { get; set; }

        public DateTime Time { get; set; }
        public decimal High { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal Low { get; set; }
        public decimal? Volume { get; set; }
    }
}