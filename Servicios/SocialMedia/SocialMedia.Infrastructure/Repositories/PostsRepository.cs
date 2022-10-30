using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostsRepository
    {
        public IEnumerable<Posts> GetPosts()
        {
            Random random = new Random();
            var posts = Enumerable.Range(1, 10).Select(Row => new Posts
            {
                PostId = Row,
                Description = $"Descripcion {Row}",
                Date = DateTime.Now,
                Image = $"https://misapis.com/{Row}",
                UserId = random.Next()
            });

            return posts;
        }
    }
}
