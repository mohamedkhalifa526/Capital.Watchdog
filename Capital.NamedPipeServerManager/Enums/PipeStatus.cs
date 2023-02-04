namespace Capital.NamedPipeServer.Enums
{
    public enum PipeStatus
    {
        New,
        WaitingForClients,
        Connected,
        Reciveing,
        DisConnected,
        Disposed
    }
}