using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.HinhAnh
{
    public class HinhAnhUpdateRequest
    {
        public int IdHinhAnh { get; set; }
        public string MoTa { get; set; }
        public int ThuTu { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
