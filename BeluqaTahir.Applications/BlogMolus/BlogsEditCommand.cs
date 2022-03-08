using BeluqaTahir.Applications.Core.Extension;
using BeluqaTahir.Domain.Model.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.BlogMolus
{
    public   class BlogsEditCommand : BlogsViewModel, IRequest<int>
    {


        public class BlogsEditCommandHandler : IRequestHandler<BlogsEditCommand, int>
        {
            readonly BeluqaTahirDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;


            public BlogsEditCommandHandler(BeluqaTahirDbContext db, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(BlogsEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id != request.Id)
                {
                    return 0;
                }


                if (string.IsNullOrWhiteSpace(request.ImagePati) && request.file == null)
                {

                    ctx.ActionContext.ModelState.AddModelError("file", "Not Chosen");
                }

                var entity = await db.blogPosts.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }

                if (ctx.ModelStateValid())
                {
                    entity.Title = request.Title;
                    entity.Body = request.Body;
                    entity.ImagePati = request.ImagePati;
                    entity.Description = request.Description;
                    entity.ShopDescription = request.ShopDescription;





                    if (request.file != null)
                    {

                        string extension = Path.GetExtension(request.file.FileName);  //.jpg tapmaq ucundur.

                        request.ImagePati = $"{Guid.NewGuid()}{extension}";//imagenin name 


                        string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", request.ImagePati);

                        using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                        {
                            await request.file.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrWhiteSpace(entity.ImagePati))
                        {
                            System.IO.File.Delete(Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", entity.ImagePati));

                        }
                        entity.ImagePati = request.ImagePati;
                    }

                    await db.SaveChangesAsync(cancellationToken);
                    return entity.Id;



                }
                return 0;

            }

        }

    }
}
