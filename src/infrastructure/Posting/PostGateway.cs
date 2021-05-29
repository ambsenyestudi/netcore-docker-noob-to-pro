using Microsoft.Extensions.Options;
using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Application.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Infrastructure.Posting
{
    public class PostGateway: IPostGateway
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private readonly PostSettings settings;
        private readonly string postsEndpoint;

        public PostGateway(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions,
            IOptions<PostSettings> options)
        {
            this.httpClient = httpClient;
            this.jsonSerializerOptions = jsonSerializerOptions;
            settings = options.Value;
            postsEndpoint = settings.Endpoint;
        }

        public async Task<IEnumerable<PostDTO>> GetAllPosts()
        {
            var response = await httpClient.GetAsync(postsEndpoint);
            response.EnsureSuccessStatusCode();
            return await DeserializeContentAsync(response.Content);
        }

        private async Task<IEnumerable<PostDTO>> DeserializeContentAsync(HttpContent content)
        {
            var readableContent = await content.ReadAsStringAsync();
            var contentStream = await content.ReadAsStreamAsync();
            var resultList = await JsonSerializer.DeserializeAsync<IEnumerable<PostDTO>>(contentStream, jsonSerializerOptions);
            return resultList;
        }
    }
}
