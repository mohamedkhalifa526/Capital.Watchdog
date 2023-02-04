using Capital.Core.Converters.SystemTextJsonSamples;
using System.Text.Json.Serialization;

namespace Capital.Core.Model
{
    public class MqlTick
    {
        public string Pair { get; set; }

        [JsonConverter(typeof(JsonMqlTimeConverter))]
        public DateTime Time { get; set; } = DateTime.Now;// Time of the last prices update

        public decimal Bid { get; set; }// Current Bid price
        public decimal Ask { get; set; }// Current Ask price
    }
}