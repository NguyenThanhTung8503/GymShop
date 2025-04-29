using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class NhapHang
    {
        public int MaNhapHang { get; set; }
        public int MaNhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }

        public NhaCungCap NhaCungCap { get; set; }
        public ICollection<ChiTietNhapHang> ChiTietNhapHangs { get; set; }
    }
}
