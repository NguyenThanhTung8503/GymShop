using Microsoft.AspNetCore.Mvc;
using ShopGYM.WebApp.Models;
using ShopGYM.WebApp.Service;

namespace ShopGYM.WebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMomoService _momoService;
        public PaymentController(IMomoService momoService)
        {
            _momoService = momoService;
        }


        [HttpPost]
        public async Task<IActionResult> CreatePaymentMomo(OrderInfoModel model)
        {
           var response = await _momoService.CreatePaymentAsync(model);
           return Redirect(response.PayUrl);
        }

        [HttpGet]
        public IActionResult PaymentCallBack()
        {
            var response = _momoService.PaymentExecuteAsync(Request.Query);
            return View(response);
        }
    }
}
