using MyBackgroundProcess.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Posting
{
    public class PostService : IPostService
    {
        private readonly IPostGateway postGateway;

        public PostService(IPostGateway postGateway)
        {
            this.postGateway = postGateway;
        }
        public Task<IEnumerable<PostDTO>> GetAllPostsAsync() =>
            postGateway.GetAllPosts();
    }
}
