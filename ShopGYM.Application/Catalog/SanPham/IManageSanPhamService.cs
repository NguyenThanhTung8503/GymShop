using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.Application.Catalog.SanPham
{
    public interface IManageSanPhamService
    {
        Task<int> Create(SanPhamCreateRequest request);
        Task<int> Update(SanPhamUpdateRequest request);
        Task<bool> UpdatePrice(int IdSanPham, decimal GiaMoi);

        Task<SanPhamViewModel> GetById(int IdSanPham);
        Task<bool> UpdateStock(int IdSanPham, int SoLuongMoi);
        Task<int> Delete(int IdSanPham);
        Task<PagedResult<SanPhamViewModel>> GetAllPaging(GetManageSanPhamPagingRequest request);
        Task<int> AddImage(int IdSanPham, HinhAnhCreateRequest request);
        Task<int> RemoveImage(int IdHinhAnh);
        Task<int> UpdateImage(int IdHinhAnh, HinhAnhUpdateRequest request);
        Task<HinhAnhViewModel> GetImageById(int IdHinhAnh);

        Task<List<HinhAnhViewModel>> GetListImages(int IdSanPham);


    }
}
