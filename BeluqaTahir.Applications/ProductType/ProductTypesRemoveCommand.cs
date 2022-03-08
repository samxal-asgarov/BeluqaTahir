using BeluqaTahir.Applications.Core.Infrastructure;
using BeluqaTahir.Domain.Model.DataContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.ProductType
{
    public class ProductTypesRemoveCommand : IRequest<CommandJsonRespons>
    {

        public int? Id { get; set; }

        public ProductTypesRemoveCommand()
        {

        }
        public ProductTypesRemoveCommand(int id)
        {
            Id = id;
        }
        public class IconsRemoveCommandHandler : IRequestHandler<ProductTypesRemoveCommand, CommandJsonRespons>
        {
            readonly BeluqaTahirDbContext db;
            public IconsRemoveCommandHandler(BeluqaTahirDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonRespons> Handle(ProductTypesRemoveCommand request, CancellationToken cancellationToken)
            {

                var response = new CommandJsonRespons();


                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Mellumat tamligi qorunmayib";
                    goto end;
                }

                var brand = await db.productTypes.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeleteByUserId == null);

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
