using BeluqaTahir.Applications.Core.Extension;
using BeluqaTahir.Domain.Model.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.ProductType
{
    public  class ProductTypesEditCommand : ProductTypesViewModel, IRequest<int>
    {


        public class EducationEditCommandHandler : IRequestHandler<ProductTypesEditCommand, int>
        {
            readonly BeluqaTahirDbContext db;
            readonly IActionContextAccessor ctx;

            public EducationEditCommandHandler(BeluqaTahirDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<int> Handle(ProductTypesEditCommand
                model, CancellationToken cancellationToken)
            {

                if (model.Id == null || model.Id < 0)

                    return 0;




                var entity = await db.productTypes.FirstOrDefaultAsync(b => b.Id == model.Id && b.DeleteByUserId == null);

                if (ctx.ModelStateValid())
                {
                    entity.Name = model.Name;
                    entity.Description = model.Description;
                    await db.SaveChangesAsync(cancellationToken);
                    return entity.Id;
                }


                return 0;
            }
        }

    }
}
