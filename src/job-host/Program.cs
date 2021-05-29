using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MyBackgroundProcess.Application.Posting;
using MyBackgroundProcess.Infrastructure.Blogging;
using MyBackgroundProcess.Infrastructure.Posting;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

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
                        .AddTransient<IPostService, PostService>()
                        .AddSingleton<JsonSerializerOptions>(CreateDefaultJsonSerializerOptions());
                    services.Configure<BlogClientSettings>(hostContext.Configuration.GetSection(nameof(BlogClientSettings)));
                    services.Configure<PostSettings>(hostContext.Configuration.GetSection(nameof(PostSettings)));

                    services.AddHttpClient<IPostGateway, PostGateway>()
                        .ConfigureHttpClient(ConfigureClient);
                });

        public static void ConfigureClient(IServiceProvider sp, HttpClient client)
        {
            var blogOptions = sp.GetService<IOptions<BlogClientSettings>>();
            AddBaseAddress(client, blogOptions.Value);
            AddAcceptHeaders(client);
        }

        public static void AddBaseAddress(HttpClient httpClient, BlogClientSettings blogClientSettings)
        {
            var blogUrl = blogClientSettings.BaseUrl;
            var blogUri = new Uri(blogUrl);
            httpClient.BaseAddress = blogUri;
        }

        public static void AddAcceptHeaders(HttpClient httpClient)
        {
            var jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                jsonHeader);
        }
        public static JsonSerializerOptions CreateDefaultJsonSerializerOptions() =>
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
}
