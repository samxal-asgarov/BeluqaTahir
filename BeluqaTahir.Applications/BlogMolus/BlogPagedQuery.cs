using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using BeluqaTahir.Domain.Model.ViewModels;
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
  public  class BlogPagedQuery : IRequest<PagedViewModel<BlogPost>>
    {
      
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 4;

        public class BlogPagedQueryHandler : IRequestHandler<BlogPagedQuery, PagedViewModel<BlogPost>>
        {
            readonly BeluqaTahirDbContext db;
            public BlogPagedQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<BlogPost>> Handle(BlogPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.blogPosts.Include(b=>b.CreateByUser).Where(b =>  b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);

                return new PagedViewModel<BlogPost>(query, model.pageIndex , model.pageSize );
            }
        }
    }

}

