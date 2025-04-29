using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class GioHang
    {
        public int MaGioHang { get; set; }
        public Guid MaNguoiDung { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }

        public AppUser AppUser { get; set; }
        public SanPham SanPham { get; set; }
    }
}
