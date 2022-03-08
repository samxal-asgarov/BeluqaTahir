using BeluqaTahir.Applications.HappyClientss;
using BeluqaTahir.Domain.Model.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BeluqaTahir.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HappyClientsController : Controller
    {
        private readonly IMediator mediator;
        public HappyClientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public async Task<IActionResult> Index(AboutPagedQuery request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }

        public async Task<IActionResult> Details(AboutSingleQuery query)
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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutCreateComman command)
        {

            HappyClients model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }


        public async Task<IActionResult> Delete(AboutRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }



        public async Task<IActionResult> Edit(AboutSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            AboutViewModel vm = new AboutViewModel();

            vm.Id = respons.Id;
            vm.ImagePati = respons.ImagePati;
            vm.FullName = respons.FullName;
            vm.Answer = respons.Answer;
            vm.Description = respons.Description;

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }

    }
}
