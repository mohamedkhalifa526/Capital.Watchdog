using Capital.NamedPipeServer.Enums;
using Capital.NamedPipeServer.Extentions;
using System.Collections.Concurrent;
using System.IO.Pipes;

namespace Capital.NamedPipeServer.Classes
{
    public class PipesManager
    {
        public readonly string PipeNamePattern = "^[_A-Za-z]{1}[_\\w\\d]*$";

        public int PipeIndex { get; private set; } = 0;
        public ConcurrentDictionary<string, PipeContainer> Pipes = new();

        public async Task<PipeContainer> CreatePipe(string name, bool restartOnDisconnect = true)
        {
            var np = new NamedPipeServerStream(name);
            var container = new PipeContainer()
            {
                Index = PipeIndex++,
                Name = name,
                RestartOnDisconnect = restartOnDisconnect,
                Pipe = np,
                Status = PipeStatus.New
            };
            Pipes.TryAdd(name, container);

            return container;
        }

        public IEnumerable<PipeContainer> GetPipes() => Pipes.Values;

        public void DeletePipe(string name)
        {
            Pipes.Remove(name, out var container);
            container?.Dispose();
        }
    }

    public class PipeContainer : IDisposable
    {
        public delegate void MessageRecived(object sender, string message);

        public delegate void Connected(object sender);

        public delegate void Disconnected(object sender);

        public event Connected? OnConnected;

        public event Disconnected? OnDisconnected;

        public event MessageRecived? OnMessageRecived;

        public void Print(object sender, string message)
        {
            Console.WriteLine(sender.GetHashCode().ToString() + " " + message);
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public bool RestartOnDisconnect { get; set; }
        public PipeStatus Status { get; set; } = PipeStatus.New;
        public NamedPipeServerStream Pipe { get; set; }

        public async Task StartAsync()
        {
            do
            {
                if (Pipe.IsConnected)
                    Pipe.Disconnect();

                Status = PipeStatus.WaitingForClients;

                await Pipe.Connect();
                Status = PipeStatus.Connected;

                if (OnConnected != null)
                    OnConnected.Invoke(this);

                while (Pipe.IsConnected)
                {
                    Status = PipeStatus.Reciveing;
                    var line = await Pipe.ReadLine();

                    if ((sbyte)line.Last() == -1)
                        Pipe.Disconnect();
                    else
                        OnMessageRecived.Invoke(this, line);
                }

                Status = PipeStatus.DisConnected;
                if (OnDisconnected != null)
                    OnDisconnected.Invoke(this);
            } while (RestartOnDisconnect);

            Status = PipeStatus.Disposed;
            Dispose();
        }

        public void Dispose()
        {
            Pipe.Dispose();
            Status = PipeStatus.Disposed;
        }
    }
}