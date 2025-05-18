using ShopGYM.Data.EF;
using ShopGYM.Data.Entities;
using ShopGYM.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using ShopGYM.ViewModels.Common;
using ShopGYM.ViewModels.Catalog.SanPham;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using ShopGYM.Application.Common;
using ShopGYM.ViewModels.Catalog.HinhAnh;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace ShopGYM.Application.Catalog.SanPham
{
    public class ProductService : IProductService
    {
        private readonly ShopGYMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ProductService(ShopGYMDbContext context, IStorageService storageService)

        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {

            var sanpham = new Data.Entities.SanPham()
            {
                TenSanPham = request.TenSanPham,
                //MaDanhMuc = request.MaDanhMuc,
                Gia = request.Gia,
                MoTa = request.MoTa,
                KichThuoc = request.KichThuoc,
                MauSac = request.MauSac,
                SoLuongTon = request.SoLuongTon,
                NgayTao = DateTime.Now,
                NoiBat = false,
            };
            //Save Images
            if (request.ThumbnailImage != null)
            {
                sanpham.HinhAnhs = new List<HinhAnh>()
                {
                    new HinhAnh()
                    {
                        Mota = "Thumbnail Images",
                        NgayTao = DateTime.Now,
                        DuongDan = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = false
                    }
                };
            }

            _context.SanPhams.Add(sanpham);
            await _context.SaveChangesAsync();
            return sanpham.MaSanPham;
        }
        public async Task<int> Edit(ProductUpdateRequest request)
        {
            var sanpham = await _context.SanPhams.FindAsync(request.Id);
            if (sanpham == null) throw new ShopGYMException($"Khong the tim thay san pham voi id: {request.Id}");
            sanpham.TenSanPham = request.TenSanPham;
            sanpham.MoTa = request.MoTa;
            sanpham.MauSac = request.MauSac;
            sanpham.KichThuoc = request.KichThuoc;
            sanpham.Gia = request.Gia;
            sanpham.SoLuongTon = request.SoLuongTon;
            //Save Images
            if (request.ThumbnailImage != null)
            {
                var thumbNailImage = await _context.HinhAnhs.FirstOrDefaultAsync(i => i.MaSanPham == request.Id);
                if (thumbNailImage != null)
                {
                    thumbNailImage.DuongDan = await SaveFile(request.ThumbnailImage);
                    _context.HinhAnhs.Update(thumbNailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int IdSanpham)
        {
            var sanpham = await _context.SanPhams.FindAsync(IdSanpham);
            if (sanpham == null) throw new ShopGYMException($"Khong the tim thay san pham: {IdSanpham}");

            var hinhanh = _context.HinhAnhs.Where(i => i.MaSanPham == IdSanpham);
            foreach (var image in hinhanh)
            {
                await _storageService.DeleteFileAsync(image.DuongDan);
                _context.HinhAnhs.Remove(image);
            }

            _context.SanPhams.Remove(sanpham);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductVM>> GetAllPaging(GetManageProductPagingRequest request)
        {
            // Tạo truy vấn
            var query = from sp in _context.SanPhams
                        join pic in _context.ProductInCategories on sp.MaSanPham equals pic.MaSanPham into sppic
                        from pic in sppic.DefaultIfEmpty()
                        join dm in _context.DanhMucs on pic.MaDanhMuc equals dm.MaDanhMuc into dmsp
                        from dm in dmsp.DefaultIfEmpty()
                        join ha in _context.HinhAnhs on sp.MaSanPham equals ha.MaSanPham into spha
                        select new
                        {
                            sp,
                            pic,
                            dm,
                            ha = spha.FirstOrDefault(h => h.IsDefault == true) ?? spha.FirstOrDefault() // Lấy hình ảnh IsDefault == true, nếu không có thì lấy ảnh đầu tiên
                        };


            // Áp dụng bộ lọc
            if (request.MaDanhMuc != null && request.MaDanhMuc != 0)
            {
                query = query.Where(x => x.pic.MaDanhMuc == request.MaDanhMuc);
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.sp.TenSanPham.Contains(request.Keyword) ||
                                        x.sp.MoTa != null && x.sp.MoTa.Contains(request.Keyword));
            }
            // Tính tổng số bản ghi (TotalRecords)
            int totalRecords = await query.CountAsync();

            var items = await query
                .Skip((request.PageIndex - 1) * request.PageSize) // Bỏ qua (PageIndex - 1) * PageSize bản ghi
                .Take(request.PageSize) // Lấy số bản ghi bằng PageSize
                .Select(x => new ProductVM
                {
                    MaSanPham = x.sp.MaSanPham,
                    TenSanPham = x.sp.TenSanPham,
                    TenDanhMuc = x.dm.TenDanhMuc,
                    Gia = x.sp.Gia,
                    MoTa = x.sp.MoTa,
                    KichThuoc = x.sp.KichThuoc,
                    MauSac = x.sp.MauSac,
                    SoLuongTon = x.sp.SoLuongTon,
                    HinhAnhChinh = x.ha.DuongDan
                })
                .ToListAsync(); // Thực thi truy vấn và trả về danh sách SanPhamViewModel

            // Trả về kết quả phân trang
            return new PagedResult<ProductVM>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
        }

        public async Task<PagedResult<ProductVM>> GetAllByMaDanhMuc(GetPublicProductPagingRequest request)
        {
            // Tạo truy vấn
            var query = from sp in _context.SanPhams
                        join pic in _context.ProductInCategories on sp.MaSanPham equals pic.MaSanPham
                        join dm in _context.DanhMucs on pic.MaDanhMuc equals dm.MaDanhMuc
                        join ha in _context.HinhAnhs on sp.MaSanPham equals ha.MaSanPham into hinhAnhs
                        from ha in hinhAnhs.DefaultIfEmpty() // Kết nối trái cho hình ảnh
                        where ha == null || ha.IsDefault == true
                        select new { sp, pic, ha, dm };

            // Áp dụng bộ lọc
            if (request.IdDanhMuc.HasValue && request.IdDanhMuc > 0)
            {
                query = query.Where(x => x.pic.MaDanhMuc == request.IdDanhMuc.Value);
            }

            // Tính tổng số bản ghi (TotalRecords)
            int totalRecords = await query.CountAsync();

            var items = await query
                .Skip((request.PageIndex - 1) * request.PageSize) // Bỏ qua (PageIndex - 1) * PageSize bản ghi
                .Take(request.PageSize) // Lấy số bản ghi bằng PageSize
                .Select(x => new ProductVM
                {
                    MaSanPham = x.sp.MaSanPham,
                    TenSanPham = x.sp.TenSanPham,
                    TenDanhMuc = x.dm.TenDanhMuc,
                    Gia = x.sp.Gia,
                    MoTa = x.sp.MoTa,
                    KichThuoc = x.sp.KichThuoc,
                    MauSac = x.sp.MauSac,
                    SoLuongTon = x.sp.SoLuongTon,
                    HinhAnhChinh = x.ha != null ? x.ha.DuongDan : null
                })
                .ToListAsync(); // Thực thi truy vấn và trả về danh sách SanPhamViewModel

            // Trả về kết quả phân trang
            return new PagedResult<ProductVM>
            {
                TotalRecords = totalRecords,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = items
            };
        }


        public async Task<bool> UpdatePrice(int IdSanPham, decimal GiaMoi)
        {
            var sanpham = await _context.SanPhams.FindAsync(IdSanPham);
            if (sanpham == null) throw new ShopGYMException($"Khong the tim thay san pham voi Id: {IdSanPham}");
            sanpham.Gia = GiaMoi;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int IdSanPham, int SoLuongMoi)
        {
            var sanpham = await _context.SanPhams.FindAsync(IdSanPham);
            if (sanpham == null) throw new ShopGYMException($"Khong the tim thay san pham voi Id: {IdSanPham}");
            sanpham.SoLuongTon = SoLuongMoi;
            return await _context.SaveChangesAsync() > 0;
        }


        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<int> AddImage(int IdSanPham, HinhAnhCreateRequest request)
        {
            var hinhanh = new HinhAnh()
            {
                Mota = request.MoTa,
                NgayTao = DateTime.Now,
                MaSanPham = IdSanPham,
                IsDefault = false
            };

            if (request.ImageFile != null)
            {
                hinhanh.DuongDan = await SaveFile(request.ImageFile);
            }
            _context.HinhAnhs.Add(hinhanh);
            await _context.SaveChangesAsync();
            return hinhanh.MaHinhAnh;
        }

        public async Task<int> RemoveImage(int IdHinhAnh)
        {
            var hinhanh = await _context.HinhAnhs.FindAsync(IdHinhAnh);
            if (hinhanh == null)
                throw new ShopGYMException($"Khong the tim thay hinh anh voi id: {IdHinhAnh}");
            _context.HinhAnhs.Remove(hinhanh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int IdHinhAnh, HinhAnhUpdateRequest request)
        {
            var hinhanh = await _context.HinhAnhs.FindAsync(IdHinhAnh);
            if (hinhanh == null)
                throw new ShopGYMException($"Khong the tim thay hinh anh voi id: {IdHinhAnh}");

            if (request.ImageFile != null)
            {
                hinhanh.DuongDan = await SaveFile(request.ImageFile);
            }
            if (request.MoTa != null)
            {
                hinhanh.Mota = request.MoTa;
            }
            hinhanh.NgayTao = DateTime.Now;

            _context.HinhAnhs.Update(hinhanh);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductVM> GetById(int IdSanPham)
        {
            var sanpham = await _context.SanPhams.FindAsync(IdSanPham);
            if (sanpham == null)
                return null;
            var danhmucs = await (from dm in _context.DanhMucs
                                  join pic in _context.ProductInCategories on dm.MaDanhMuc equals pic.MaDanhMuc
                                  where pic.MaSanPham == IdSanPham
                                  select dm.TenDanhMuc).ToListAsync();

            var hinhanh = await _context.HinhAnhs.Where(x => x.MaSanPham == IdSanPham).FirstOrDefaultAsync();

            var sanphamtViewModel = new ProductVM()
            {
                MaSanPham = sanpham.MaSanPham,
                TenSanPham = sanpham.TenSanPham,
                Category = danhmucs,
                Gia = sanpham.Gia,
                MoTa = sanpham.MoTa,
                KichThuoc = sanpham.KichThuoc,
                MauSac = sanpham.MauSac,
                SoLuongTon = sanpham.SoLuongTon,
                HinhAnhChinh = hinhanh != null ? hinhanh.DuongDan : "no-image.jpg",
            };
            return sanphamtViewModel;
        }

        public async Task<HinhAnhViewModel> GetImageById(int IdHinhAnh)
        {
            var hinhanh = await _context.HinhAnhs.FindAsync(IdHinhAnh);
            if (hinhanh == null)
                throw new ShopGYMException($"Khong the tim thay hinh anh voi id: {IdHinhAnh}");

            var viewModel = new HinhAnhViewModel()
            {
                Mota = hinhanh.Mota,
                NgayTao = hinhanh.NgayTao,
                MaHinhAnh = hinhanh.MaHinhAnh,
                DuongDan = hinhanh.DuongDan,
                MaSanPham = hinhanh.MaSanPham,
                IsDefault = hinhanh.IsDefault == true
            };
            return viewModel;
        }

        public async Task<List<HinhAnhViewModel>> GetListImages(int IdSanPham)
        {
            var product = await _context.SanPhams.FindAsync(IdSanPham);
            if (product == null)
            {
                return new List<HinhAnhViewModel>();
            }
            var images = await _context.HinhAnhs.Where(x => x.MaSanPham == IdSanPham)
                .Select(i => new HinhAnhViewModel()
                {
                    Mota = i.Mota,
                    NgayTao = i.NgayTao,
                    MaHinhAnh = i.MaHinhAnh,
                    DuongDan = i.DuongDan,
                    MaSanPham = i.MaSanPham,
                    TenSanPham = product.TenSanPham,
                    IsDefault = i.IsDefault
                }).ToListAsync();
            return images;
        }


        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var product = await _context.SanPhams.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<bool>($"Sản phẩm với id: {id} không tồn tại");
            }

            foreach (var category in request.Categories)
            {
                var productInCategory = await _context.ProductInCategories
                    .FirstOrDefaultAsync(x => x.MaDanhMuc == int.Parse(category.Id)
                    && x.MaSanPham == id);
                if (productInCategory != null && category.Selected == false)
                {
                    _context.ProductInCategories.Remove(productInCategory);
                }
                else if (productInCategory == null && category.Selected)
                {
                    await _context.ProductInCategories.AddAsync(new ProductInCategory()
                    {
                        MaDanhMuc = int.Parse(category.Id),
                        MaSanPham = id
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> SetThumbnailImage(int id, ThumbnailAssignRequest request)
        {
            var product = await _context.SanPhams.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<bool>($"Không có hình ảnh nào cho sản phẩm: {id}");
            }

            var images = await _context.HinhAnhs
                .Where(x => x.MaSanPham == id)
                .ToListAsync();

            if (images == null || !images.Any())
            {
                return new ApiErrorResult<bool>("Không có hình ảnh nào cho sản phẩm này");
            }
            // Tìm ảnh hiện tại có IsDefault = true
            var currentDefaultImage = images.FirstOrDefault(x => x.IsDefault);

            foreach (var item in request.Images)
            {
                var image = images.FirstOrDefault(x => x.MaHinhAnh == int.Parse(item.Id) && x.MaSanPham == id);

                if (item.Selected)
                {
                    if (currentDefaultImage != null && currentDefaultImage.MaHinhAnh != int.Parse(item.Id))
                    {
                        currentDefaultImage.IsDefault = false;
                        _context.HinhAnhs.Update(currentDefaultImage);
                    }
                    if (!image.IsDefault)
                    {
                        image.IsDefault = true;
                        _context.HinhAnhs.Update(image);
                    }
                }
                else if (image.IsDefault && !item.Selected)
                {
                }
            }

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();

        }

        public async Task<List<ProductVM>> GetFeatureProducts(int take)
        {


            // Tạo truy vấn
            var query = from sp in _context.SanPhams
                        join pic in _context.ProductInCategories on sp.MaSanPham equals pic.MaSanPham into sppic
                        from pic in sppic.DefaultIfEmpty()
                        join dm in _context.DanhMucs on pic.MaDanhMuc equals dm.MaDanhMuc into dmsp
                        from dm in dmsp.DefaultIfEmpty()
                        join ha in _context.HinhAnhs on sp.MaSanPham equals ha.MaSanPham into spha
                        from ha in spha.DefaultIfEmpty() // Kết nối trái cho hình ảnh
                        where sp.NoiBat == true && (ha == null || ha.IsDefault == true)
                        select new { sp, pic, ha, dm };


            var items = await query.OrderByDescending(x => x.sp.NgayTao).Take(take)
                .Select(x => new ProductVM
                {
                    MaSanPham = x.sp.MaSanPham,
                    TenSanPham = x.sp.TenSanPham,
                    TenDanhMuc = x.dm.TenDanhMuc,
                    Gia = x.sp.Gia,
                    MoTa = x.sp.MoTa,
                    KichThuoc = x.sp.KichThuoc,
                    MauSac = x.sp.MauSac,
                    SoLuongTon = x.sp.SoLuongTon,
                    HinhAnhChinh = x.ha.DuongDan, 
                    NoiBat = x.sp.NoiBat 
                })
                .ToListAsync();

            return items;
        }

        public async Task<List<ProductVM>> GetLatestProducts(int take)
        {

            var query = from sp in _context.SanPhams
                        join pic in _context.ProductInCategories on sp.MaSanPham equals pic.MaSanPham into sppic
                        from pic in sppic.DefaultIfEmpty()
                        join dm in _context.DanhMucs on pic.MaDanhMuc equals dm.MaDanhMuc into dmsp
                        from dm in dmsp.DefaultIfEmpty()
                        join ha in _context.HinhAnhs on sp.MaSanPham equals ha.MaSanPham into spha
                        from ha in spha.DefaultIfEmpty() // Kết nối trái cho hình ảnh
                        where (ha == null || ha.IsDefault == true)
                        select new { sp, pic, ha, dm };


            var items = await query.OrderByDescending(x => x.sp.NgayTao).Take(take)
                .Select(x => new ProductVM
                {
                    MaSanPham = x.sp.MaSanPham,
                    TenSanPham = x.sp.TenSanPham,
                    TenDanhMuc = x.dm.TenDanhMuc,
                    Gia = x.sp.Gia,
                    MoTa = x.sp.MoTa,
                    KichThuoc = x.sp.KichThuoc,
                    MauSac = x.sp.MauSac,
                    SoLuongTon = x.sp.SoLuongTon,
                    HinhAnhChinh = x.ha.DuongDan
                })
                .ToListAsync();

            return items;
        }

        public async Task<ProductVM> Detail(int IdSanPham)
        {
            var sanpham = await _context.SanPhams.FindAsync(IdSanPham);
            if (sanpham == null)
                return null;

            var danhmucs = await (from dm in _context.DanhMucs
                                  join pic in _context.ProductInCategories on dm.MaDanhMuc equals pic.MaDanhMuc
                                  where pic.MaSanPham == IdSanPham
                                  select dm.TenDanhMuc).ToListAsync();


            var hinhanhs = await _context.HinhAnhs
                .Where(x => x.MaSanPham == IdSanPham)
                .Select(x => x.DuongDan)
                .ToListAsync();

            var sanphamtViewModel = new ProductVM()
            {
                MaSanPham = sanpham.MaSanPham,
                TenSanPham = sanpham.TenSanPham,
                Category = danhmucs,
                Gia = sanpham.Gia,
                MoTa = sanpham.MoTa,
                KichThuoc = sanpham.KichThuoc,
                MauSac = sanpham.MauSac,
                SoLuongTon = sanpham.SoLuongTon,
                HinhAnhs = hinhanhs
            };

            return sanphamtViewModel;
        }

    }


}
