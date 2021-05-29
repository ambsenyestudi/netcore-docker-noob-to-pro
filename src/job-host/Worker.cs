using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyBackgroundProcess.Application.Posting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBackgroundProces.JobHost
{
    public class Worker : IHostedService
    {
        private readonly IPostService postService;
        private readonly ILogger<Worker> logger;
        private readonly IHostApplicationLifetime appLifetime;
        private int? exitCode;

        public Worker(
            IPostService postService,
            ILogger<Worker> logger,
            IHostApplicationLifetime appLifetime)
        {
            this.postService = postService;
            this.logger = logger;
            this.appLifetime = appLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");
            appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var postIdCollection = await postService.GetAllPostIdsAsync();
                        foreach (var id in postIdCollection)
                        {
                            await Task.Delay(50);
                            await postService.GetByAsync(id);
                        }
                        
                        exitCode = 0;
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Unhandled exception!");
                        exitCode = 1;
                    }
                    finally
                    {
                        // Stop the application once the work is done
                        appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug($"Exiting with return code: {exitCode}");

            // Exit code may be null if the user cancelled via Ctrl+C/SIGTERM
            Environment.ExitCode = exitCode.GetValueOrDefault(-1);
            return Task.CompletedTask;
        }
    }
}
