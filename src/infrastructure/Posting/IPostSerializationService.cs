using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Domain.Posting;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Infrastructure.Posting
{
    public interface IPostSerializationService
    {
        Task<IEnumerable<Post>> DeserializeAsync(HttpResponseMessage responseMessage);
    }
}
