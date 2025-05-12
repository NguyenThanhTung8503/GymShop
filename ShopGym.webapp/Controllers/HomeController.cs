using Microsoft.AspNetCore.Mvc;
using ShopGYM.ApiIntegration;
using ShopGYM.WebApp.Models;
using System.Diagnostics;

namespace ShopGYM.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel()
            {
                FeaturedProducts = _productApiClient.GetFeaturedProducts(4).Result,
                LatestProducts = _productApiClient.GetLatestProducts(6).Result
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
