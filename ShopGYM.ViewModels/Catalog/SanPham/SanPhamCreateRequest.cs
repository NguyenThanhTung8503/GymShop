using Microsoft.AspNetCore.Http;
using ShopGYM.Data.Enums;

namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class SanPhamCreateRequest
    {
        public string TenSanPham { get; set; }
        public int MaDanhMuc { get; set; }
        public decimal Gia { get; set; }
        public string MoTa { get; set; }
        public string KichThuoc { get; set; }
        public string MauSac { get; set; }
        public int SoLuongTon { get; set; }
        public ICollection<string> HinhAnhs { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
