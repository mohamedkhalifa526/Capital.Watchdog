using Capital.NamedPipeServer.Delegates;

namespace Capital.NamedPipeServer.Classes
{
    public class MessagePublisher : IMessageHandler
    {
        public MessagePublisher()
        {
            OnMessageRecived = Print;
        }
        public event ProcessMessage OnMessageRecived;

        public void Print(object sender, string message)
        {
            Console.WriteLine(sender.GetHashCode().ToString() + " " + message);
        }
    }
}