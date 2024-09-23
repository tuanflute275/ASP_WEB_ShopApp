using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using X.PagedList;

namespace ShopApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly ShopAppAspWebContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private readonly INotyfService _toastNotification;

        public OrderController(ShopAppAspWebContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, INotyfService notyfService)
        {
            _context = context;
            _environment = environment;
            _toastNotification = notyfService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? sort, int page = 1)
        {
            page = page <= 1 ? 1 : page;
            int limit = 10;
            var orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).ToListAsync();
            if (!string.IsNullOrEmpty(sort))
            {
                ViewBag.sorts = sort;

                Console.WriteLine(sort);
                switch (sort)
                {
                    case "Id-ASC":
                        orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).OrderBy(x => x.OrderId).ToListAsync();
                        break;
                    case "Id-DESC":
                        orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).ToListAsync();
                        break;

                    case "Created_Date-ASC":
                        orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).OrderBy(x => x.OrderId).ToListAsync();
                        break;
                    case "Created_Date-DESC":
                        orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).OrderByDescending(x => x.OrderId).ToListAsync();
                        break;

                    case "Status-ASC":
                        orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).OrderBy(x => x.OrderId).ToListAsync();
                        break;
                    case "Status-DESC":
                        orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).OrderByDescending(x => x.OrderId).ToListAsync();
                        break;
                }

            }
            var pagedData = orders.ToPagedList(page, limit);
            return View(pagedData);
        }
    }
}
