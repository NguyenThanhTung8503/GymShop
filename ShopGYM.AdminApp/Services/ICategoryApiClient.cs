using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll();

    }
}
