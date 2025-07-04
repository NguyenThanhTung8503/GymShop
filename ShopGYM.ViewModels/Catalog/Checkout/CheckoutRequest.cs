﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.Checkout
{
    public class CheckoutRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public Guid UserId { get; set; }

        public string? PhoneNumber { get; set; }
        public string? PhuongThucThanhToan { get; set; }

        public List<OrderDetailVm> OrderDetails { set; get; } = new List<OrderDetailVm>();
    }
}
