using ShopGYM.ViewModels.Catalog.Checkout;

namespace ShopGYM.Application.Catalog.DonHang
{
    public interface IOrderService
    {
        Task<int> CreateOrder(CheckoutRequest request);
        Task<int> CreateOrderDetail(OrderDetailVm request, int id);
        Task<List<OrderVm>> GetAll();
        Task<int> Delete(int Id);
        Task<OrderVm> GetById(int id);
    }
}
