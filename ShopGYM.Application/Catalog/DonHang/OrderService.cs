using Microsoft.EntityFrameworkCore;
using ShopGYM.Data.EF;
using ShopGYM.Data.Entities;
using ShopGYM.Utilities.Exceptions;
using ShopGYM.ViewModels.Catalog.Checkout;

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
                try
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
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw; // Ném lại ngoại lệ để xử lý ở cấp cao hơn
                }
            }
        }

        public async Task<int> CreateOrderDetail(OrderDetailVm request, int id)
        {

            var donhang = new ChiTietDonHang()
            {
                MaSanPham = request.ProductId,
                SoLuong = request.Quantity,
                Gia = request.Total,
                MaDonHang = id,
            };

            _context.ChiTietDonHangs.Add(donhang);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var donhang = await _context.DonHangs.FindAsync(Id);
            if (donhang == null) throw new ShopGYMException($"Khong the tim thay don hang: {Id}");

            _context.DonHangs.Remove(donhang);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderVm>> GetAll()
        {
            var query = from sp in _context.SanPhams
                        join od in _context.ChiTietDonHangs on sp.MaSanPham equals od.MaSanPham
                        join dh in _context.DonHangs on od.MaDonHang equals dh.MaDonHang
                        select new
                        {
                            sp, dh,od
                        };


            var items = await query
                .Select(x => new OrderVm
                {
                    Id = x.dh.MaDonHang,
                    Name = x.dh.TenNguoiNhan,
                    NameProduct = x.sp.TenSanPham,
                    Total = x.od.Gia,
                    PhoneNumber = x.dh.SDT,
                    Quantity = x.od.SoLuong,
                    CreatedDate = x.dh.NgayDatHang,
                    Address = x.dh.DiaChiGiaoHang
                })
                .OrderByDescending(x => x.Address)
                .ToListAsync();
            return items;

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
