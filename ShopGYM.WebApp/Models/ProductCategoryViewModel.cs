using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Catalog.SanPham;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductVM> Products { get; set; }
    }
}
