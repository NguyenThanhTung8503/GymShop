﻿using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.System.Users;

namespace ShopGYM.Application.Catalog.SanPham
{
    public interface IProductService
    { 
        Task<int> Create(ProductCreateRequest request);
        Task<int> Edit(ProductUpdateRequest request);
        Task<int> Delete(int IdSanPham);
        Task<bool> UpdatePrice(int IdSanPham, decimal GiaMoi);
        Task<bool> UpdateStock(int IdSanPham, int SoLuongMoi);
        Task<ProductVM> GetById(int IdSanPham);
        Task<ProductVM> Detail(int IdSanPham);
        Task<ApiResult<bool>> SetThumbnailImage(int id, ThumbnailAssignRequest request);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<PagedResult<ProductVM>> GetAllByMaDanhMuc(GetPublicProductPagingRequest request);
        Task<PagedResult<ProductVM>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImage(int IdSanPham, HinhAnhCreateRequest request);
        Task<int> RemoveImage(int IdHinhAnh);
        Task<int> UpdateImage(int IdHinhAnh, HinhAnhUpdateRequest request);
        Task<HinhAnhViewModel> GetImageById(int IdHinhAnh);
        Task<List<ProductVM>> GetFeatureProducts(int take);
        Task<List<ProductVM>> GetLatestProducts(int take);
        Task<List<HinhAnhViewModel>> GetListImages(int IdSanPham);

    }
}
