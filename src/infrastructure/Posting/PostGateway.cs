using Microsoft.Extensions.Options;
using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Application.Posting;
using MyBackgroundProcess.Domain.Posting;
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
        private readonly IPostSerializationService postSerializationService;
        private readonly HttpClient httpClient;
        private readonly PostSettings settings;
        private readonly string postsEndpoint;

        public PostGateway(
            IPostSerializationService postSerializationService,
            HttpClient httpClient,
            IOptions<PostSettings> options)
        {
            this.postSerializationService = postSerializationService;
            this.httpClient = httpClient;
            settings = options.Value;
            postsEndpoint = settings.Endpoint;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var response = await httpClient.GetAsync(postsEndpoint);
            response.EnsureSuccessStatusCode();
            return await postSerializationService.DeserializeAsync(response);
        }

        

        
    }
}
