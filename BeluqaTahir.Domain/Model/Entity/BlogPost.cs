using BeluqaTahir.Domain.Model.Entity.Membership;
using System;
using System.Collections.Generic;

namespace BeluqaTahir.Domain.Model.Entity
{
    public class BlogPost : BaseEntity
    {
        public string ImagePati { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShopDescription { get; set; }

        public string Body { get; set; }

        public virtual ICollection<BlogPostComment> Comments { get; set; }

        



    }
}
