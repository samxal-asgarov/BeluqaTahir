using BeluqaTahir.Domain.Model.DataContexts;
using BeluqaTahir.Domain.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BeluqaTahir.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountdetailsController : Controller
    {
        private readonly BeluqaTahirDbContext _context;

        public AccountdetailsController(BeluqaTahirDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.accountdetails.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountdetails = await _context.accountdetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountdetails == null)
            {
                return NotFound();
            }

            return View(accountdetails);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountdetails = await _context.accountdetails.FindAsync(id);
            if (accountdetails == null)
            {
                return NotFound();
            }
            return View(accountdetails);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Email,Twwiter,Facebook,Instagram,Linkedin,Phone,Address,Id,CreateByUserId,CreateData,DeleteByUserId,DeleteData")] Accountdetails accountdetails)
        {
            if (id != accountdetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountdetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accountdetails);
        }

       
    }
}
