using ShopGYM.ViewModels.Catalog.Checkout;

namespace ShopGYM.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}
