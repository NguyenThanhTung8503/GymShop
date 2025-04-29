using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class HinhAnh
    {
        public int MaHinhAnh { get; set; }
        public string DuongDan { get; set; } 
        public int MaSanPham { get; set; }
        public string Mota { get; set; }
        public DateTime NgayTao { get; set; }
        public int? MaDanhGia { get; set; }
        public int ThuTu { get; set; }

        public SanPham SanPham { get; set; }
        public DanhGia DanhGia { get; set; }
    }
}
