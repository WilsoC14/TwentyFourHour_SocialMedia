using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.Post
{
    public class PostListItem
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
       
    }
}
