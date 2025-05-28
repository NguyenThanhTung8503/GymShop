using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class DanhGia
    {
        public int MaDanhGia { get; set; }
        public int MaSanPham { get; set; }
        public Guid MaNguoiDung { get; set; }
        public string? NoiDung { get; set; }
        public DateTime NgayDanhGia { get; set; }

        public SanPham SanPham { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<HinhAnh> HinhAnhs { get; set; }
    }
}
