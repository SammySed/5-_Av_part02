using Delete.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Delete.Controllers
{
    public class ClientController : Controller
    {
        private readonly Delete.Data.AppCont _appCont;

        public ClientController(Delete.Data.AppCont appCont)
        {
            _appCont = appCont;
        }

        //GET: Produtocontroller

        public async Task<ActionResult> Index()
        {
            var allProducts = await _appCont.Client.ToListAsync();
            return View(allProducts);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            _appCont.Client.Add(client);
            await _appCont.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _appCont.Client.FindAsync(id);

            if (client == null)
            {
                return BadRequest();
            }
            return View(client);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = await _appCont.Client.FindAsync(id);
            if (client == null)
            {
                return BadRequest();
            }
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var client = await _appCont.Client.FindAsync(id);
            _appCont.Client.Remove(client);
            await _appCont.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
