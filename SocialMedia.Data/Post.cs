using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<Comment> CommentsForPost { get; set; }
    }
}
