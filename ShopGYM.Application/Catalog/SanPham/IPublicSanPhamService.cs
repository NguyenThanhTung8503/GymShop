using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.Application.Catalog.SanPham
{
    public interface IPublicSanPhamService
    {
        Task<PagedResult<SanPhamViewModel>> GetAllByMaDanhMuc(GetPublicSanPhamPagingRequest request);
    }
}
