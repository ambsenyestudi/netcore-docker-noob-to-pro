using MyBackgroundProcess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Domain.Posting
{
    public class Post
    {
        public PostId Id { get; }
        private readonly UserId userId;
        private string title = string.Empty;
        private string body = string.Empty;
        public Post(PostId id, UserId userId)
        {
            this.Id = id;

            this.userId = userId;
        }
        public void UpdateTitle(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                this.title = title;
            }
        }

        public void UpdateBody(string body)
        {
            if (!string.IsNullOrWhiteSpace(body))
            {
                this.body = body;
            }
        }

        public override string ToString()=>
            $"id: {Id.Value} title:{title} userId:{userId.Value}";
    }
}
