using ShopGYM.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class DonHang
    {
        public int MaDonHang { get; set; }
        public Guid MaNguoiDung { get; set; }
        public DateTime NgayDatHang { get; set; } 
        public decimal TongTien { get; set; }
        public TrangThaiDonHang TrangThai { get; set; }  
        public PhuongThucThanhToan PhuongThucThanhToan { get; set; } 
        public string DiaChiGiaoHang { get; set; }

        public AppUser AppUser { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public ICollection<GiaoDich> GiaoDichs { get; set; }
    }
}
