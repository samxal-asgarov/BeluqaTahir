using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.BlogMolus
{
  public  class BlogSingleQuery : IRequest<BlogPost>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }


        // nested class clasin icinde class
        public class BlogSingleQueryHandler : IRequestHandler<BlogSingleQuery, BlogPost>
        {
            readonly BeluqaTahirDbContext db;
            public BlogSingleQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<BlogPost> Handle(BlogSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.blogPosts
                    .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}


