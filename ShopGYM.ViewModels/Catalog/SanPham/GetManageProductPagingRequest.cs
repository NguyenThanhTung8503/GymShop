using ShopGYM.Data.Enums;
using ShopGYM.ViewModels.Common;

namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public int? MaDanhMuc { get; set; } 
        public string? Keyword { get; set; } 


    }
}
