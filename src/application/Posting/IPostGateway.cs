using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Domain.Posting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Posting
{
    public interface IPostGateway
    {
        Task<IEnumerable<Post>> GetAllPosts();
    }
}
