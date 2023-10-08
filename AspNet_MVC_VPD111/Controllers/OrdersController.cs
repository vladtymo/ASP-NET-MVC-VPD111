using AspNet_MVC_VPD111.Helpers;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNet_MVC_VPD111.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Shop111DbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public OrdersController(Shop111DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            var items = ctx.Orders.Where(x => x.UserId == CurrentUserId).ToList();

            return View(items);
        }

        public IActionResult Create()
        {
            var ids = HttpContext.Session.Get<List<int>>("cart_items") ?? new();
            var products = ctx.Products.Where(x => ids.Contains(x.Id)).ToList();

            var order = new Order()
            {
                Date = DateTime.Now,
                Products = products,
                TotalPrice = products.Sum(x => x.Price),
                UserId = CurrentUserId
            };

            ctx.Orders.Add(order);
            ctx.SaveChanges();

            // cleat cart items
            HttpContext.Session.Remove("cart_items");

            return RedirectToAction("Index", "Home");
        }
    }
}
