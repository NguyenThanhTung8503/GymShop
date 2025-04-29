using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class ChiTietNhapHang
    {
        public int MaChiTietNhapHang { get; set; }
        public int MaNhapHang { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }

        public NhapHang NhapHang { get; set; }
        public SanPham SanPham { get; set; }
    }
}
