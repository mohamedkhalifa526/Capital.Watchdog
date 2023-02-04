using System.IO.Pipes;
using System.Text;

namespace Capital.NamedPipeServer.Extentions
{
    public static class NamedPipeExtentions
    {
        public static async Task<bool> IsConnected(this NamedPipeServerStream pipeServer)
            => pipeServer.IsConnected;

        public static async Task Connect(this NamedPipeServerStream pipeServer)
        {
            // Waiting for the client to connect to the pipe.
            await Task.Run(() => pipeServer.WaitForConnection());
        }

        public static async Task<string> ReadLine(this NamedPipeServerStream pipeServer)
        {
            var result = new StringBuilder();

            char character = default;
            while (!Environment.NewLine.EndsWith(character) && (sbyte)character != -1)
            {
                int c = pipeServer.ReadByte();
                character = (char)c;
                result.Append(character);
            }

            return result.ToString();
        }
    }
}