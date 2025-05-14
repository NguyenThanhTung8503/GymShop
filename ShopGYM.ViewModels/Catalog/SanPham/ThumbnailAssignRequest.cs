using ShopGYM.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class ThumbnailAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Images { get; set; } = new List<SelectItem>();
    }
}
