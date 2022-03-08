using BeluqaTahir.Applications.Core.Extension;
using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.HappyClientss
{
    public class AboutCreateComman : IRequest<HappyClients>
    {
        public string ImagePati { get; set; }
        public string FullName { get; set; }
        public string Answer { get; set; }
        public string Description { get; set; }
        public IFormFile file { get; set; }

        public class AboutCreateCommanHandler : IRequestHandler<AboutCreateComman, HappyClients>
        {
            readonly BeluqaTahirDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public AboutCreateCommanHandler(BeluqaTahirDbContext db, IActionContextAccessor ctx, IHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<HappyClients> Handle(AboutCreateComman model, CancellationToken cancellationToken)
            {

                if (ctx.ModelStateValid())
                {
                    HappyClients blog = new HappyClients();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    blog.ImagePati = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", blog.ImagePati);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }


                    blog.FullName = model.FullName;
                    blog.Answer = model.Answer;
                    blog.Description = model.Description;



                    db.Add(blog);
                    await db.SaveChangesAsync(cancellationToken);

                    return blog;
                }
                return null;
            }
        }
    }
}
