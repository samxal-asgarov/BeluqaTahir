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

namespace BeluqaTahir.Applications.Accountdetailss
{
    public class AccountdetailssSingleQuery : IRequest<Accountdetails>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }

        // nested class clasin icinde class
        public class AccountdetailsSingleQueryHandler : IRequestHandler<AccountdetailssSingleQuery, Accountdetails>
        {
            readonly BeluqaTahirDbContext db;
            public AccountdetailsSingleQueryHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<Accountdetails> Handle(AccountdetailssSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.accountdetails
                    .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}
