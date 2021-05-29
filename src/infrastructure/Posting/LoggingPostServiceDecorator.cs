using Microsoft.Extensions.Logging;
using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Application.Posting;
using MyBackgroundProcess.Domain.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Infrastructure.Posting
{
    public class LoggingPostServiceDecorator : IPostService
    {
        private readonly IPostService decorated;
        private readonly ILogger<LoggingPostServiceDecorator> logger;

        public LoggingPostServiceDecorator(
            IPostService decorated,
            ILogger<LoggingPostServiceDecorator> logger)
        {
            this.decorated = decorated;
            this.logger = logger;
        }

        public async Task<IEnumerable<PostId>> GetAllPostIdsAsync()
        {
            try
            {
                return await decorated.GetAllPostIdsAsync();
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return Enumerable.Empty<PostId>();
            }
            
        }

        public async Task<Post> GetByAsync(PostId postId)
        {   
            var result = await decorated.GetByAsync(postId);
            logger.LogInformation(result.ToString());
            return result;
        }
    }
}
