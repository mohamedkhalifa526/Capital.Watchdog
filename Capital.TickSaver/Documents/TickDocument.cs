using Capital.Core.Model;
using Newtonsoft.Json;

namespace Capital.TickSaver.Documents
{
    public class TickDocument : MqlTick
    {
        public TickDocument(MqlTick bs, string? collection = null)
        {
            Pair = bs.Pair;
            Time = bs.Time;
            Ask = bs.Ask;
            Bid = bs.Bid;

            if (string.IsNullOrEmpty(collection))
                collection = bs.Pair;

            if (MetaData == null)
                MetaData = new Dictionary<string, object>();

            if (!(MetaData.Any() || MetaData.Keys.Contains("@collection")))
                MetaData.Add("@collection", collection);
        }

        [JsonProperty("@metadata")]
        public Dictionary<string, object> MetaData { get; set; }
    }
}