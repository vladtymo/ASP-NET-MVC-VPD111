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

        // delete product by ID
        public IActionResult Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            ctx.Products.Remove(item);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
