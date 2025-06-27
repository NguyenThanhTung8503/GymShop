using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopGYM.ApiIntegration;
using ShopGYM.Data.EF;
using ShopGYM.Utilities.Constants;
using ShopGYM.ViewModels.Catalog.Checkout;
using ShopGYM.WebApp.Models;
using ShopGYM.WebApp.Service;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopGYM.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly ShopGYMDbContext _context;

        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient, ShopGYMDbContext context)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View(GetCheckoutViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel request)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = GetCheckoutViewModel();
                
            var orderDetails = model.CartItems.Select(item => new OrderDetailVm
            {
                ProductId = item.IdSanPham,
                Quantity = item.SoLuong,
                Total = item.Gia * item.SoLuong
            }).ToList();

            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var checkoutRequest = new CheckoutRequest
            {
                Address = request.CheckoutModel.Address,
                Name = request.CheckoutModel.Name,
                PhoneNumber = request.CheckoutModel.PhoneNumber,
                PhuongThucThanhToan = "COD",
                UserId = Guid.Parse(userId),
                OrderDetails = orderDetails
            };

            using var transaction = await _context.Database.BeginTransactionAsync();
            var maDonHang = await _orderApiClient.CreateOrder(checkoutRequest);
            await transaction.CommitAsync();

            TempData["SuccessMsg"] = "Đặt hàng thành công";
            return RedirectToAction("Index", "Order");
        }

        private CheckoutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            var checkoutVm = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return checkoutVm;
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

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            foreach (var item in currentCart)
            {
                if (item.IdSanPham == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.SoLuong = quantity;
                }
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

    }
}

