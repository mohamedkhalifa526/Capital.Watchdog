using Capital.NamedPipeServer.Delegates;

namespace Capital.NamedPipeServer.Classes
{
    public interface IMessageHandler
    {
        event ProcessMessage OnMessageRecived;
    }
}