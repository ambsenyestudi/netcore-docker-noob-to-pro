using MyBackgroundProcess.Domain.Posting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Posting
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostId>> GetAllPostId();
        Task<Post> GetBy(PostId postId);
    }
}