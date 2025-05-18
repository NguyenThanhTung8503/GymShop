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
        public string TenNguoiNhan { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string SDT { get; set; }

        public AppUser AppUser { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

    }
}
