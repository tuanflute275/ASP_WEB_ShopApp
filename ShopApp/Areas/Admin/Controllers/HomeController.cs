using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShopApp.Data;

namespace ShopApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Route("Admin")]
    public class HomeController : Controller
    {
        private readonly ShopAppAspWebContext _context;
        private readonly INotyfService _toastNotification;
        public HomeController(ShopAppAspWebContext context, INotyfService toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
