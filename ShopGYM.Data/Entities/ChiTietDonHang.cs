using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class ChiTietDonHang
    {
        public int MaDonHang { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }

        public DonHang DonHang { get; set; }
        public SanPham SanPham { get; set; }
    }
}
