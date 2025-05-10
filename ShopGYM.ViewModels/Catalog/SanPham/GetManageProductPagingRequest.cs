using ShopGYM.Data.Enums;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public int? MaDanhMuc { get; set; } // Lọc theo danh mục
        public string? Keyword { get; set; } // Tìm kiếm theo tên hoặc mô tả


    }
}
