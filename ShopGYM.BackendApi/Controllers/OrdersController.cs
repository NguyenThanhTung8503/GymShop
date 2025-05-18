using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopGYM.Application.Catalog.DonHang;
using ShopGYM.ViewModels.Catalog.Checkout;
using ShopGYM.ViewModels.Catalog.SanPham;

namespace ShopGYM.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _orderService.GetAll();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromForm] CheckoutRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maDonHang = await _orderService.CreateOrder(request);
            if (maDonHang == 0)
                return BadRequest();

            return Ok(maDonHang);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donHang = await _orderService.GetById(id);
            if (donHang == null)
                return BadRequest("Không thể tìm thấy don hang");

            return Ok(donHang);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedresult = await _orderService.Delete(id);
            if (affectedresult == 0)
                return BadRequest();

            return Ok();
        }

    }
}
