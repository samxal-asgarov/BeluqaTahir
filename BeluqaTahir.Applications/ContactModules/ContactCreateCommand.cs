using BeluqaTahir.Applications.Core.Extension;
using BeluqaTahir.Applications.Core.Infrastructure;
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

namespace BeluqaTahir.Applications.ContactModules
{
  public  class ContactCreateCommand:IRequest<CommandJsonRespons>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public class ContactCreateCommandHandler : IRequestHandler<ContactCreateCommand, CommandJsonRespons>
        {
            readonly BeluqaTahirDbContext db;
            readonly IActionContextAccessor ctx;
            public ContactCreateCommandHandler(BeluqaTahirDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<CommandJsonRespons> Handle(ContactCreateCommand request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonRespons();
                if (ctx.ModelStateValid())
                {
                    var contact = new Contact();
                    contact.Name = request.Name;
                    contact.Email = request.Email;
                    contact.Subject = request.Subject;
                    contact.Content = request.Content;
                    db.contacts.Add(contact);
                    await db.SaveChangesAsync(cancellationToken);
                    response.Error = false;
                    response.Message = "Successfully";
                    return response;
                }
                response.Error = true;
                response.Message = "Error,Try again";
                return response;
            }
        }
    }
}
