using BeluqaTahir.Applications.Core.Infrastructure;
using BeluqaTahir.Domain.Model.DataContexts;
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
  public  class ProductsRemoveCommand : IRequest<CommandJsonRespons>
    {

        public int? Id { get; set; }


        public class BlogsRemoveCommandHandler : IRequestHandler<ProductsRemoveCommand, CommandJsonRespons>
        {
            readonly BeluqaTahirDbContext db;
            public BlogsRemoveCommandHandler(BeluqaTahirDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonRespons> Handle(ProductsRemoveCommand request, CancellationToken cancellationToken)
            {

                var response = new CommandJsonRespons();


                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Mellumat tamligi qorunmayib";
                    goto end;
                }

                var brand = await db.products.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeleteByUserId == null);

                if (brand == null)
                {
                    response.Error = true;
                    response.Message = "Melumat movcud deyildir.";
                    goto end;
                }

                brand.DeleteByUserId = 1;
                brand.DeleteData = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);

                response.Error = false;
                response.Message = "ugurlu elemlyat";
            end:
                return response;
            }

        }
    }
}
