using SocialMedia.Data;
using SocialMedia.Models.Post;
using SocialMedia.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostServices
    {
        private Guid _userId;
        public PostServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Post entity = new Post()
                {
                    Title = post.Title,
                    Text = post.Text,
                    AuthorId = _userId,
                };
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetAllPostsForUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
               var query = ctx.Posts
                      .Where(p => p.AuthorId == _userId)
                      .Select(m => new PostListItem
                      {
                          Id = m.Id,
                          Title = m.Title,
                          Text = m.Text,
                          AuthorId = m.AuthorId,
                          AuthorName = m.Author.Name
                      });
                return query.ToList();
            }
        }
        public IEnumerable<PostListItem> GetAllPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts                      
                       .Select(m => new PostListItem
                       {
                           Id = m.Id,
                           Title = m.Title,
                           Text = m.Text,
                           AuthorId = m.AuthorId,
                           AuthorName = m.Author.Name
                       });
                return query.ToList();
            }
        }

        public UserDetail ConvertUserToUserDetail(User user)
        {
            var userDetail = new UserDetail()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
               // PostsByUser = 
            };
            foreach (var post in user.PostsByUser)
            {
                var postListItem = new PostListItem
                {
                    Id = post.Id,
                    Text = post.Text,
                    Title = post.Title,
                    AuthorId = post.AuthorId,
                    AuthorName = post.Author.Name
                };
                userDetail.PostsByUser.Add(postListItem);
            }
            return userDetail;
        }
    }
}
