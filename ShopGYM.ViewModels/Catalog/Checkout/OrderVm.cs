using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGYM.ViewModels.Catalog.Checkout
{
    public class OrderVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public Guid UserId { get; set; }

        public string PhoneNumber { get; set; }
        public string NameProduct { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
