using Microsoft.EntityFrameworkCore;
using ShopGYM.Data.EF;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopGYM.Application.Catalog.SanPham
{
    public class PublicSanPhamService : IPublicSanPhamService
    {
        private readonly ShopGYMDbContext _context;
        public PublicSanPhamService(ShopGYMDbContext context)

        {
            _context = context;
        }

        public async Task<PagedResult<SanPhamViewModel>> GetAllByMaDanhMuc(GetPublicSanPhamPagingRequest request)
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
            if (request.IdDanhMuc.HasValue)
            {
                query = query.Where(x => x.sp.MaDanhMuc == request.IdDanhMuc.Value);
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
            return new PagedResult<SanPhamViewModel>
            {
                TotalRecords = totalRecords,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = items
            };
        }
    }
}
