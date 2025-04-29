using ShopGYM.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class GiaoDich
    {
        public int MaGiaoDich { get; set; }
        public int MaDonHang { get; set; }
        public string MaGiaoDichCuaCong { get; set; }
        public decimal SoTien { get; set; }
        public TrangThaiGiaoDich TrangThai { get; set; } // Sử dụng enum
        public DateTime NgayGiaoDich { get; set; }
        public CongThanhToan CongThanhToan { get; set; } // Sử dụng enum

        public DonHang DonHang { get; set; }
    }
}
