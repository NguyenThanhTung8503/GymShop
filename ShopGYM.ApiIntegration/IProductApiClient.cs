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
        Task<bool> EditProduct(ProductUpdateRequest request);
        Task<bool> DeleteProduct(int id);
        Task<bool> AddImage( HinhAnhCreateRequest request);
        Task<bool> UpdateImage( HinhAnhUpdateRequest request);
        Task<bool> DeleteImage(int id);
        Task<ProductVM> GetById(int id);
        Task<List<HinhAnhViewModel>> GetListImages(int id);
        Task<HinhAnhViewModel> GetImageById(int id);
        Task<ProductVM> Detail(int id);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<ApiResult<bool>> SetThumbnailImage(int id, ThumbnailAssignRequest request);
        Task<List<ProductVM>> GetFeaturedProducts( int take);
        Task<List<ProductVM>> GetLatestProducts(int take);
    }
}
