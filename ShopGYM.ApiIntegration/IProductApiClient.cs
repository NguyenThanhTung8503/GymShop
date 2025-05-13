using ShopGYM.ViewModels.Catalog.HinhAnh;
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
        Task<bool> DeleteProduct(int id);
        Task<bool> AddImage( HinhAnhCreateRequest request);
        Task<ProductVM> GetById(int id);
        Task<ProductVM> Detail(int id);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<List<ProductVM>> GetFeaturedProducts( int take);
        Task<List<ProductVM>> GetLatestProducts(int take);
    }
}
