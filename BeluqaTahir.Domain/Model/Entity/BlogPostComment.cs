using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeluqaTahir.Domain.Model.Entity
{
    public class BlogPostComment:BaseEntity
    {
        public string Comment { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int? ParentId { get; set; }
        public virtual BlogPostComment Parent { get; set; }
        public virtual ICollection<BlogPostComment> Children { get; set; }
    }
}
