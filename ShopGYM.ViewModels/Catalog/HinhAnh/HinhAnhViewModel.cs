using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.HinhAnh
{
    public class HinhAnhViewModel
    {
        public int MaHinhAnh { get; set; }
        public int MaSanPham { get; set; }
        public string Mota { get; set; }
        public string DuongDan { get; set; }
        public DateTime NgayTao { get; set; }
        public int MaDanhGia { get; set; }
        public int ThuTu { get; set; }
    }
}
