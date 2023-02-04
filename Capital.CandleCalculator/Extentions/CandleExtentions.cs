using Capital.Core.Enums;
using Capital.Core.Model;

namespace Capital.CandleCalculator.Extentions
{
    public static class CandleExtentions
    {
        public static Candle UpdateCandle(this Candle current, MqlTick tick)
        {
            var result = new Candle
            {
                Time = tick.Time,
                Open = current.Open,
                High = Math.Max(tick.Ask, current.High),
                Low = Math.Min(tick.Ask, current.Low),
                Close = tick.Ask
            };

            return result;
        }

        public static Candle CreateCandle(this MqlTick tick)
        {
            var result = new Candle
            {
                Time = tick.Time,
                Open = tick.Ask,
                High = tick.Ask,
                Low = tick.Ask,
                Close = tick.Ask
            };

            return result;
        }

        public static bool IsNewCandle(this MqlTick tick, Candle last, TimeFrame frame)
        {
            var dateFrames = new TimeFrame[]
            {
                TimeFrame.D1,
                TimeFrame.W1,
                TimeFrame.MN
            };
            var minuteFrames = new TimeFrame[]
            {
                TimeFrame.M1,
                TimeFrame.M5,
                TimeFrame.M15,
                TimeFrame.M30,
                TimeFrame.H1,
                TimeFrame.H4
            };

            if (dateFrames.Contains(frame))
            {
                var tickDate = tick.Time.Date;
                var candleDate = last.Time.Date;
                switch (frame)
                {
                    case TimeFrame.D1:
                        return candleDate == tickDate;

                    case TimeFrame.W1:
                        var d = (int)candleDate.DayOfWeek;
                        return tickDate - candleDate.AddDays(-d) >= TimeSpan.FromDays(7);

                    case TimeFrame.MN:
                        return candleDate.Year == tickDate.Year && candleDate.Month == tickDate.Month;
                }
            }

            if (minuteFrames.Contains(frame))
            {
                switch (frame)
                {
                    case TimeFrame.M1:
                        var m1 = last.Time.AddSeconds(-last.Time.Second);
                        return tick.Time - m1 >= TimeSpan.FromMinutes(1);

                    case TimeFrame.M5:
                        //var f5 = last.Time.Minute / 5;
                        var m5 = last.Time.AddMinutes(-last.Time.Minute).AddSeconds(-last.Time.Second);
                        //var m5 = last.Time.Date.AddHours(f5 * 5);
                        return tick.Time - m5 >= TimeSpan.FromMinutes(5);

                    case TimeFrame.M15:
                        var m15 = last.Time.AddMinutes(-last.Time.Minute).AddSeconds(-last.Time.Second);
                        return tick.Time - m15 >= TimeSpan.FromMinutes(15);

                    case TimeFrame.M30:
                        var m30 = last.Time.AddMinutes(-last.Time.Minute).AddSeconds(-last.Time.Second);
                        return tick.Time - m30 >= TimeSpan.FromHours(30);

                    case TimeFrame.H1:
                        var hour = last.Time.Date.AddHours(last.Time.Hour);
                        return tick.Time - hour >= TimeSpan.FromHours(1);

                    case TimeFrame.H4:
                        var f4 = last.Time.Hour / 4;
                        var h4 = last.Time.Date.AddHours(f4 * 4);
                        return tick.Time - h4 >= TimeSpan.FromHours(4);
                }
            }

            return true;
        }
    }
}