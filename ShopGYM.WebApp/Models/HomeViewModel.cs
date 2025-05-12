using ShopGYM.ViewModels.Catalog.SanPham;

namespace ShopGYM.WebApp.Models
{
    public class HomeViewModel
    {
        public List<ProductVM> FeaturedProducts { get; set; }
        public List<ProductVM> LatestProducts { get; set; }
    }
}
