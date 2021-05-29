using AutoMapper;
using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Domain.Posting;
using MyBackgroundProcess.Domain.Users;
using System.Collections.Generic;
using System.Linq;

namespace MyBackgroundProcess.Application.Posting
{
    public class PostMappingService : IPostMappingService
    {
        private readonly IMapper mapper;

        public PostMappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IEnumerable<PostDTO> RemoveIfAnyInvalidateId(IEnumerable<PostDTO> postCollection) =>
            postCollection.Where(HasValidIds);

        public IEnumerable<Post> Map(IEnumerable<PostDTO> postCollection) => 
            postCollection.Select(x => mapper.Map<Post>(x));

        private bool HasValidIds(PostDTO postDTO) =>
            PostId.IsValidId(postDTO.Id) &&
            UserId.IsValidId(postDTO.UserId);
    }
}
