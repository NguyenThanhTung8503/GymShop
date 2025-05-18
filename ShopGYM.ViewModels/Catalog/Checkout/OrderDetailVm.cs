using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.Checkout
{
    public class OrderDetailVm
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }
    }
}
