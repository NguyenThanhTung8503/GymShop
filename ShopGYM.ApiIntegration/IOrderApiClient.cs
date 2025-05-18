using ShopGYM.ViewModels.Catalog.Checkout;

namespace ShopGYM.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<int> CreateOrder(CheckoutRequest request);
        Task<bool> DeleteOrder(int id);
        Task<OrderVm> GetById(int id);
        Task<List<OrderVm>> GetAll();
    }
}
