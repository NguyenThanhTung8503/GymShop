using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopGYM.Application.Catalog.DonHang;
using ShopGYM.ViewModels.Catalog.Checkout;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

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

        [HttpGet("{userId}/getall")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var order = await _orderService.GetAll(userId);
            return Ok(order);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllAdmin([FromQuery] PagingRequestBase request)
        {
            var order = await _orderService.GetAllAdmin(request);
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

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] OrderUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.UserId = id;
            var affectedResult = await _orderService.Edit(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}/status")]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateOrderStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var affectedRows = await _orderService.UpdateStatus(id, request.Status);
            if (affectedRows == 0)
                return BadRequest("Không thể cập nhật trạng thái đơn hàng");

            return Ok();
        }
    }
}
