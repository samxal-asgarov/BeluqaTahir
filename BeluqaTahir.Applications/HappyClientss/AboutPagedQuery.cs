using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using BeluqaTahir.Domain.Model.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.HappyClientss
{
   public class AboutPagedQuery : IRequest<PagedViewModel<HappyClients>>
    {

        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 6;

        public class AboutPagedQueryHandler : IRequestHandler<AboutPagedQuery, PagedViewModel<HappyClients>>
        {
            readonly BeluqaTahirDbContext db;
            public AboutPagedQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<HappyClients>> Handle(AboutPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.happyClients.Where(b => b.CreateByUserId == null && b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);

                return new PagedViewModel<HappyClients>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}

