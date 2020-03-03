using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Like
    {[Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Post))]
        public virtual Post Post { get; set; }
        [ForeignKey(nameof(Liker))]
        public Guid LikerId { get; set; }
        public virtual User Liker { get; set; }
    }
}
