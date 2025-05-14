using Microsoft.AspNetCore.Http;
using ShopGYM.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopGYM.ViewModels.Catalog.SanPham
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Giá")]
        public decimal Gia { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Kích thước")]
        public string KichThuoc { get; set; }

        [Display(Name = "Màu sắc")]
        public string MauSac { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int SoLuongTon { get; set; }

        [Display(Name = "Hình ảnh")]
        public IFormFile? ThumbnailImage { get; set; }
    }
}
