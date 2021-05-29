using Microsoft.Extensions.Options;
using MyBackgroundProcess.Application.Greeting;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Infrastructure.Greeting
{
    public class GreetingService : IGreetingService
    {
        private readonly GreetingSettings settings;

        public GreetingService(IOptions<GreetingSettings> options)
        {
            settings = options.Value;
        }
        public Task<string> ComposeGreeting() =>
            Task.Factory.StartNew(() => settings.Greeting);
    }
}
