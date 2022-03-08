using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.ProductType
{
  public  class ProductTypesSingleQuery : IRequest<ProductTypes>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }


        // nested class clasin icinde class
        public class ProductTypesSingleQueryHandler : IRequestHandler<ProductTypesSingleQuery, ProductTypes>
        {
            readonly BeluqaTahirDbContext db;
            public ProductTypesSingleQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<ProductTypes> Handle(ProductTypesSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.productTypes
                    .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                return blog;
            }
        }

    }

}

