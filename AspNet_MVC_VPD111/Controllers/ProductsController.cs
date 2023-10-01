using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNet_MVC_VPD111.Controllers
{
    public class ProductsController : Controller
    {
        Shop111DbContext ctx = new Shop111DbContext();

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(ctx.Categories.ToList(), 
                                                nameof(Category.Id), 
                                                nameof(Category.Name));
        }

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
            // Ways of transfering data to View
            // 1 - using View(model)
            // 2 - using TempData: this.TempData["key"] = value
            // 3 - using ViewBag: this.ViewBag.Property = value
            LoadCategories();

            return View();
        }

        // POST: create product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            // create product in database
            ctx.Products.Add(product);
            ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: show updte product page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            LoadCategories();

            return View(item);
        }

        // POST: update product
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            // create product in database
            ctx.Products.Update(product);
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
