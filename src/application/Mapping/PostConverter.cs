using AutoMapper;
using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Domain.Posting;
using MyBackgroundProcess.Domain.Users;

namespace MyBackgroundProcess.Application.Mapping
{
    public class PostConverter : ITypeConverter<PostDTO, Post>
    {
        public Post Convert(PostDTO source, Post destination, ResolutionContext context)
        {
            var id = PostId.FromInt(source.Id);
            var userId = UserId.FromInt(source.UserId);
            var result = new Post(id, userId);
            result.UpdateTitle(source.Title);
            result.UpdateBody(source.Body);
            return result;
        }
    }
}