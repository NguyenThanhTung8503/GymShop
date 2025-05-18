using Microsoft.AspNetCore.Mvc;

namespace ShopGYM.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
