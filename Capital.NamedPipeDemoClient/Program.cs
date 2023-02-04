using Capital.Core.Model;
using Newtonsoft.Json;
using System.IO.Pipes;

namespace Capital.NamedPipeDemoClient
{
    internal class Program
    {
        public static int threadcounter = 1;
        public static NamedPipeClientStream client;

        private static void Main(string[] args)
        {
            var pipeName = args[0];

            client = new NamedPipeClientStream(".", pipeName, PipeDirection.Out);
            client.Connect();

            //var t1 = new Thread(StartSend);
            var t2 = new Thread(StartSend);

            //t1.Start();
            t2.Start();
        }

        public static void StartSend()
        {
            int thisThread = threadcounter;
            threadcounter++;

            StartReadingAsync(client);

            var arr = new List<char>();

            var m1 = new MqlTick() { Time = DateTime.Now.AddSeconds(-3), Pair = "EURUSD", Ask = 1.05696m, Bid = 1.05716m };
            var m2 = new MqlTick() { Time = DateTime.Now.AddSeconds(-2), Pair = "EURUSD", Ask = 1.05698m, Bid = 1.05718m };
            var m3 = new MqlTick() { Time = DateTime.Now.AddSeconds(-1), Pair = "EURUSD", Ask = 1.05695m, Bid = 1.05715m };

            arr.AddRange(JsonConvert.SerializeObject(m1).ToCharArray());
            arr.AddRange(Environment.NewLine.ToCharArray());
            arr.AddRange(JsonConvert.SerializeObject(m2).ToCharArray());
            arr.AddRange(Environment.NewLine.ToCharArray());
            arr.AddRange(JsonConvert.SerializeObject(m3).ToCharArray());
            arr.AddRange(Environment.NewLine.ToCharArray());

            for (int i = 0; i < arr.Count; i++)
            {
                var buf = new byte[1];
                buf[0] = (byte)arr[i];
                client.WriteAsync(buf, 0, 1);

                Console.WriteLine($@"Thread{thisThread} Wrote: {buf[0]}");
                //Task.Delay(100).Wait();
            }
        }

        public static async Task StartReadingAsync(NamedPipeClientStream pipe)
        {
            var bufferLength = 1;
            byte[] pBuffer = new byte[bufferLength];

            await pipe.ReadAsync(pBuffer, 0, bufferLength).ContinueWith(async c =>
            {
                Console.WriteLine($@"read data {pBuffer[0]}");
                await StartReadingAsync(pipe); // read the next data <--
            });
        }
    }
}