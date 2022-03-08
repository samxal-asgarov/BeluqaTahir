using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.Products
{
    public class ProductsSingleQuery : IRequest<Product>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }
        public int IconsId { get; set; }


        // nested class clasin icinde class
        public class ProductsSingleQueryHandler : IRequestHandler<ProductsSingleQuery, Product>
        {
            readonly BeluqaTahirDbContext db;
            public ProductsSingleQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<Product> Handle(ProductsSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.products
                   .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                return blog;
            }

            
        }


    }

}

