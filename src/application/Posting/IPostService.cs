using MyBackgroundProcess.Domain.Posting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Posting
{
    public interface IPostService
    {
        Task<IEnumerable<PostId>> GetAllPostIdsAsync();
        Task<Post> GetByAsync(PostId postId);
    }
}
