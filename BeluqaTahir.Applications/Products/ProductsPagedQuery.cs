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

namespace BeluqaTahir.Applications.Products
{
    public class ProductsPagedQuery : IRequest<PagedViewModel<Product>>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;

        public class ProductsPagedQueryHandler : IRequestHandler<ProductsPagedQuery, PagedViewModel<Product>>
        {
            readonly BeluqaTahirDbContext db;
            public ProductsPagedQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Product>> Handle(ProductsPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.products.Where(b => b.CreateByUserId == null && b.DeleteByUserId == null).Include(i => i.ProductTypes).AsQueryable(); // silinmemisleri getirir

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);

                return new PagedViewModel<Product>(query, model.pageIndex, model.pageSize);

            }

        }
    }
}
