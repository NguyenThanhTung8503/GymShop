using Microsoft.AspNetCore.Mvc;
using ShopGYM.WebApp.Models;
using ShopGYM.WebApp.Service;
using ShopGYM.ViewModels.Catalog.Checkout;
using System.Security.Claims;
using ShopGYM.ApiIntegration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopGYM.Utilities.Constants;
using ShopGYM.Data.EF;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using ShopGYM.WebApp.Models.Momo;
using PayPal.Api;

namespace ShopGYM.WebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMomoService _momoService;
        private readonly IOrderApiClient _orderApiClient;
        private readonly ShopGYMDbContext _context;
        private readonly IOptions<MomoOptionModel> _options;

        public PaymentController(
            IMomoService momoService,
            IOrderApiClient orderApiClient,
            ShopGYMDbContext context,
            IOptions<MomoOptionModel> options)
        {
            _momoService = momoService;
            _orderApiClient = orderApiClient;
            _context = context;
            _options = options;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentMomo(OrderInfoModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            model.OrderId = DateTime.UtcNow.Ticks.ToString();
            model.OrderInfo = $"Nội dung: Thanh toán qua Momo cho đơn hàng {model.OrderId}";

            // Lấy CartItems trực tiếp từ session
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }

            // Lưu CartItems vào session để sử dụng trong PaymentCallBack
            HttpContext.Session.SetString("CartItemsForCallback", JsonConvert.SerializeObject(currentCart));

            // Lưu thông tin người dùng vào session
            HttpContext.Session.SetString("CheckoutInfo", JsonConvert.SerializeObject(new
            {
                FullName = model.FullName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            }));

            var momoResponse = await _momoService.CreatePaymentAsync(model);
            if (momoResponse.ErrorCode == 0 && !string.IsNullOrEmpty(momoResponse.PayUrl))
            {
                return Redirect(momoResponse.PayUrl);
            }
            else
            {
                TempData["ErrorMsg"] = "Có lỗi xảy ra khi tạo thanh toán Momo. Vui lòng thử lại.";
                return RedirectToAction("Checkout", "Cart");
            }
        }

        [HttpGet]
        public async Task<IActionResult> PaymentCallBack(OrderInfoModel model)
        {
            var requestQuery = HttpContext.Request.Query;
            var errorCode = requestQuery["errorCode"];
            var message = requestQuery["message"];
            if (errorCode != "0" && message != "Success")
            {
                TempData["ErrorMsg"] = "Không nhận được thông tin kết quả thanh toán.";
                return RedirectToAction("Checkout", "Cart");
            }
            
            if (errorCode == "0" && message == "Success")
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // Lấy thông tin người dùng từ session
            var checkoutInfoJson = HttpContext.Session.GetString("CheckoutInfo");
                    var checkoutInfo = checkoutInfoJson != null
                        ? JsonConvert.DeserializeObject<dynamic>(checkoutInfoJson)
                        : new { FullName = "", Address = "", PhoneNumber = "" };

                    var checkoutModel = new CheckoutRequest
                    {
                        Name = checkoutInfo.FullName,
                        Address = checkoutInfo.Address,
                        PhoneNumber = checkoutInfo.PhoneNumber,
                        PhuongThucThanhToan = "Momo"
                    };

                    // Lấy CartItems từ session
                    var cartItemsJson = HttpContext.Session.GetString("CartItemsForCallback");
                    List<CartItemViewModel> currentCart = cartItemsJson != null
                        ? JsonConvert.DeserializeObject<List<CartItemViewModel>>(cartItemsJson)
                        : new List<CartItemViewModel>();

                    var orderDetails = currentCart.Select(item => new OrderDetailVm
                    {
                        ProductId = item.IdSanPham,
                        Quantity = item.SoLuong,
                        Total = item.Gia * item.SoLuong
                    }).ToList();

                    var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        checkoutModel.UserId = Guid.Parse(userId);
                    }

                    checkoutModel.OrderDetails = orderDetails;

                    var maDonHang = await _orderApiClient.CreateOrder(checkoutModel);
                    await transaction.CommitAsync();

                    // Xóa session sau khi sử dụng
                    HttpContext.Session.Remove("CartItemsForCallback");
                    HttpContext.Session.Remove("CheckoutInfo");

                    TempData["SuccessMsg"] = "Thanh toán thành công! Đơn hàng của bạn đã được xử lý.";
                    return RedirectToAction("Index", "Order");
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    TempData["ErrorMsg"] = "Có lỗi xảy ra khi lưu đơn hàng. Vui lòng thử lại.";
                    return RedirectToAction("Checkout", "Cart");
                }
            }
            else
            {
                TempData["ErrorMsg"] = $"Thanh toán thất bại với lỗi: {errorCode}, message: {requestQuery["message"]}";
                return RedirectToAction("Checkout", "Cart");
            }
        }

        
        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }
    }
}