using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.ShopMolus
{
    public class ShopList : IRequest<ShopViewModel>
    {
        public class ShopListHandler : IRequestHandler<ShopList, ShopViewModel>
        {
            readonly BeluqaTahirDbContext db;
            public ShopListHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<ShopViewModel> Handle(ShopList model, CancellationToken cancellationToken)
            {
                ShopViewModel vm = new ShopViewModel();

                vm.productTypes = await db.productTypes.Where(b => b.DeleteByUserId == null).ToListAsync(cancellationToken); // silinmemisleri getirir
                vm.Products = await db.products
                    .Include(p=>p.ProductTypes)
                    .Where(b => b.DeleteByUserId == null).ToListAsync(cancellationToken); // silinmemisleri getirir

                return vm;

            }
        }
    }
}
