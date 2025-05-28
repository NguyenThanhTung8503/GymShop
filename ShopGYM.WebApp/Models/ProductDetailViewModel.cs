using ShopGYM.ViewModels.Catalog.DanhGia;
using ShopGYM.ViewModels.Catalog.DanhMuc;
using ShopGYM.ViewModels.Catalog.HinhAnh;
using ShopGYM.ViewModels.Catalog.SanPham;

namespace ShopGYM.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryVm Category { get; set; }

        public ProductVM Product { get; set; }

        public List<ProductVM> RelatedProducts { get; set; }

        public List<HinhAnhViewModel> ProductImages { get; set; }
        public List<CommentVm> Comments { get; set; } = new List<CommentVm>();
    }
}
