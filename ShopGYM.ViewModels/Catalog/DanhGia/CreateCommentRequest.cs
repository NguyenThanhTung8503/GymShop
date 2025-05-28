using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.DanhGia
{
    public class CreateCommentRequest
    {
        public int IdSanPham { get; set; }
        public string? NoiDung { get; set; }
        public Guid IdUser { get; set; }
        public DateTime NgayDanhGia { get; set; }
    }
}
