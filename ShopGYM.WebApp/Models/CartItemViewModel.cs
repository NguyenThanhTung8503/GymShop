namespace ShopGYM.WebApp.Models
{
    public class CartItemViewModel
    {
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public string Image { get; set; }
        public string MoTa { get; set; }
        public string TenSanPham { get; set; }
        public decimal Gia { get; set; }
    }
}
