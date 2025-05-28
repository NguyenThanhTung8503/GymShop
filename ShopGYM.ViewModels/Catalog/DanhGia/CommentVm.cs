using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.DanhGia
{
    public class CommentVm
    {
        public int Id { get; set; }
        public string? NoiDung { get; set; }
        public DateTime NgayDanhGia { get; set; }
        public string? TenNguoiDanhGia { get; set; }
        public Guid MaNguoiDung { get; set; } 
    }
}
