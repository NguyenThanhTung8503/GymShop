using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopGYM.ApiIntegration;
using ShopGYM.Utilities.Constants;
using ShopGYM.WebApp.Models;

namespace ShopGYM.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        public CartController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentCart);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _productApiClient.GetById(id);

            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            var existingItem = currentCart.FirstOrDefault(x => x.IdSanPham == id);
            if (existingItem != null)
            {
                existingItem.SoLuong += 1;
            }
            else
            {
                var cartItem = new CartItemViewModel()
                {
                    IdSanPham = id,
                    MoTa = product.MoTa,
                    Image = product.HinhAnhChinh,
                    TenSanPham = product.TenSanPham,
                    Gia = product.Gia,
                    SoLuong = 1
                };
                currentCart.Add(cartItem);
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

    }
}

