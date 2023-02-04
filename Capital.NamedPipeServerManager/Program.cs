using Capital.NamedPipeServer.Classes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Capital.NamedPipeServer
{
    internal static class Program
    {
        internal static IServiceProvider? ServiceProvider { get; private set; }
        internal static string[] _args;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            _args = args;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Home>());
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => ConfigureServices(context, services));
        }

        private static IServiceCollection ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<PipesManager>();
            services.AddSingleton<MessageSender>();
            services.AddTransient<Home>();

            return services;
        }
    }
}