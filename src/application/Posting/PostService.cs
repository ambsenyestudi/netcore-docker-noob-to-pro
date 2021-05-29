using AutoMapper;
using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Domain.Posting;
using MyBackgroundProcess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Posting
{
    public class PostService : IPostService
    {
        private readonly IPostRepository repository;

        public PostService(IPostRepository repository)
        {
            this.repository = repository;
        }
        
        public Task<IEnumerable<PostId>> GetAllPostIdsAsync() => repository.GetAllPostId();
        public Task<Post> GetByAsync(PostId postId) => repository.GetBy(postId);

    }
}
