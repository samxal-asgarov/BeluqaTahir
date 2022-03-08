using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.HappyClientss
{
    public  class AboutSingleQuery : IRequest<HappyClients>
    {
        public int Id { get; set; }


        public class AboutSingleQueryHandler : IRequestHandler<AboutSingleQuery, HappyClients>
        {
            readonly BeluqaTahirDbContext db;
            public AboutSingleQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<HappyClients> Handle(AboutSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.happyClients
                    .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                return blog;
            }
        }
    }
}
