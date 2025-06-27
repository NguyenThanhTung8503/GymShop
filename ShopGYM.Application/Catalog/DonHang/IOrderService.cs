using ShopGYM.ViewModels.Catalog.Checkout;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.Application.Catalog.DonHang
{
    public interface IOrderService
    {
        Task<int> CreateOrder(CheckoutRequest request);
        Task<List<OrderVm>> GetAll(Guid userId);
        Task<int> Delete(int Id);
        Task<OrderVm> GetById(int id);
        Task<int> Edit(OrderUpdateRequest request);
        Task<PagedResult<OrderVm>> GetAllAdmin(PagingRequestBase request);
        Task<int> UpdateStatus(int orderId, string status);

    }
}
