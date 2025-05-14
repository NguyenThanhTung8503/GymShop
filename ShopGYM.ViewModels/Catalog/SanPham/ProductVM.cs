namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class ProductVM
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string? TenDanhMuc { get; set; } 
        public decimal Gia { get; set; }
        public string? MoTa { get; set; }
        public string KichThuoc { get; set; }
        public string MauSac { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnhChinh { get; set; } // Hình ảnh chính (hình đầu tiên từ HinhAnhs)
        public List<string> HinhAnhs { get; set; } = new List<string>(); // Danh sách hình ảnh
        public List<string> Category { get; set; } = new List<string>(); // Danh sách danh mục
    }
}
