using Microsoft.AspNetCore.Mvc;
using ShopGYM.ApiIntegration;
using ShopGYM.ViewModels.Catalog.Checkout;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;

        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var request = new PagingRequestBase()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _orderApiClient.GetAllAdmin(request);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateOrderStatusRequest request)
        {
            try
            {
                var result = await _orderApiClient.UpdateStatus(request.OrderId, request.Status);
                return Ok(new { success = true });
            }
            catch (UnauthorizedAccessException)
            {
                return Ok(new { success = false, redirectToLogin = true });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message });
            }
        }
    }
}

