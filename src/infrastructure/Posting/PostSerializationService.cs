using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Application.Posting;
using MyBackgroundProcess.Domain.Posting;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Infrastructure.Posting
{
    public class PostSerializationService : IPostSerializationService
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private readonly IPostMappingService postMappingService;

        public PostSerializationService(
            IPostMappingService postMappingService,
            JsonSerializerOptions jsonSerializerOptions)
        {
            this.jsonSerializerOptions = jsonSerializerOptions;
            this.postMappingService = postMappingService;
        }
        public Task<IEnumerable<Post>> DeserializeAsync(HttpResponseMessage responseMessage) =>
            DeserializePosts(responseMessage.Content);

        private async Task<IEnumerable<PostDTO>> DeserializeContentAsync(HttpContent content)
        {
            var contentStream = await content.ReadAsStreamAsync();
            var resultList = await JsonSerializer.DeserializeAsync<IEnumerable<PostDTO>>(contentStream, jsonSerializerOptions);
            return resultList;
        }
        private async Task<IEnumerable<Post>> DeserializePosts(HttpContent content)
        {
            var postCollection = await DeserializeContentAsync(content);
            postCollection = postMappingService.RemoveIfAnyInvalidateId(postCollection);
            return postMappingService.Map(postCollection);
        }
    }
}
