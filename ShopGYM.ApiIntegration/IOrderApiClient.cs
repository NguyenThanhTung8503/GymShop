using ShopGYM.ViewModels.Catalog.Checkout;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<int> CreateOrder(CheckoutRequest request);
        Task<bool> DeleteOrder(int id);
        Task<OrderVm> GetById(int id);
        Task<List<OrderVm>> GetAll(Guid userId);
        Task<PagedResult<OrderVm>> GetAllAdmin(PagingRequestBase request);
        Task<bool> UpdateStatus(int orderId, string status);
    }
}
