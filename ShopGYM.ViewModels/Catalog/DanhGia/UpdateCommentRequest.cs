using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.DanhGia
{
    public class UpdateCommentRequest
    {
        public int Id { get; set; }
        public int IdSanPham { get; set; }
        public string? NoiDung { get; set; }
        public Guid IdUser { get; set; }
    }
}
