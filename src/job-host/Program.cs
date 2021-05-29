using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBackgroundProcess.Application.Greeting;
using MyBackgroundProcess.Infrastructure.Greeting;

namespace MyBackgroundProces.JobHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddHostedService<Worker>()
                        .AddTransient<IGreetingService, GreetingService>();
                    services.Configure<GreetingSettings>(hostContext.Configuration.GetSection(nameof(GreetingSettings)));
                });
    }
}
