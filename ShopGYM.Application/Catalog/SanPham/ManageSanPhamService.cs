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

namespace ShopGYM.Application.Catalog.SanPham
{
    public class ManageSanPhamService : IManageSanPhamService
    {
        private readonly ShopGYMDbContext _context;
        private readonly IStorageService _storageService;
        public ManageSanPhamService(ShopGYMDbContext context, IStorageService storageService)

        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(SanPhamCreateRequest request)
        {
            var sanpham = new Data.Entities.SanPham()
            {
                TenSanPham = request.TenSanPham,
                MaDanhMuc = request.MaDanhMuc,
                Gia = request.Gia,
                MoTa = request.MoTa,
                KichThuoc = request.KichThuoc,
                MauSac = request.MauSac,
                SoLuongTon = request.SoLuongTon
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
                        DuongDan = await SaveFile(request.ThumbnailImage),
                        ThuTu = 1
                    }
                };
            }

            _context.SanPhams.Add(sanpham);
            await _context.SaveChangesAsync();
            return sanpham.MaSanPham;
        }
        public async Task<int> Update(SanPhamUpdateRequest request)
        {
            var sanpham = await _context.SanPhams.FindAsync(request.IdSanPham);
            if (sanpham == null) throw new ShopGYMException($"Khong the tim thay san pham voi id: {request.IdSanPham}");
            sanpham.TenSanPham = request.TenSanPham;
            sanpham.MoTa = request.MoTa;
            sanpham.MauSac = request.MauSac;
            sanpham.KichThuoc = request.KichThuoc;

            //Save Images
            if (request.ThumbnailImage != null)
            {
                var thumbNailImage = await _context.HinhAnhs.FirstOrDefaultAsync(i => i.MaSanPham == request.IdSanPham);
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

        public async Task<PagedResult<SanPhamViewModel>> GetAllPaging(GetManageSanPhamPagingRequest request)
        {
            // Tạo truy vấn
            var query = from sp in _context.SanPhams
                        join dm in _context.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc
                        join ha in _context.HinhAnhs on sp.MaSanPham equals ha.MaSanPham into hinhAnhs
                        from ha in hinhAnhs.DefaultIfEmpty() // Kết nối trái cho hình ảnh
                        where ha == null || ha.ThuTu == (from h in _context.HinhAnhs
                                                         where h.MaSanPham == sp.MaSanPham
                                                         orderby h.ThuTu
                                                         select h.ThuTu).FirstOrDefault() // Lấy hình đầu tiên
                        select new { sp, dm, ha };

            // Áp dụng bộ lọc
            if (request.MaDanhMuc.HasValue)
            {
                query = query.Where(x => x.sp.MaDanhMuc == request.MaDanhMuc.Value);
            }

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.sp.TenSanPham.Contains(request.Keyword) ||
                                        x.sp.MoTa != null && x.sp.MoTa.Contains(request.Keyword));
            }

            if (request.MinPrice.HasValue)
            {
                query = query.Where(x => x.sp.Gia >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(x => x.sp.Gia <= request.MaxPrice.Value);
            }

            if (request.InStock.HasValue && request.InStock.Value)
            {
                query = query.Where(x => x.sp.SoLuongTon > 0);
            }

            // Sắp xếp
            switch (request.SortBy?.ToLower())
            {
                case "name":
                    query = query.OrderBy(x => x.sp.TenSanPham);
                    break;
                case "price_asc":
                    query = query.OrderBy(x => x.sp.Gia);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(x => x.sp.Gia);
                    break;
                default:
                    query = query.OrderBy(x => x.sp.MaSanPham); // Mặc định
                    break;
            }

            // Tính tổng số bản ghi (TotalRecords)
            int totalRecords = await query.CountAsync();

            var items = await query
                .Skip((request.PageIndex - 1) * request.PageSize) // Bỏ qua (PageIndex - 1) * PageSize bản ghi
                .Take(request.PageSize) // Lấy số bản ghi bằng PageSize
                .Select(x => new SanPhamViewModel
                {
                    MaSanPham = x.sp.MaSanPham,
                    TenSanPham = x.sp.TenSanPham,
                    TenDanhMuc = x.dm.TenDanhMuc.ToString(),
                    Gia = x.sp.Gia,
                    MoTa = x.sp.MoTa,
                    // Chuyển enum KichThuoc sang chuỗi để hiển thị (ví dụ: "S", "M")
                    KichThuoc = x.sp.KichThuoc.ToString(),
                    MauSac = x.sp.MauSac,
                    SoLuongTon = x.sp.SoLuongTon,
                    HinhAnhChinh = x.ha != null ? x.ha.DuongDan : null
                })
                .ToListAsync(); // Thực thi truy vấn và trả về danh sách SanPhamViewModel

            // Trả về kết quả phân trang
            return new PagedResult<SanPhamViewModel>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
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
            var fileName = $"{Guid.NewGuid()}.{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<int> AddImage(int IdSanPham, HinhAnhCreateRequest request)
        {
            var hinhanh = new HinhAnh()
            {
                Mota = request.MoTa,
                NgayTao = DateTime.Now,
                MaSanPham = IdSanPham,
                ThuTu = request.ThuTu
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
            _context.HinhAnhs.Update(hinhanh);
            return await _context.SaveChangesAsync();
        }

        public async Task<SanPhamViewModel> GetById(int IdHinhAnh)
        {
            var sanpham = await _context.SanPhams.FindAsync(IdHinhAnh);
            if (sanpham == null)
                return null;
            var danhmuc = await _context.DanhMucs
                        .Where(dm => dm.MaDanhMuc == sanpham.MaDanhMuc)
                        .Select(dm => dm.TenDanhMuc)
                        .FirstOrDefaultAsync();

            var hinhanh = await _context.HinhAnhs.Where(x => x.MaSanPham == IdHinhAnh).FirstOrDefaultAsync();

            var sanphamtViewModel = new SanPhamViewModel()
            {
                MaSanPham = sanpham.MaSanPham,
                TenSanPham = sanpham.TenSanPham,
                TenDanhMuc = danhmuc,
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
                ThuTu = hinhanh.ThuTu
            };
            return viewModel;
        }

        public async Task<List<HinhAnhViewModel>> GetListImages(int IdSanPham)
        {
            return await _context.HinhAnhs.Where(x => x.MaSanPham == IdSanPham)
                .Select(i => new HinhAnhViewModel()
                {
                    Mota = i.Mota,
                    NgayTao = i.NgayTao,
                    MaHinhAnh = i.MaHinhAnh,
                    DuongDan = i.DuongDan,
                    MaSanPham = i.MaSanPham,
                    ThuTu = i.ThuTu
                }).ToListAsync();
        }
    }


}
