using MyBackgroundProcess.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Posting
{
    public interface IPostGateway
    {
        Task<IEnumerable<PostDTO>> GetAllPosts();
    }
}
