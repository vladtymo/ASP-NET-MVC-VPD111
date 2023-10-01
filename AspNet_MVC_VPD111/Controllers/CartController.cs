using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AspNet_MVC_VPD111.Helpers;
using DataAccess.Data;

namespace AspNet_MVC_VPD111.Controllers
{
    public class CartController : Controller
    {
        private readonly Shop111DbContext ctx;

        public CartController(Shop111DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>("cart_items") ?? new();

            var products = ctx.Products.Where(x => ids.Contains(x.Id)).ToList();

            return View(products);
        }

        public IActionResult Add(int id)
        {
            // read data from browser storage
            var ids = HttpContext.Session.Get<List<int>>("cart_items");

            if (ids == null) ids = new();
            
            ids.Add(id);

            // write data to browser storage
            HttpContext.Session.Set("cart_items", ids);

            return RedirectToAction("Index", "Home");
        }
    }
}
