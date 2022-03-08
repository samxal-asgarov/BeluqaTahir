using BeluqaTahir.Applications.Core.Extension;
using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.ProductType
{
   public class ProductTypesCreateCommand : IRequest<ProductTypes>
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public class ProductTypesCreateCommandHandler : IRequestHandler<ProductTypesCreateCommand, ProductTypes>
        {
            readonly BeluqaTahirDbContext db;
            readonly IActionContextAccessor ctx;
            public ProductTypesCreateCommandHandler(BeluqaTahirDbContext db, IActionContextAccessor ctx) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<ProductTypes> Handle(ProductTypesCreateCommand model, CancellationToken cancellationToken)
            {


                if (ctx.ModelStateValid())
                {
                    ProductTypes producttypes = new ProductTypes();
                    producttypes.Name = model.Name;
                    producttypes.Description = model.Description;

                    db.productTypes.Add(producttypes);
                    await db.SaveChangesAsync(cancellationToken);

                    return producttypes;
                }

                return null;
            }
        }
    }
}

