using Microsoft.EntityFrameworkCore;
using ShopGYM.Data.EF;
using ShopGYM.Data.Entities;
using ShopGYM.Utilities.Exceptions;
using ShopGYM.ViewModels.Catalog.Checkout;
using ShopGYM.ViewModels.Catalog.SanPham;

namespace ShopGYM.Application.Catalog.DonHang
{
    public class OrderService : IOrderService
    {
        private readonly ShopGYMDbContext _context;
        public OrderService(ShopGYMDbContext context)

        {
            _context = context;
        }
        public async Task<int> CreateOrder(CheckoutRequest request)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                // Tạo và lưu DonHang
                var donHang = new Data.Entities.DonHang()
                {
                    MaNguoiDung = request.UserId,
                    DiaChiGiaoHang = request.Address,
                    NgayDatHang = DateTime.Now,
                    SDT = request.PhoneNumber,
                    TenNguoiNhan = request.Name,
                };

                _context.DonHangs.Add(donHang);
                await _context.SaveChangesAsync();

                // Lưu ChiTietDonHang từ OrderDetails
                if (request.OrderDetails != null && request.OrderDetails.Any())
                {
                    foreach (var orderDetail in request.OrderDetails)
                    {
                        var chiTietDonHang = new ChiTietDonHang()
                        {
                            MaSanPham = orderDetail.ProductId,
                            SoLuong = orderDetail.Quantity,
                            Gia = orderDetail.Total,
                            MaDonHang = donHang.MaDonHang // Liên kết với MaDonHang vừa tạo
                        };

                        _context.ChiTietDonHangs.Add(chiTietDonHang);
                    }
                    await _context.SaveChangesAsync();
                }

                // Commit giao dịch
                await transaction.CommitAsync();

                return donHang.MaDonHang;
            }
        }

        public async Task<int> Delete(int Id)
        {
            var donhang = await _context.DonHangs.FindAsync(Id);
            if (donhang == null) throw new ShopGYMException($"Khong the tim thay don hang: {Id}");

            _context.DonHangs.Remove(donhang);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(OrderUpdateRequest request)
        {
            var sanpham = await _context.DonHangs.FindAsync(request.UserId);
            if (sanpham == null) throw new ShopGYMException($"Khong the tim thay san pham voi id: {request.UserId}");
            sanpham.TenNguoiNhan = request.Name;
            sanpham.DiaChiGiaoHang = request.Address;
            sanpham.SDT = request.PhoneNumber;

            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderVm>> GetAll(Guid userId)
        {
            // Fetch data from the database
            var orders = await _context.DonHangs
                .Where(dh => dh.MaNguoiDung == userId)
                .Include(dh => dh.ChiTietDonHangs) // Include related ChiTietDonHang
                    .ThenInclude(ct => ct.SanPham) // Include related SanPham
                .OrderByDescending(dh => dh.NgayDatHang)
                .ToListAsync();

            // Transform to OrderVm in memory
            var items = orders.Select(dh => new OrderVm
            {
                Id = dh.MaDonHang,
                Name = dh.TenNguoiNhan,
                Address = dh.DiaChiGiaoHang,
                UserId = dh.MaNguoiDung,
                PhoneNumber = dh.SDT,
                CreatedDate = dh.NgayDatHang,
                NameProduct = string.Join(", ", dh.ChiTietDonHangs.Select(ct => ct.SanPham.TenSanPham)),
                Quantity = dh.ChiTietDonHangs.Sum(ct => ct.SoLuong),
                Total = dh.ChiTietDonHangs.Sum(ct => ct.Gia * ct.SoLuong)
            }).ToList();

            return items ?? new List<OrderVm>();
        }


        public async Task<OrderVm> GetById(int MaDonHang)
        {
            var donHang = await _context.DonHangs
                .Include(dh => dh.AppUser) // Bao gồm thông tin AppUser
                .FirstOrDefaultAsync(dh => dh.MaDonHang == MaDonHang);

            if (donHang == null)
                return null;

            var orderVm = new OrderVm
            {
                Id = donHang.MaDonHang,
                Name = donHang.TenNguoiNhan,
                CreatedDate = donHang.NgayDatHang,
                Address = donHang.DiaChiGiaoHang,
                PhoneNumber = donHang.SDT,
            };

            return orderVm;
        }
    }
}
