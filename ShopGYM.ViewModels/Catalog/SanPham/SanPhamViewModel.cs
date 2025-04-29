namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class SanPhamViewModel
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string TenDanhMuc { get; set; } // Từ DanhMuc
        public decimal Gia { get; set; }
        public string MoTa { get; set; }
        public string KichThuoc { get; set; }
        public string MauSac { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnhChinh { get; set; } // Hình ảnh chính (hình đầu tiên từ HinhAnhs)
    }
}
