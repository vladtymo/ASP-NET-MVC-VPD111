using AspNet_MVC_VPD111.Data;
using AspNet_MVC_VPD111.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC_VPD111.Controllers
{
    public class ProductsController : Controller
    {
        Shop111DbContext ctx = new Shop111DbContext();

        public IActionResult Index()
        {
            // get data from the database
            var products = ctx.Products.ToList();

            return View(products);
        }

        // GET: show product details page
        public IActionResult Details(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            return View(item);
        }

        // GET: show create product page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: create product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            // create product in database
            ctx.Products.Add(product);
            ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // delete product by ID
        public IActionResult Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            ctx.Products.Remove(item);
            ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
