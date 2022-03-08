using BeluqaTahir.Applications.Products;
using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace BeluqaTahir.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;
        private readonly BeluqaTahirDbContext db;
        public ProductsController(IMediator mediator, BeluqaTahirDbContext db)
        {
            this.mediator = mediator;
            this.db = db;
        }


        public async Task<IActionResult> Index(ProductsPagedQuery query)
        {
            var respons = await mediator.Send(query);
            return View(respons);
        }

        public async Task<IActionResult> Details(ProductsSingleQuery query)
        {


            var respons = await mediator.Send(query);
            if (respons == null)
            {
                return NotFound();
            }


            return View(respons);
        }



        public IActionResult Create()
        {
            ViewData["ProductTypesId"] = new SelectList(db.productTypes.Where(b => b.DeleteByUserId == null), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductsCreateCommand command)
        {

            Product model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));



            ViewData["ProductTypesId"] = new SelectList(db.productTypes.Where(b => b.DeleteByUserId == null), "Id", "Name", command.ProductTypes);

            return View(command);
        }


        public async Task<IActionResult> Delete(ProductsRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }


        public async Task<IActionResult> Edit(ProductsSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            ProductsViewModel vm = new ProductsViewModel();

            vm.Id = respons.Id;
            vm.Name = respons.Name;
            vm.Price = respons.Price;
            vm.ImagePati = respons.ImagePati;
            vm.Description = respons.Description;
            vm.ShopDescription = respons.ShopDescription;
            vm.FullName = respons.FullName;
            vm.ProductTypesId = respons.ProductTypesId;

            ViewData["ProductTypesId"] = new SelectList(db.productTypes.Where(b => b.DeleteByUserId == null), "Id", "Name");

            return View(vm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(ProductEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            ViewData["ProductTypesId"] = new SelectList(db.productTypes.Where(b => b.DeleteByUserId == null), "Id", "Name", command.ProductTypes);

            return View(command);



        }
    }
}
