using Capital.NamedPipeServer.Classes;

namespace Capital.NamedPipeServer.Extentions
{
    public static class PipeManagerExtentions
    {
        public static bool Exists(this PipesManager manager, string name) => manager.Pipes.ContainsKey(name);
    }
}
