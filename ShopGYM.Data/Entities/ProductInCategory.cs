using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class ProductInCategory
    {
        public int MaSanPham { get; set; }

        public SanPham SanPham { get; set; }

        public int MaDanhMuc { get; set; }

        public DanhMuc DanhMuc { get; set; }
    }
}
