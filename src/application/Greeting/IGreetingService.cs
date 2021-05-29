using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Greeting
{
    public interface IGreetingService
    {
        Task<string> ComposeGreeting();
    }
}
