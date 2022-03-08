using BeluqaTahir.Applications.Core.Extension;
using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace BeluqaTahir.Applications.Products
{
    public class ProductsCreateCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string ShopDescription { get; set; }
        public string ImagePati { get; set; }
        public int ProductTypesId { get; set; }

        public virtual ProductTypes ProductTypes { get; set; }
        public IFormFile file { get; set; }


        public class ProductsCreateCommandHandler : IRequestHandler<ProductsCreateCommand, Product>
        {
            readonly BeluqaTahirDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public ProductsCreateCommandHandler(BeluqaTahirDbContext db, IActionContextAccessor ctx, IHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;

            }
            public async Task<Product> Handle(ProductsCreateCommand model, CancellationToken cancellationToken)
            {


                if (ctx.ModelStateValid())
                {
                    Product product = new Product();


                  
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    product.ImagePati = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "assets", "images", product.ImagePati);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.Description = model.Description;
                    product.FullName = model.FullName;
                    product.ProductTypesId = model.ProductTypesId;
                    product.ShopDescription = model.ShopDescription;

                    db.products.Add(product);
                    await db.SaveChangesAsync(cancellationToken);

                    return product;
                }

                return null;

                //ctx.ActionContext.ModelState.IsValid if icinde bu cur yoxlamamaq ucun extension yaziiriq.
            }
        }
    }

}



