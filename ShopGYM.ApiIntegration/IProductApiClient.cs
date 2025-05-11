using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVM>> GetProductsPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<bool> EditProduct(ProductUpdateRequets request);
        Task<ProductVM> GetById(int id);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
    }
}
