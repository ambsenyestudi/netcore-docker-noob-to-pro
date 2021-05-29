using MyBackgroundProcess.Domain.Posting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Posting
{
    public class PostRepository : IPostRepository
    {
        private readonly List<PostId> postIdList = new List<PostId>();
        private readonly List<Post> postList = new List<Post>();
        private readonly IPostGateway postGateway;


        public PostRepository(IPostGateway postGateway)
        {
            this.postGateway = postGateway;
        }

        public async Task<IEnumerable<PostId>> GetAllPostId()
        {
            if (MustUpdate(postIdList))
            {
                await UpdateAsync();
            }
            return postIdList.AsEnumerable();
        }
        public async Task<Post> GetBy(PostId postId)
        {
            if (MustUpdate(postList))
            {
                await UpdateAsync();
            }
            return postList.FirstOrDefault(x => x.Id == postId);
        }

        private async Task UpdateAsync()
        {
            var postCollection = await postGateway.GetAllPosts();
            postList.AddRange(postCollection);
            var postIdCollection = postCollection.Select(x => x.Id).Distinct();
            postIdList.AddRange(postIdCollection);
        }

        private bool MustUpdate(List<PostId> postIdList) =>
            !postIdList.Any();

        private bool MustUpdate(List<Post> postList) =>
            !postList.Any();
    }
}
