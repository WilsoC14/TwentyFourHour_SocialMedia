using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {[Key]
       public int Id { get; set; }
        [Required]
       public string Text { get; set; }
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
       public virtual User Author { get; set; }
        [ForeignKey(nameof(CommentPost))]
        public int PostId { get; set; }
        public virtual Post CommentPost { get; set; }
        
    }
}
