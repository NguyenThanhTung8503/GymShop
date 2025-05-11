using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll();

    }
}
