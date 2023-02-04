using Capital.Core.Model;
using Raven.Client.Documents.Indexes;

namespace Capital.TickSaver.Indices
{
    public class Tick_Data : AbstractIndexCreationTask<MqlTick>
    {
        public class TickDocument
        {

        }

        public Tick_Data()
        {
            Map = messages => messages.Select(m => new
            {
                m.Pair,
                m.Time,
                m.Ask,
                m.Bid,
                Spread = m.Ask - m.Bid,
                AveragePrice = (m.Ask + m.Bid) / 2,



            });
        }
    }
}