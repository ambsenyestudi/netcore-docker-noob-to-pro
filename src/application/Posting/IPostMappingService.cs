using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Domain.Posting;
using System.Collections.Generic;

namespace MyBackgroundProcess.Application.Posting
{
    public interface IPostMappingService
    {
        IEnumerable<PostDTO> RemoveIfAnyInvalidateId(IEnumerable<PostDTO> postCollection);
        IEnumerable<Post> Map(IEnumerable<PostDTO> postCollection);
    }
}
