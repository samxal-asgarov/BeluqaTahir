using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using BeluqaTahir.Domain.Model.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeluqaTahir.Applications.BlogMolus
{
    public class BlogList : IRequest<BlogViewModel>
    {
        public int Id { get; set; }
        public class BlogListHandler : IRequestHandler<BlogList, BlogViewModel>
        {
            readonly BeluqaTahirDbContext db;
            public BlogListHandler(BeluqaTahirDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<BlogViewModel> Handle(BlogList model, CancellationToken cancellationToken)
            {
                BlogViewModel vm = new BlogViewModel();

                vm.BlogPosts = await db.blogPosts
                    .Include(m => m.CreateByUser)
                    .Include(m => m.Comments)
                    .ThenInclude(m => m.CreateByUser)
                    .Include(m => m.Comments)
                    .ThenInclude(m => m.Children)
                    .FirstOrDefaultAsync(m => m.Id == model.Id, cancellationToken);

                // vm.Comments = await db.BlogPostComments.Where(c => c.DeleteData == null && c.BlogPostId==vm.BlogPosts.Id).ToListAsync();

                return vm;

            }
        }
    }

}

