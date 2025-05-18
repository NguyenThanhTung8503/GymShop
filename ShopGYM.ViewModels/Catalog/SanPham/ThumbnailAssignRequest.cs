using ShopGYM.ViewModels.Common;

namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class ThumbnailAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Images { get; set; } = new List<SelectItem>();
    }
}
