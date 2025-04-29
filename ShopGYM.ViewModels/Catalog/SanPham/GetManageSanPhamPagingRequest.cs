using ShopGYM.Data.Enums;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class GetManageSanPhamPagingRequest : PagingRequestBase
    {
        public int? MaDanhMuc { get; set; } // Lọc theo danh mục
        public string Keyword { get; set; } // Tìm kiếm theo tên hoặc mô tả
        public decimal? MinPrice { get; set; } // Giá tối thiểu
        public decimal? MaxPrice { get; set; } // Giá tối đa
        public string? KichThuoc { get; set; } // Lọc theo kích thước
        public string? MauSac { get; set; } // Lọc theo màu sắc
        public bool? InStock { get; set; } // Lọc sản phẩm còn hàng
        public string SortBy { get; set; } // Sắp xếp: "name", "price_asc", "price_desc"
    }
}
