using ShopGYM.WebApp.Models;
using ShopGYM.WebApp.Models.Momo;

namespace ShopGYM.WebApp.Service
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model);
        MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
    }
}
