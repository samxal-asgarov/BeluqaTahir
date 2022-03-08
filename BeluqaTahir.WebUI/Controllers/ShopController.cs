using BeluqaTahir.Applications.ShopMolus;
using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using BeluqaTahir.Domain.Model.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeluqaTahir.WebUI.Controllers
{
    public class ShopController : Controller
    {

        readonly IMediator db;
        readonly BeluqaTahirDbContext bt;

        public ShopController(IMediator db, BeluqaTahirDbContext bt)
        {
            this.db = db;
            this.bt = bt;

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(ShopList query)
        {
            var respons = await db.Send(query);
            return View(respons);
        }

        public async Task<IActionResult> Details(ShopSingleQuery query )
        {
            var respons = await db.Send(query);

            return View(respons);
        }


        public async Task<IActionResult> ShoppingCard()
        {

            if (Request.Cookies.TryGetValue("basket", out string basketJson))
            {
                var data = JsonConvert.DeserializeObject<List<BasketViewModel>>(basketJson);

                foreach (var item in data)
                {
                    var product = await bt.products.FirstOrDefaultAsync(p => p.Id == item.ProductId);
                    item.Name = product.Name;
                    item.Price = product.Price;
                    item.ImagePati = product.ImagePati;
                }

                return View(data);
            }

            return View();
        }


    }
}
