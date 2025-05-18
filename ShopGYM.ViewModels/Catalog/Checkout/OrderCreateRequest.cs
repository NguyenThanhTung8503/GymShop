using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.Checkout
{
    public class OrderCreateRequest
    {
        public Guid MaNguoiDung { get; set; }

        public DateTime NgayDatHang { get; set; }

        public int MaSanPham { get; set; }

        public decimal Gia { get; set; }

        public decimal TongTien { get; set; }
        public string SDT { get; set; }
        public string DiaChiGiaoHang { get; set; }

        public int SoLuong { get; set; }

    }
}
