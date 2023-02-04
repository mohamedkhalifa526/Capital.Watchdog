using System.IO.Pipes;

namespace Capital.NamedPipeServer.Helpers
{
    public class NamedPipeHelper
    {
        public NamedPipeServerStream CreateNamedPipe(string pipename)
        {
            // Create a named pipe.
            // The "TestPipe" is the name of the pipe and can be given arbitrarily.
            return new NamedPipeServerStream(pipename);
        }
    }
}