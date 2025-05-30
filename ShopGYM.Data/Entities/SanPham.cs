﻿using ShopGYM.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.Data.Entities
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public string? MoTa { get; set; }
        public string KichThuoc { get; set; }
        public string MauSac { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime NgayTao { get; set; }
        public bool NoiBat { get; set; }
        public ICollection<HinhAnh> HinhAnhs { get; set; }
        public List<GioHang> GioHangs { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public ICollection<DanhGia> DanhGias { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
