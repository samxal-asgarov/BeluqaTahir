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

namespace BeluqaTahir.Applications.ProductType
{
    public class ProductTypesPagedQuery : IRequest<PagedViewModel<ProductTypes>>
    {


        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;

        public class ProductTypesPagedQueryHandler : IRequestHandler<ProductTypesPagedQuery, PagedViewModel<ProductTypes>>
        {
            readonly BeluqaTahirDbContext db;
            public ProductTypesPagedQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<ProductTypes>> Handle(ProductTypesPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.productTypes.Where(b => b.CreateByUserId == null && b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);

                return new PagedViewModel<ProductTypes>(query, model.pageIndex, model.pageSize);
            }
        }
    }


}

